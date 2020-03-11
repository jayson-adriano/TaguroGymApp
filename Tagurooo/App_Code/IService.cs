using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;


[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebGet(UriTemplate = "hi", ResponseFormat = WebMessageFormat.Json)]
    //[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string hello();

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LogIn/{userName}/{password}")]
    string LogIn(string userName, string password);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Register/{lastName}/{firstName}/{middleName}/{userName}/{password}/{emailAddress}")]
    string Register(string lastName, string firstName, string middleName, string userName, string password, string emailAddress);
        
    [OperationContract]   
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ShowCourseByTime/{time}")]
    string[] ShowCourseByTime(string time);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ShowCourseDescriptionAndPrice/{courseCode}")]
    string[] ShowCourseDescriptionAndPrice(string courseCode);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ShowCourseByInstructor/{firstName}")]
    string[] ShowCourseByInstructor(string firstName);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string[] ShowInstructors();

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCourseToSched/{courseCode}/{custID}")]
    string AddCourseToSched(string courseCode, string custID);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "getCustomerID/{userName}")]
    string getCustomerID(string userName);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "BindEnrollSched/{custID}")]
    string[] BindEnrollSched(string custID);


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ViewCustomerProfile/{custID}")]
    string[] ViewCustomerProfile(string custID);//change to no parameter later

    [OperationContract]
    //[WebGet(UriTemplate = "ViewCustomerSchedule?custID={custID}", ResponseFormat = WebMessageFormat.Json)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string[] ViewCustomerSchedule(string custID);//change to no parameter later

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ComputeTotal/{custID}")]
    string ComputeTotal(string custID);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "CheckIfDiscounted/{custID}")]
    string CheckIfDiscounted(string custID);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ComputeDiscounted/{custID}")]
    string ComputeDiscounted(string custID);

    [OperationContract]
    //[WebGet(UriTemplate = "ComputeGrandTotal?custID={custID}", ResponseFormat = WebMessageFormat.Json)]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string GetCoursePrice(string courseID);
    
    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateInventoryCredit/{custID}/{amount}/{credit}")]
    string UpdateInventoryCredit(string custID, string amount, string credit);

   [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateInventoryGym/{custID}/{amount}")]
    string UpdateInventoryGym(string custID, string amount);


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ViewInventory/{custID}")]
    string[] ViewInventory(string custID);


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string[] GetQuizQuestions();


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PromoAvailed/{custID}")]
    string PromoAvailed(string custID);

    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubmitFeedback/{feedback}/{custID}")]
    string SubmitFeedback(string feedback, string custID);


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string[] GetRandomFeedback();


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "EditProfile/{custID}/{lastName}/{firstName}/{middleName}/{emailAddress}")]
    string EditProfile(string custID, string lastName, string firstName, string middleName, string emailAddress);


    [OperationContract]
    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ClearSchedule/{custID}")]
    string ClearSchedule(string custID);
    
}
