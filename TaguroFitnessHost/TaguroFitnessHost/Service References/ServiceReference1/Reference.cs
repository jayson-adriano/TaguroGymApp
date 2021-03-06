﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaguroFitnessHost.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogIn", ReplyAction="http://tempuri.org/IService/LogInResponse")]
        string LogIn(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogIn", ReplyAction="http://tempuri.org/IService/LogInResponse")]
        System.Threading.Tasks.Task<string> LogInAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        string Register(string lastName, string firstName, string middleName, string userName, string password, string emailAddress, string month, string day, string year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string lastName, string firstName, string middleName, string userName, string password, string emailAddress, string month, string day, string year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseByTime", ReplyAction="http://tempuri.org/IService/ShowCourseByTimeResponse")]
        string[] ShowCourseByTime(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseByTime", ReplyAction="http://tempuri.org/IService/ShowCourseByTimeResponse")]
        System.Threading.Tasks.Task<string[]> ShowCourseByTimeAsync(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseDescriptionAndPrice", ReplyAction="http://tempuri.org/IService/ShowCourseDescriptionAndPriceResponse")]
        string[] ShowCourseDescriptionAndPrice(string courseCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseDescriptionAndPrice", ReplyAction="http://tempuri.org/IService/ShowCourseDescriptionAndPriceResponse")]
        System.Threading.Tasks.Task<string[]> ShowCourseDescriptionAndPriceAsync(string courseCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseByInstructor", ReplyAction="http://tempuri.org/IService/ShowCourseByInstructorResponse")]
        string[] ShowCourseByInstructor(string firstName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowCourseByInstructor", ReplyAction="http://tempuri.org/IService/ShowCourseByInstructorResponse")]
        System.Threading.Tasks.Task<string[]> ShowCourseByInstructorAsync(string firstName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddCourseToSched", ReplyAction="http://tempuri.org/IService/AddCourseToSchedResponse")]
        string AddCourseToSched(string courseCode, int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddCourseToSched", ReplyAction="http://tempuri.org/IService/AddCourseToSchedResponse")]
        System.Threading.Tasks.Task<string> AddCourseToSchedAsync(string courseCode, int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewCustomerProfile", ReplyAction="http://tempuri.org/IService/ViewCustomerProfileResponse")]
        string[] ViewCustomerProfile(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewCustomerProfile", ReplyAction="http://tempuri.org/IService/ViewCustomerProfileResponse")]
        System.Threading.Tasks.Task<string[]> ViewCustomerProfileAsync(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewCustomerSchedule", ReplyAction="http://tempuri.org/IService/ViewCustomerScheduleResponse")]
        string[] ViewCustomerSchedule(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewCustomerSchedule", ReplyAction="http://tempuri.org/IService/ViewCustomerScheduleResponse")]
        System.Threading.Tasks.Task<string[]> ViewCustomerScheduleAsync(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/computeDiscounted", ReplyAction="http://tempuri.org/IService/computeDiscountedResponse")]
        string computeDiscounted(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/computeDiscounted", ReplyAction="http://tempuri.org/IService/computeDiscountedResponse")]
        System.Threading.Tasks.Task<string> computeDiscountedAsync(int custID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : TaguroFitnessHost.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<TaguroFitnessHost.ServiceReference1.IService>, TaguroFitnessHost.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string LogIn(string userName, string password) {
            return base.Channel.LogIn(userName, password);
        }
        
        public System.Threading.Tasks.Task<string> LogInAsync(string userName, string password) {
            return base.Channel.LogInAsync(userName, password);
        }
        
        public string Register(string lastName, string firstName, string middleName, string userName, string password, string emailAddress, string month, string day, string year) {
            return base.Channel.Register(lastName, firstName, middleName, userName, password, emailAddress, month, day, year);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string lastName, string firstName, string middleName, string userName, string password, string emailAddress, string month, string day, string year) {
            return base.Channel.RegisterAsync(lastName, firstName, middleName, userName, password, emailAddress, month, day, year);
        }
        
        public string[] ShowCourseByTime(string time) {
            return base.Channel.ShowCourseByTime(time);
        }
        
        public System.Threading.Tasks.Task<string[]> ShowCourseByTimeAsync(string time) {
            return base.Channel.ShowCourseByTimeAsync(time);
        }
        
        public string[] ShowCourseDescriptionAndPrice(string courseCode) {
            return base.Channel.ShowCourseDescriptionAndPrice(courseCode);
        }
        
        public System.Threading.Tasks.Task<string[]> ShowCourseDescriptionAndPriceAsync(string courseCode) {
            return base.Channel.ShowCourseDescriptionAndPriceAsync(courseCode);
        }
        
        public string[] ShowCourseByInstructor(string firstName) {
            return base.Channel.ShowCourseByInstructor(firstName);
        }
        
        public System.Threading.Tasks.Task<string[]> ShowCourseByInstructorAsync(string firstName) {
            return base.Channel.ShowCourseByInstructorAsync(firstName);
        }
        
        public string AddCourseToSched(string courseCode, int custID) {
            return base.Channel.AddCourseToSched(courseCode, custID);
        }
        
        public System.Threading.Tasks.Task<string> AddCourseToSchedAsync(string courseCode, int custID) {
            return base.Channel.AddCourseToSchedAsync(courseCode, custID);
        }
        
        public string[] ViewCustomerProfile(int custID) {
            return base.Channel.ViewCustomerProfile(custID);
        }
        
        public System.Threading.Tasks.Task<string[]> ViewCustomerProfileAsync(int custID) {
            return base.Channel.ViewCustomerProfileAsync(custID);
        }
        
        public string[] ViewCustomerSchedule(int custID) {
            return base.Channel.ViewCustomerSchedule(custID);
        }
        
        public System.Threading.Tasks.Task<string[]> ViewCustomerScheduleAsync(int custID) {
            return base.Channel.ViewCustomerScheduleAsync(custID);
        }
        
        public string computeDiscounted(int custID) {
            return base.Channel.computeDiscounted(custID);
        }
        
        public System.Threading.Tasks.Task<string> computeDiscountedAsync(int custID) {
            return base.Channel.computeDiscountedAsync(custID);
        }
    }
}
