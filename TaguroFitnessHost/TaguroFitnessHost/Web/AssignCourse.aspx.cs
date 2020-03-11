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
    public partial class AssignCourse : System.Web.UI.Page
    {
        Admin obj = new Admin();
        protected void bindGrid()
        {
            DataTable dt = obj.ViewAvailableCourses();
            gridviewAvailableCourses.DataSource = dt.Copy();
            gridviewAvailableCourses.DataBind();
        }
        protected void bindGrid2()
        {
            string id = obj.ChooseCourse(txtCourseID.Text);
            DataTable dt = obj.ViewAvailableInstructors(id);
            gridviewAvailableInstructor.DataSource = dt.Copy();
            gridviewAvailableInstructor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gridviewAvailableInstructor.Visible = true;
            gridviewAvailableCourses.Visible = true;
            gridviewAvailableInstructor.Visible = true;
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
             
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course Selected!');", true);
                bindGrid2();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course_ID is not in the table.');", true);
                txtCourseID.Text = String.Empty;
            }
        }
        protected void OnButtonClick2(object sender, EventArgs e)
        {
            if (isIDInside2(txtAvailableInstructor.Text))
            {
                obj.AssignCourse(int.Parse(txtAvailableInstructor.Text), txtCourseID.Text);
                bindGrid();
                bindGrid2();
                gridviewAvailableInstructor.Visible = false;
                txtAvailableInstructor.Text = String.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Schedule added!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Instructor_ID is not in the table.');", true);
                txtAvailableInstructor.Text = String.Empty;
            }
        }
        protected bool isIDInside(string txtID)
        {
            DataTable dt = obj.ViewAvailableCourses();
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
        protected bool isIDInside2(string txtID)
        {

            string id = obj.ChooseCourse(txtCourseID.Text);
            DataTable dt = obj.ViewAvailableInstructors(id);
            DataView dv = dt.DefaultView;

            foreach (DataRowView drv in dv)
            {
                string id2 = drv.Row["Instructor_ID"].ToString();

                if (id2 == txtID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}