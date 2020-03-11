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
    public partial class Inventory : System.Web.UI.Page
    {
        Admin obj = new Admin();
        protected void bindGrid()
        {
            DataTable dt = obj.ViewInventory();
            gridviewSales.DataSource = dt.Copy();
            gridviewSales.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Web/SessionExpired.aspx");
            }
            bindGrid();
        }
    }
}