using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using admin;
using System.Data;

namespace TaguroFitnessHost.Web
{
    public partial class ConfirmPayments : System.Web.UI.Page
    {

        Admin obj = new Admin();
        protected void bindGrid()
        {
            DataTable dt = obj.ViewPaymentRequest();
            gridviewConfirmPayments.DataSource = dt.Copy();
            gridviewConfirmPayments.DataBind();
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
            if (isIDInside(txtCustID.Text))
            {
                obj.EditPaymentStatus(int.Parse(txtCustID.Text));
                bindGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Payment approved!.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Sales_ID is not in the table.');", true);
                txtCustID.Text = String.Empty;
            }
        }
        protected bool isIDInside(string txtID)
        {
            DataTable dt = obj.ViewPaymentRequest();
            DataView dv = dt.DefaultView;

            foreach (DataRowView drv in dv)
            {
                string id = drv.Row["Sales_ID"].ToString();

                if (id == txtID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}