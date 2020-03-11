using System;
using System.Collections.Generic;

namespace TaguroFitnessHost.Web
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}