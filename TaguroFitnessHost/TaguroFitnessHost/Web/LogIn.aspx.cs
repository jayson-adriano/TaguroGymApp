using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using admin;

namespace TaguroFitnessHost.Web
{
    public partial class LogIn : System.Web.UI.Page
    {
        Admin obj = new Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["userID"] = obj.logIn(txtBoxLoginUserName.Text.ToString(), txtBoxLoginPassword.Text.ToString());

            if (txtBoxLoginPassword.Text == String.Empty || txtBoxLoginUserName.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Username or Password must not be empty!');", true);
                txtBoxLoginUserName.Text = String.Empty;
                txtBoxLoginPassword.Text = String.Empty;
            }
            else if (int.Parse(Session["userID"].ToString()) == 1)
            {
                Response.Redirect("~/Web/Home.aspx");
            }
            else if (int.Parse(Session["userID"].ToString()) == 2)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Invalid account details.');", true);
                txtBoxLoginUserName.Text = String.Empty;
                txtBoxLoginPassword.Text = String.Empty;
            }

        }
    }
}