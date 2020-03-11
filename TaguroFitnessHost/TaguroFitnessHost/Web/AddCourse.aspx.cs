using System;
using System.Data;
using System.Web.UI;
using admin;

namespace TaguroFitnessHost.Web
{
    public partial class AddCourse : System.Web.UI.Page
    {
        Admin obj = new Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Web/SessionExpired.aspx");
            }
        }
        protected void OnButtonClick(object sender, EventArgs e)
        {
            string dummy = "ok";
            string courseCode = txtCourseID.Text;
            if (txtCourseID.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode must not be empty!');", true);
            }
            else if (courseCode.Length != 5)
            {
                dummy = "not ok";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                txtCourseID.Text = String.Empty;
            }

            else if (txtPrice.Text == String.Empty || txtDescription.Text == String.Empty)
            {

                dummy = "not ok";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Price and Description must not be empty!');", true);

            }
            else {
                if (courseCode[3] == 'M')
                {
                    txtDay.Text = "Monday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                else if (courseCode[3] == 'T')
                {
                    txtDay.Text = "Tuesday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                //day = "Tuesday"; }
                else if (courseCode[3] == 'W')
                {
                    txtDay.Text = "Wednesday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                //day = "Wednesday"; }
                else if (courseCode[3] == 'H')
                {
                    txtDay.Text = "Thursday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                //day = "Thursday"; }
                else if (courseCode[3] == 'F')
                {
                    txtDay.Text = "Friday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }

                //day = "Friday"; }
                else if (courseCode[3] == 'S')
                {
                    txtDay.Text = "Saturday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                //day = "Saturday"; }
                else if (courseCode[3] == 'U')
                {
                    txtDay.Text = "Sunday";
                    if (courseCode[4] == '1')
                    {
                        txtTime.Text = "9-12";
                    }
                    else if (courseCode[4] == '2')
                    {
                        txtTime.Text = "12-3";
                    }
                    else if (courseCode[4] == '3')
                    {
                        txtTime.Text = "3-6";
                    }
                    else
                    {
                        dummy = "not ok";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                }
                else {
                    dummy = "not ok";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Coursecode not in correct format!');", true);
                    txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                    txtDescription.Text = String.Empty;
                }

                if (dummy == "ok")
                {
                    string dum = obj.AddCourse(txtCourseID.Text, txtDay.Text, txtTime.Text, int.Parse(txtPrice.Text), txtDescription.Text);

                    if (dum == "Course added!")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course Added!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Course already exists!');", true);
                        txtCourseID.Text = String.Empty; txtPrice.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                    }
                    
                }
            }
        }
    }
}