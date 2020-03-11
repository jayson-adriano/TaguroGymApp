using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace admin
{
    public class Admin
    {
        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = TaguroFitnessApp; Integrated Security = False; User ID = melly; Password=1234567");
        Helper help = new Helper();

        //LOG IN
        public int logIn(string userName, string password)
        {
            if (userName == "admin" && password == "melly")
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

        //ADD COURSE
        public string AddCourse(string courseId, string day, string time, int price, string description)
        {

            SqlCommand cmd = new SqlCommand("AdminCheckIfCourseExists", con); //check if username does not exists
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar, 10).Value = courseId;
            SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
            sqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlParam);

            help.checkingHelper(cmd, con);
            int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

            if (result == 1) //username not exists
            {
                cmd = new SqlCommand("AdminAddCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Course_ID", SqlDbType.VarChar, 10).Value = courseId;
                cmd.Parameters.Add("@Day", SqlDbType.VarChar, 20).Value = day;
                cmd.Parameters.Add("@Time", SqlDbType.VarChar, 20).Value = time;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = description;
                cmd.Parameters.Add("@PricePerSess", SqlDbType.Int).Value = price;
                help.resultHelper(cmd);
                return "Course added!";
            }
            else { return "Course already exists!"; }
        }

        //ADD INSTRUCTOR
        public string AddInstructor(string lastName, string firstName, string middleName, string email, string month, string day, string year, string userName, string password, string gender, string password2)
        {
            string months;
            if (month == "January")
            {  months = "1"; }
            else if (month == "February")
            { months = "2"; }
            else if (month == "March")
            { months = "3"; }
            else if (month == "April")
            { months = "4"; }
            else if (month == "May")
            { months = "5"; }
            else if (month == "June")
            { months = "6"; }
            else if (month == "July")
            { months = "7"; }
            else if (month == "August")
            { months = "8"; }
            else if (month == "September")
            { months = "9"; }
            else if (month == "October")
            { months = "10"; }
            else if (month == "November")
            { months = "11"; }
            else
            { months = "12"; }

            if (password != password2)
            {
                return "Password does not match!";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("CheckIfUsernameExist", con); //check if username does not exists
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
                SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
                sqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqlParam);

                help.checkingHelper(cmd, con);
                int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

                if (result == 1)
                {
                    DateTime birthday;
                    string bday = year + "-" + months + "-" + day;
                    birthday = DateTime.Parse(bday);
                    string results = "A";
                    cmd = new SqlCommand("AddInstructor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 20).Value = lastName;
                    cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = firstName;
                    cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 20).Value = middleName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = email;
                    cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = birthday;
                    cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = password;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = gender;

                    results = help.addHelper(cmd, con);

                    if (results == "Success connection.")
                    {
                        int id = int.Parse(getInstructorID(userName));
                        return AdminPopulateSchedTable(id);
                    }
                    else
                    {
                        int id = int.Parse(getInstructorID(userName));
                        return AdminPopulateSchedTable(id);
                    }

                }
                else
                {
                    return "Username exists!!!";
                }
            }
        }
        public string getInstructorID(string userName)
        {
            SqlCommand cmd2 = new SqlCommand("AdminGetInstructorID", con);
            cmd2.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
            cmd2.CommandType = CommandType.StoredProcedure;

            DataTable dt = help.resultHelper(cmd2);
            string id = dt.Rows[0][0].ToString();
            return id;

        }
        public string AdminPopulateSchedTable(int instID)
        {
            SqlCommand cmd = new SqlCommand("AdminPopulateSchedTable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Instructor_ID", SqlDbType.Int).Value = instID;
            cmd.Parameters.Add("@Monday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Tuesday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Wednesday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Thursday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Friday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Saturday", SqlDbType.VarChar, 50).Value = "--";
            cmd.Parameters.Add("@Sunday", SqlDbType.VarChar, 50).Value = "--";

            help.addHelper(cmd, con);

            return "Instructor Added!";
        }     

        //REMOVE COURSE
        public DataTable ViewCourses()
        {
            SqlCommand cmd = new SqlCommand("AdminViewCourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            return help.resultHelper(cmd);
        }
        public DataTable RemoveCourse(string courseID)
        {
            SqlCommand cmd = new SqlCommand("AdminRemoveCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Course_ID", SqlDbType.VarChar, 10).Value = courseID;
            return help.resultHelper(cmd);
        }

        //CONFIRM PAYMENTS
        public DataTable ViewPaymentRequest()
        {
            SqlCommand cmd = new SqlCommand("AdminGetPendingPayments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            return help.resultHelper(cmd);
        }
        public DataTable EditPaymentStatus(int salesID)
        {
            SqlCommand cmd = new SqlCommand("AdminUpdatePaymentStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Sales_ID", SqlDbType.Int).Value = salesID;
            return help.resultHelper(cmd);
        }
        //INVENTORY
        public DataTable ViewInventory()
        {
            SqlCommand cmd = new SqlCommand("AdminGetInventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            return help.resultHelper(cmd);
        }

        //ASSIGN COURSE
        public DataTable ViewAvailableCourses()
        {
            SqlCommand cmd = new SqlCommand("AdminGetAvailableCourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            return help.resultHelper(cmd);
        }
        public string ChooseCourse(string courseID)
        {
            SqlCommand cmd2 = new SqlCommand("AdminGetDayofCourse", con);
            cmd2.Parameters.Add("@Course_ID", SqlDbType.VarChar, 10).Value = courseID;
            cmd2.CommandType = CommandType.StoredProcedure;

            DataTable dt = help.resultHelper(cmd2);
            string id = dt.Rows[0][0].ToString();

            return id;

        }
        public DataTable ViewAvailableInstructors(string id)
        {
            
            SqlCommand cmd;
            if (id == "Monday")
            {
                cmd = new SqlCommand("AdminGetAvailableInstructorsForMonday", con);
            }
            else if (id == "Tuesday")
            {
                cmd = new SqlCommand("AdminGetAvailableInstructorsForTuesday", con);
            }
            //day = "Tuesday"; }
            else if (id == "Wednesday")
            {
                cmd = new SqlCommand("AdminGetAvailableInstructorsForWednesday", con);
            }
            //day = "Wednesday"; }
            else if (id == "Thursday")
            {
                cmd = new SqlCommand("AdminGetAvailableInstructorsForThursday", con);
            }
            //day = "Thursday"; }
            else if (id == "Friday")
            { cmd = new SqlCommand("AdminGetAvailableInstructorsForFriday", con); }

            //day = "Friday"; }
            else if (id == "Saturday")
            { cmd = new SqlCommand("AdminGetAvailableInstructorsForSaturday", con); }
            //day = "Saturday"; }
            else
            { cmd = new SqlCommand("AdminGetAvailableInstructorsForSunday", con); }

            cmd.CommandType = CommandType.StoredProcedure;
            return help.resultHelper(cmd);
        }
        public void AssignCourse(int insID, string courseCode)
        {
            SqlCommand cmd;
            //check 3rd character from courseCode for DAY
            if (courseCode[3] == 'M')
            {
                cmd = new SqlCommand("AdminAssignMondayCourse", con);
            }
            else if (courseCode[3] == 'T')
            {
                cmd = new SqlCommand("AdminAssignTuesdayCourse", con);
            }
            //day = "Tuesday"; }
            else if (courseCode[3] == 'W')
            {
                cmd = new SqlCommand("AdminAssignWednesdayCourse", con);
            }
            //day = "Wednesday"; }
            else if (courseCode[3] == 'H')
            {
                cmd = new SqlCommand("AdminAssignThursdayCourse", con);
            }
            //day = "Thursday"; }
            else if (courseCode[3] == 'F')
            { cmd = new SqlCommand("AdminAssignFridayCourse", con); }

            //day = "Friday"; }
            else if (courseCode[3] == 'S')
            { cmd = new SqlCommand("AdminAssignSaturdayCourse", con); }
            //day = "Saturday"; }
            else
            { cmd = new SqlCommand("AdminAssignSundayCourse", con); }
            //day = "Sunday"; }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Course_ID", SqlDbType.VarChar, 20).Value = courseCode;
            cmd.Parameters.Add("@Instructor_ID", SqlDbType.Int).Value = insID;

            help.addHelper(cmd, con);
        }


        //APPROVE REGISTRATION
        //public DataTable ViewRegistrationRequest()
        //{
        //    SqlCommand cmd = new SqlCommand("AdminGetPendingMembers", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    return help.resultHelper(cmd);
        //}
        //public DataTable EditRegistrationStatus(int custID)
        //{
        //    SqlCommand cmd = new SqlCommand("AdminUpdateRegistrationStatus", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID;
        //    return help.resultHelper(cmd);
        //}

        //APPROVE SCHEDULE
        //public DataTable ViewScheduleRequest()
        //{
        //    SqlCommand cmd = new SqlCommand("AdminGetPendingSchedule", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    return help.resultHelper(cmd);
        //}

        //public DataTable EditScheduleStatus(int custID)
        //{
        //    SqlCommand cmd = new SqlCommand("AdminUpdateScheduleStatus", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID;
        //    return help.resultHelper(cmd);
        //}
    }

}
