using System;
using System.Web.UI;
using admin;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace TaguroFitnessHost.Web
{
    public partial class AddInstructor : System.Web.UI.Page
    {
        Admin obj = new Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlYear.Items.Clear();
                this.ddlYear.DataSource = populateYears();
                this.ddlYear.DataBind();

                this.ddlMonth.Items.Clear();
                this.ddlMonth.DataSource = populateMonths();
                this.ddlMonth.DataBind();

            }
        }

        protected void OnButtonClick(object sender, EventArgs e)
        {
            if (ddlDay.Text == String.Empty || txtEmail.Text == String.Empty || txtFirstName.Text == String.Empty || txtLastName.Text == String.Empty || txtMiddleName.Text == String.Empty || ddlMonth.Text == String.Empty || txtPassword.Text == String.Empty || txtPassword2.Text == String.Empty || txtUserName.Text == String.Empty || ddlYear.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('All fields must not be empty!');", true);
            }
            else
            {
                string res = "A";
                res = obj.AddInstructor(txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtEmail.Text, ddlMonth.Text, ddlDay.Text, ddlYear.Text, txtUserName.Text, txtPassword.Text, ddGender.SelectedItem.ToString(), txtPassword2.Text);
                if (res == "Instructor Added!")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Instructor Added!');", true);
                    txtLastName.Text = String.Empty;
                    txtFirstName.Text = String.Empty;
                    txtMiddleName.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    //txtDay.Text = String.Empty;
                    //txtMonth.Text = String.Empty;
                    //txtYear.Text = String.Empty;
                    txtUserName.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtPassword2.Text = String.Empty;

                }
                else if (res == "Username exists!!!")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Username exists!');", true);
                    txtUserName.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtPassword2.Text = String.Empty;
                }
                else if (res == "Password does not match!")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Password does not match!');", true);
                    txtPassword.Text = String.Empty;
                    txtPassword2.Text = String.Empty;
                }

            }
        }


        public List<string> populateYears()
        {
            List<string> years = new List<string>();

            for (int i = 1950; i < 2017; i++)
            {
                years.Add(i.ToString());
            }

            return years;
        }

        protected void ddlYear_Load(object sender, EventArgs e)
        {
            populateYears();
        }


        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlDay.Items.Clear();
            this.ddlDay.DataSource = populateDays();
            this.ddlDay.DataBind();

        }

        protected void ddlMonth_Load(object sender, EventArgs e)
        {
            populateMonths();
        }

        public List<string> populateMonths()
        {
            List<string> month = new List<string>();
            month.Add("January");
            month.Add("February");
            month.Add("March");
            month.Add("April");
            month.Add("May");
            month.Add("June");
            month.Add("July");
            month.Add("August");
            month.Add("September");
            month.Add("October");
            month.Add("November");
            month.Add("December");
            return month;   
        }


        public List<string> populateDays()
        {
            List<string> days = new List<string>();


            if (ddlMonth.SelectedItem.ToString() == "September" || ddlMonth.SelectedItem.ToString() == "April" || ddlMonth.SelectedItem.ToString() == "June" || ddlMonth.SelectedItem.ToString() == "November")
            {
                //30
                for (int i = 1; i < 31; i++)
                {
                    days.Add(i.ToString());
                }
            }
            else if (ddlMonth.SelectedItem.ToString() == "February")
            {
                if (ddlYear.SelectedItem.ToString() == "1951" || ddlYear.SelectedItem.ToString() == "1955" || ddlYear.SelectedItem.ToString() == "1959" || ddlYear.SelectedItem.ToString() == "1963" || ddlYear.SelectedItem.ToString() == "1967" || ddlYear.SelectedItem.ToString() == "1971" || ddlYear.SelectedItem.ToString() == "1975" || ddlYear.SelectedItem.ToString() == "1979" || ddlYear.SelectedItem.ToString() == "1983" || ddlYear.SelectedItem.ToString() == "1987" || ddlYear.SelectedItem.ToString() == "1991" || ddlYear.SelectedItem.ToString() == "1995" || ddlYear.SelectedItem.ToString() == "1999" || ddlYear.SelectedItem.ToString() == "2004" || ddlYear.SelectedItem.ToString() == "2008" || ddlYear.SelectedItem.ToString() == "2012" || ddlYear.SelectedItem.ToString() == "2016")
                {
                    //29
                    for (int i = 1; i < 30; i++)
                    {
                        days.Add(i.ToString());
                    }
                }
                else
                {
                    //28
                    for (int i = 1; i < 29; i++)
                    {
                        days.Add(i.ToString());
                    }
                }
            }
            else
            {
                //31
                for (int i = 1; i < 32; i++)
                {
                    days.Add(i.ToString());
                }
            }


            return days;
        }
    }

}
