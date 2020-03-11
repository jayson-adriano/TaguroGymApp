using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using admin;

namespace TaguroFitnessHost.Web
{
    public partial class RemoveCourse : System.Web.UI.Page
    {
        Admin obj = new Admin();
        protected void bindGrid()
        {
            DataTable dt = obj.ViewCourses();
            gridviewRemoveCourse.DataSource = dt.Copy();
            gridviewRemoveCourse.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Web/SessionExpired.aspx");
            }
            bindGrid();
        }
        protected void OnButtonClick(object sender, EventArgs e)
        {
            if (isIDInside(txtCourseID.Text))
            {
                obj.RemoveCourse(txtCourseID.Text);
                bindGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course Deleted!.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course_ID is not in the table.');", true);
                txtCourseID.Text = String.Empty;
            }
        }
        protected bool isIDInside(string txtID)
        {
            DataTable dt = obj.ViewCourses();
            DataView dv = dt.DefaultView;

            foreach (DataRowView drv in dv)
            {
                string id = drv.Row["Course_ID"].ToString();

                if (id == txtID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}