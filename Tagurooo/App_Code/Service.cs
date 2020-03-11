using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel.Activation;


[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
public class Service : IService
{
    SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = TaguroFitnessApp; Integrated Security = False; User ID = melly; Password=1234567");
    Helper hlp = new Helper();
    int userID;

    public string hello()
    {
        return "hello!";
    }
    public string LogIn(string userName, string password)
    {
        if ((userName == "admin" && password == "melly") || (userName == "carl" && password == "vasquez") || (userName == "lean" && password == "pimentel"))
        {
            return "YOU ARE AN ADMIN!";
        }
        else
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckIfUsernameExist", con); //check if username does not exists
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
                SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
                sqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqlParam);

                hlp.checkingHelper(cmd, con);
                int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

                if (result == 1)
                {
                    return "USER NAME DOES NOT EXIST";
                }
                else //username exists
                {
                    cmd = new SqlCommand("CheckIfUsernameAndPasswordMatched", con); //check if username and password matches
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                    sqlParam = new SqlParameter("@Result", DbType.Boolean);
                    sqlParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(sqlParam);

                    hlp.checkingHelper(cmd, con);
                    result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

                    if (result == 1)
                    {
                        return "USERNAME AND PASSWORD DOES NOT MATCH!"; //username and password does not match
                    }
                    else //USERNAME AND PASSWORD MATCHED";
                    {
                        cmd = new SqlCommand("CheckIfInstructor", con); //check if instructor
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = userName;

                        DataTable dt = hlp.resultHelper(cmd);

                        if (dt.Rows.Count > 0) //instructor
                        {
                            userID = int.Parse(dt.Rows[0][0].ToString());   //accountID
                            string userIDS = dt.Rows[0][0].ToString();
                            //return string.Format("Your account ID is {0}", userIDS);
                            return "YOU ARE AN INSTRUCTOR!";
                        }
                        else
                        {
                            cmd = new SqlCommand("AssginAccountID", con); //assign accountID
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;

                            DataTable dt2 = hlp.resultHelper(cmd);

                            if (dt2.Rows.Count > 0)
                            {
                                userID = int.Parse(dt2.Rows[0][0].ToString());   //accountID
                                string userIDS = dt2.Rows[0][0].ToString();
                                //return string.Format("Your account ID is {0}", userIDS);
                                return "SUCCESS";
                            }
                            else
                            {
                                return "EMPTY!"; //invalid input: empty
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    public DataTable getCustomerRow(string actID)
    {
        int actID2 = int.Parse(actID);
        SqlCommand cmd = new SqlCommand("SetCustomerID", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Account_ID", SqlDbType.Int, 20).Value = actID2;

        return hlp.resultHelper(cmd);
    }
    //public int getCustomerID(int actID)
    //{
    //    int id = 0;
    //    DataTable dt = getCustomerRow(userID);
    //    DataView dv = dt.DefaultView;

    //    foreach (DataRowView drv in dv)
    //    {
    //        id = int.Parse(drv.Row["Customer_ID"].ToString());
    //    }

    //    return id;
    //}
    public string Register(string lastName, string firstName, string middleName, string userName, string password, string emailAddress)
    {
        //string lastName, string firstName, string middleName, string userName, string password, string emailAddress, string month, string day, string year
        //string lastName = "Roxas";
        //string firstName = "Mar";
        //string middleName = "Duterte";
        //string userName = "Mardut";
        //string password = "Dudirty";
        //string emailAddress = "mar@korina.com";

        SqlCommand cmd = new SqlCommand("CheckIfUsernameExist", con); //check if username does not exists
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
        SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
        sqlParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(sqlParam);

        hlp.checkingHelper(cmd, con);
        int result = int.Parse(cmd.Parameters["@Result"].Value.ToString());

        if (result == 1)
        {
            string results = "A";
            cmd = new SqlCommand("RegisterAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 20).Value = lastName;
            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = firstName;
            cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 20).Value = middleName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = emailAddress;
            cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = password;
            results = hlp.addHelper(cmd, con);

            //return results;
            if (results == "Success connection.")
            {
                string id = getCustomerID(userName).ToString();
                return PopulateSchedTable(id);
            }

            else
            {
                return "Holy shit";
            }


            //int id = int.Parse(getCustomerID(userName));
            //return PopulateSchedTable(id);
            // return "SUCCESS";

        }
        else
        {
            return "Username exists!!!";
        }
    }
    public string getCustomerID(string userName)
    {
        SqlCommand cmd2 = new SqlCommand("getCustomerID", con);
        cmd2.Parameters.Add("@User_Name", SqlDbType.VarChar, 20).Value = userName;
        cmd2.CommandType = CommandType.StoredProcedure;

        DataTable dt = hlp.resultHelper(cmd2);
        string id = dt.Rows[0][0].ToString();
        return id;

    }
    public string PopulateSchedTable(string custID)
    {
        int custID2 = int.Parse(custID);
        SqlCommand cmd = new SqlCommand("populateSchedTable", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID2;
        cmd.Parameters.Add("@Monday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Tuesday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Wednesday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Thursday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Friday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Saturday", SqlDbType.VarChar, 50).Value = "--";
        cmd.Parameters.Add("@Sunday", SqlDbType.VarChar, 50).Value = "--";

        hlp.addHelper(cmd, con);

        return "Registration Sent for Approval!";
    }

    //ENROLLMENT--------------------------------------------------------

    public string[] ShowCourseByTime(string time)
    {
        //string time = "9-12";
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("showCourseByTime", con);
        cmd.Parameters.Add("@Time", SqlDbType.VarChar, 10).Value = time;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        int count = dt.Rows.Count;
        List<string> courses = new List<string>();

        for (int i = 0; i < count; i++)//rows
        {
            courses.Add(dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString());
        }
        string[] result = courses.ToArray();

        return result;
    }
    public string[] ShowCourseDescriptionAndPrice(string courseCode)
    {
        //string courseCode = "BOXM1";
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("showCourseDescriptionAndPrice", con);
        cmd.Parameters.Add("@Course_ID", SqlDbType.VarChar, 10).Value = courseCode;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);

        string[] result = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
        return result;
    }
    public string[] ShowCourseByInstructor(string firstName)
    {
        //string firstName = "Jose";
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("getInstructorID", con);
        cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = firstName;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);

        int insID = (int.Parse(dt.Rows[0][0].ToString()));

        DataTable dt2 = new DataTable();
        cmd = new SqlCommand("showCourseByInstructor", con);
        cmd.Parameters.Add("@Instructor_ID", SqlDbType.VarChar, 20).Value = insID;
        cmd.CommandType = CommandType.StoredProcedure;

        dt2 = hlp.resultHelper(cmd);

        string[] result = dt2.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
        return result;

    }
    public string[] ShowInstructors()
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("getInstructors", con);
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        int count = dt.Rows.Count;
        List<string> instructors = new List<string>();

        for (int i = 0; i < count; i++)//rows
        {
            instructors.Add(dt.Rows[i][0].ToString() + "|" + dt.Rows[i][1].ToString() + "|" + dt.Rows[i][2].ToString());
        }
        string[] result = instructors.ToArray();

        return result;
    }
    public string AddCourseToSched(string courseCode, string custID)
    {
        int custID2 = int.Parse(custID);
        //string courseCode = "BOXT3";
        //int custID = getCustomerID(userID);

        //int custID = 3;
        SqlCommand cmd;
        //check 3rd character from courseCode for DAY
        if (courseCode[3] == 'M')
        {
            cmd = new SqlCommand("updateMSchedTable", con);
        }
        else if (courseCode[3] == 'T')
        {
            cmd = new SqlCommand("updateTSchedTable", con);
        }
        //day = "Tuesday"; }
        else if (courseCode[3] == 'W')
        {
            cmd = new SqlCommand("updateWSchedTable", con);
        }
        //day = "Wednesday"; }
        else if (courseCode[3] == 'H')
        {
            cmd = new SqlCommand("updateHSchedTable", con);
        }
        //day = "Thursday"; }
        else if (courseCode[3] == 'F')
        { cmd = new SqlCommand("updateFSchedTable", con); }

        //day = "Friday"; }
        else if (courseCode[3] == 'S')
        { cmd = new SqlCommand("updateSSchedTable", con); }
        //day = "Saturday"; }
        else
        { cmd = new SqlCommand("updateSchedTable", con); }
        //day = "Sunday"; }

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Course_ID", SqlDbType.VarChar, 20).Value = courseCode;
        cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID2;

        hlp.addHelper(cmd, con);
        return "Course " + courseCode + " added!";
    }
    public string[] BindEnrollSched(string custID)
    {
        int custID2 = int.Parse(custID);
        //string custID = "10";
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("showCustomerSchedule", con);
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        int count = dt.Rows.Count;
        List<string> courses = new List<string>();

        for (int i = 0; i < count; i++)//rows
        {
            courses.Add(dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + " " + dt.Rows[i][4].ToString() + " " + dt.Rows[i][5].ToString() + " " + dt.Rows[i][6].ToString());
        }
        string[] result = courses.ToArray();

        return result;
    }

    //when finalize enrollment button clicked
    public string ComputeTotal(string custID)
    {
        int custID2 = int.Parse(custID);
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("viewCustomerSchedule", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 10).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        hlp.resultHelper(cmd);
        dt = hlp.resultHelper(cmd);

        char selectPrice = 'A';
        int price = 0;
        for (int i = 0; i < 6; i++)
        {
            string courseString = dt.Rows[0][i].ToString();
            selectPrice = courseString[0]; //get first character

            switch (selectPrice)
            {
                case 'B':   //boxing
                    price += 250;
                    break;
                case 'Z':   //zumba
                    price += 150;
                    break;
                case 'Y':   //yoga
                    price += 450;
                    break;
                case 'M':   //muay thai
                    price += 300;
                    break;
                case 'T':   //taekwondo
                    price += 300;
                    break;
                default:
                    break;
            }
        }

        return price.ToString();
    }
    public string CheckIfDiscounted(string custID)
    {
        int custID2 = int.Parse(custID);
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("checkPromoed", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 10).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        hlp.resultHelper(cmd);
        dt = hlp.resultHelper(cmd);

        string discounted = dt.Rows[0][0].ToString();
        if (discounted == "True")
            return "10%";
        else
        {
            return "None.";
        }
    }
    public string ComputeDiscounted(string custID)
    {
        int custID2 = int.Parse(custID);
        //int custID = 4;
        string grandTotal = "lala";
        int totalPrice = int.Parse(ComputeTotal(custID));
       // int totalPrice = 300;
        int discounted = 0;


        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("checkPromoed", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 10).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        hlp.resultHelper(cmd);
        dt = hlp.resultHelper(cmd);

        grandTotal = dt.Rows[0][0].ToString();
        if (grandTotal == "True")
        {
            discounted = totalPrice- Convert.ToInt32((totalPrice*.10));
            return discounted.ToString();
        }
        else
        {
            return totalPrice.ToString();
        }
        //return grandTotal + totalPrice.ToString() ;
    }
    public string GetCoursePrice(string courseID)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("checkPromoed", con);
        cmd.Parameters.Add("Course_ID", SqlDbType.VarChar, 10).Value = courseID;
        cmd.CommandType = CommandType.StoredProcedure;

        hlp.resultHelper(cmd);
        dt = hlp.resultHelper(cmd);

        string price = dt.Rows[0][0].ToString();
        return price;
    }

    public string UpdateInventoryCredit(string custID, string amount, string credit)
    {
        int custID2 = int.Parse(custID);
        int amount2 = int.Parse(amount);
        int credit2 = int.Parse(credit);
        //int custID = 5;
        //int amount = 550;
        //int credit = 100001;
        SqlCommand cmd = new SqlCommand("UpdateInventoryCredit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = amount2;
        cmd.Parameters.Add("@Credit", SqlDbType.Int).Value = credit2;
        string result = hlp.addHelper(cmd, con);
        return result;
    }
    public string UpdateInventoryGym(string custID, string amount)
    {
        int custID2 = int.Parse(custID);
        int amount2 = int.Parse(amount);
        //int custID = 5;
        //int amount = 550;
        SqlCommand cmd = new SqlCommand("UpdateInventoryGym", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = amount2;
        string result = hlp.addHelper(cmd, con);
        return result;
    }


    //PROFILE------------------------------------------------------------
    public string[] ViewCustomerProfile(string custID)
    {
        int custID2 = int.Parse(custID);
        //int custID = 4;
        // int custID = userID; //set after logging in
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("viewCustomerProfile", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        string[] result = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
        return result;

    }
    public string[] ViewCustomerSchedule(string custID)
    {
        int custID2 = int.Parse(custID);
        //int custID = 4;
        //int custID = userID; //set after logging in
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("viewCustomerSchedule", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        string[] result = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
        return result;
    }
    public string[] ViewInventory(string custID)
    {
        int custID2 = int.Parse(custID);
        //int custID = 7;
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("GetLatestInventory", con);
        cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = custID2;
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        if (dt.Rows.Count > 0)
        {
            string[] result = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            return result;
        }
        else {
            string[] results = { "You are not yet paid!" };
            return results;
        }

    }
    public string EditProfile(string custID, string lastName, string firstName, string middleName, string emailAddress)
    { 
        int custID2 = int.Parse(custID);
       
        string results = "A";
        SqlCommand cmd = new SqlCommand("EditProfile", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 20).Value = lastName;
        cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 20).Value = firstName;
        cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 20).Value = middleName;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = emailAddress;
        results = hlp.addHelper(cmd, con);
        return results;
    }

    //QUIZ----------------------------------------------------------------
    public string[] GetQuizQuestions()
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("GetRandomQuiz", con);
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        int count = dt.Rows.Count;
        List<string> questions = new List<string>();

        for (int i = 0; i < count; i++)//rows
        {
            questions.Add(dt.Rows[i][0].ToString() + "|" + dt.Rows[i][1].ToString());
        }
        string[] result = questions.ToArray();

        return result;
    }
    public string PromoAvailed(string custID)
    {
        int custID2 = int.Parse(custID);
        SqlCommand cmd = new SqlCommand("PromoAvailed", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        string result = hlp.addHelper(cmd, con);
        return result;
    }

    //FEEDBACK-------------------------------------------------------------
    public string SubmitFeedback(string feedback, string custID)
    {
        int custID2 = int.Parse(custID);
        SqlCommand cmd = new SqlCommand("SubmitFeedback", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        cmd.Parameters.Add("@Feedback", SqlDbType.VarChar, 200).Value = feedback;
        string result = hlp.addHelper(cmd, con);
        return result;
    }
    public string[] GetRandomFeedback()
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("GetRandomFeedback", con);
        cmd.CommandType = CommandType.StoredProcedure;

        dt = hlp.resultHelper(cmd);
        int count = dt.Rows.Count;
        List<string> feedback = new List<string>();

        for (int i = 0; i < count; i++)//rows
        {
            feedback.Add(dt.Rows[i][0].ToString());
        }
        string[] result = feedback.ToArray();

        return result;
    }

    //SCHEDULE----------------------------------------------------------------
    public string ClearSchedule(string custID)
    {
        int custID2 = int.Parse(custID);
        SqlCommand cmd = new SqlCommand("ClearSchedule", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Cust_ID", SqlDbType.Int).Value = custID2;
        string result = hlp.addHelper(cmd, con);
        return result;
    }
}
