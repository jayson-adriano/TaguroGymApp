var globalVar = [];
var globalClear;
function SessionStore() {
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/getCustomerID",
        data:
            "{" +
            "\"userName\":\"" + inputUserName.value + "\"" +
            "}",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "jsonp",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.getCustomerIDResult;
            sessionStorage.setItem("ID", result.toString());
        },
        error: function (msg) {
            alert(msg.responseText + "error");
        }

    });
}
function LogIn() {
    //debugger;
    $.ajax({
        type: "POST",
        url: "http://tagurofitness.com/Tagurooo/Service.svc/LogIn",
        data:
            "{" +
            "\"userName\":\"" + inputUserName.value + "\"," +
            "\"password\":\"" + inputPassword.value + "\"" +
            "}",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json",
        //processdata: true,
        //async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.LogInResult;
            //alert(result.toString());
            if (result.toString() == "SUCCESS") {
                //sessionStorage.setItem("ID", inputUserName.value);
               // SessionStore();
                location.href = "Main.html";
            }
            else {
                alert("Error Password or Username.")
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            if (xmlHttpRequest.readyState == 0 || xmlHttpRequest.status == 0)
                return;  // it's not really an error
            else
                alert(msg.responseText + "error" + XMLHttpRequest.responseText);// Do normal error handling
        //error: function (XMLHttpRequest, msg) {
        //    alert(msg.responseText + "error" + XMLHttpRequest.responseText);
        }

    });
}

function Register() {
    //debugger;
    if (password.value === password2.value) {
        alert("Start Registration");
        $.ajax({

            type: "POST",
            url: "http://localhost/Tagurooo/Service.svc/Register",
            data:
                //JSON.stringify({
                //    studNum: studnum.value
                //}),
                "{" +
                "\"lastName\":\"" + lastnamesignup.value + "\"," +
                 "\"firstName\":\"" + firstnamesignup.value + "\"," +
                  "\"middleName\":\"" + middlenamesignup.value + "\"," +
                   "\"userName\":\"" + username.value + "\"," +
                    "\"password\":\"" + password.value + "\"," +
                     "\"emailAddress\":\"" + emailadd.value + "\"," +
                      "\"month\":\"" + month.value + "\"," +
                       "\"day\":\"" + day.value + "\"," +
                "\"year\":\"" + year.value + "\"" +
                "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            async: false,
            beforeSend: function (xhr) {
                xhr.withCredentials = true;
                xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
            },
            success: function (data) {
                var result = data.RegisterResult;
                alert(result.toString());
                if (result.toString() == "Registration Sent for Approval!") {
                    alert("Registration Sent for Approval.");
                    location.href = "index.html";
                }
                else {
                   // alert("Something Goes Wrong")
                }
            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });
    }
    else {
        alert("Passwords did not match!");
        password.value = "";
        password2.value = "";
    }
}

function EditProfile() {
    var sess = sessionStorage.getItem("ID");
    //alert(sess.toString());
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/EditProfile",
        data:
            "{" +
             "\"custID\":\"" + sess.toString() + "\"," +
            "\"lastName\":\"" + LastNameProfile.value + "\"," +
             "\"firstName\":\"" + FirstNameProfile.value + "\"," +
              "\"middleName\":\"" + MiddleNameProfile.value + "\"," +
                 "\"emailAddress\":\"" + EmailProfile.value + "\"," +
                  "\"month\":\"" + MonthProfile.value + "\"," +
                   "\"day\":\"" + DayProfile.value + "\"," +
            "\"year\":\"" + YearProfile.value + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.EditProfileResult;
            //alert(result.toString());
            if (result.toString() == "Success connection.") {
                alert("Profile Edited!");
            }
            else {
                alert("Profile not updated.")
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });

}

function CheckIfAlreadyEnrolled() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/BindEnrollSched",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var courses = [];
            var temp = [];
            var j = 0;
            var result = data.BindEnrollSchedResult.toString();

            var mySplitResult = result.split(" ");
            for (i = 0; i < mySplitResult.length; i++) {
                courses[i] = mySplitResult[i];
                if (courses[i].toString() != "--") {
                    temp[j] = "enrolled";
                    j++;
                }
                else {
                }
            }
            if (temp[0].toString() == "enrolled") {
                alert("You are already enrolled! Clear your SCHEDULE and enroll again.");
                location.href = "Main.html";
            }
            else { }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function Selectmorningclass() {
    //debugger;
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseByTime",
        data: "{" +
            "\"time\":\"" + "9-12" + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var choices = [];
            var myString = data.ShowCourseByTimeResult.toString();
            var mySplitResult = myString.split(",");

            for (i = 0; i < mySplitResult.length; i++) {
                choices[i] = mySplitResult[i];
            }
            var sel = document.getElementById('classchoicebytime');
            document.getElementById('classchoicebytime').options.length = 0;
            for (var i = 0; i < choices.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = choices[i];
                opt.value = choices[i];
                sel.appendChild(opt);
            } //sel[sel.selectedIndex].value
        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}
function Selectlunchclass() {
    //debugger;
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseByTime",
        data: "{" +
            "\"time\":\"" + "12-3" + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var choices = [];
            var myString = data.ShowCourseByTimeResult.toString();
            var mySplitResult = myString.split(",");

            for (i = 0; i < mySplitResult.length; i++) {
                choices[i] = mySplitResult[i];
            }
            var sel = document.getElementById('classchoicebytime');
            document.getElementById('classchoicebytime').options.length = 0;
            for (var i = 0; i < choices.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = choices[i];
                opt.value = choices[i];
                sel.appendChild(opt);
            }

        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });

}
function Selectafternoonclass() {
    //debugger;
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseByTime",
        data: "{" +
            "\"time\":\"" + "3-6" + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var choices = [];
            var myString = data.ShowCourseByTimeResult.toString();
            var mySplitResult = myString.split(",");

            for (i = 0; i < mySplitResult.length; i++) {
                choices[i] = mySplitResult[i];
            }
            var sel = document.getElementById('classchoicebytime');
            document.getElementById('classchoicebytime').options.length = 0;
            for (var i = 0; i < choices.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = choices[i];
                opt.value = choices[i];
                sel.appendChild(opt);
            }

        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });

}

function ShowInstructors() {
    $.ajax({
        type: "GET",
        data: "",
        url: "http://localhost/Tagurooo/Service.svc/ShowInstructors",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var choice = $('instructorchoice');
            var choices = [];
            var myString = data.ShowInstructorsResult.toString();
            var mySplitResult = myString.split(",");

            for (i = 0; i < mySplitResult.length; i++) {
                choices[i] = mySplitResult[i];
            }
            var sel = document.getElementById('instructorchoice');
            for (var i = 0; i < choices.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = choices[i];
                opt.value = choices[i];
                sel.appendChild(opt);
            }
        },
        error: function (msg) {
            alert(msg.responseText);

        }

    });

}
function GetInstructorSched() {
    //debugger;
    var e = document.getElementById('instructorchoice');//get choice
    var ins = e.options[e.selectedIndex].text;
    var mySplitResult = ins.split("|"); //get first name

    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseByInstructor",
        data: "{" +
            "\"firstName\":\"" + mySplitResult[0].toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var choice = $('choiceschedbyprof');
            var choices = [];
            var myString = data.ShowCourseByInstructorResult.toString();
            var mySplitResult = myString.split(",");

            for (i = 0; i < mySplitResult.length; i++) {
                choices[i] = mySplitResult[i];
            }
            choices.remove("--");

            var sel = document.getElementById('choiceschedbyprof');
            document.getElementById('choiceschedbyprof').options.length = 0;
            for (var i = 0; i < choices.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = choices[i];
                opt.value = choices[i];
                sel.appendChild(opt);
            }

        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });

}

function UpdateEnrollSched() {
    var sess = sessionStorage.getItem("ID");
   // alert(sess.toString());
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/BindEnrollSched",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var courses = [];
            var result = data.BindEnrollSchedResult.toString();

            var mySplitResult = result.split(" ");
            for (i = 0; i < mySplitResult.length; i++) {
                courses[i] = mySplitResult[i];
            }
     
            //alert(courses.toString());
            for (i = 0; i < 7; i++) {
                if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "M" ) {
                    $("#mon1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "M" ) {
                    $("#mon2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "M" ) {
                    $("#mon3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "T") {
                    $("#tue1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "T") {
                    $("#tue2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "T") {
                    $("#tue3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "W") {
                    $("#wed1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "W") {
                    $("#wed2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "W") {
                    $("#wed3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "H" ) {
                    $("#thu1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "H") {
                    $("#thu2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "H") {
                    $("#thu3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "F") {
                    $("#fri1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "F" ) {
                    $("#fri2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "F") {
                    $("#fri3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "S" ) {
                    $("#sat1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "S") {
                    $("#sat2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "S") {
                    $("#sat3").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "1" && courses[i].charAt(3).toString() == "U") {
                    $("#sun1").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "2" && courses[i].charAt(3).toString() == "U") {
                    $("#sun2").text(courses[i].toString());
                }
                else if (courses[i].charAt(4).toString() == "3" && courses[i].charAt(3).toString() == "U") {
                    $("#sun3").text(courses[i].toString());
                }
                else { };
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function AddCourseByTime() {
    //debugger;
    var sess = sessionStorage.getItem("ID");

    var e = document.getElementById('classchoicebytime');//get choice
    var ins = e.options[e.selectedIndex].text;
    var mySplitResult = ins.split(" "); //get coursecode

    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/AddCourseToSched",
        data: "{" +
            "\"courseCode\":\"" + mySplitResult[0].toString() + "\"," +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.AddCourseToSchedResult;
            UpdateEnrollSched();
            alert(result.toString());
        },
        error: function (msg) {
            alert(msg.responseText + "aww");

        }

    });

}
function CheckTableForTime() {
    var e = document.getElementById('classchoicebytime');//get choice
    var ins = e.options[e.selectedIndex].text;
    var mySplitResult = ins.split(" ");
    var course = mySplitResult[0].toString();

    for (i = 0; i < 7; i++) {
        if (course.charAt(3).toString() == "M" && $('#mon1').is(':empty') && $('#mon2').is(':empty') && $('#mon3').is(':empty')) {
            AddCourseByTime();
        }
        else if (course.charAt(3).toString() == "T" && $('#tue1').is(':empty') && $('#tue2').is(':empty') && $('#tue3').is(':empty')) {
            AddCourseByTime();
        }
        else if ( course.charAt(3).toString() == "W" && $('#wed1').is(':empty') && $('#wed2').is(':empty') && $('#wed3').is(':empty')) {
            AddCourseByTime();
        }
        else if (course.charAt(3).toString() == "H" && $('#thu1').is(':empty') && $('#thu2').is(':empty') && $('#thu3').is(':empty')) {
            AddCourseByTime();
        }
        else if (course.charAt(3).toString() == "F" && $('#fri1').is(':empty') && $('#fri2').is(':empty') && $('#fri3').is(':empty')) {
            AddCourseByTime();
        }
        else if (course.charAt(3).toString() == "S" && $('#sat1').is(':empty') && $('#sat2').is(':empty') && $('#sat3').is(':empty')) {
            AddCourseByTime();
        }
        else if (course.charAt(3).toString() == "U" && $('#sun1').is(':empty') && $('#sun2').is(':empty') && $('#sun3').is(':empty')) {
            AddCourseByTime();
        }
        else {
            alert("Conflict Sched!");
            break;
        }
    }
}

function AddCourseByInstructor() {
    var sess = sessionStorage.getItem("ID");

    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/AddCourseToSched",
        data: "{" +
            "\"courseCode\":\"" + choiceschedbyprof.value + "\"," +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.AddCourseToSchedResult;
            alert(result.toString());
            UpdateEnrollSched();

        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}
function CheckTableForInstructor() {
    var e = document.getElementById('choiceschedbyprof');//get choice
    var ins = e.options[e.selectedIndex].text;
    var mySplitResult = ins.split(" ");
    var course = mySplitResult[0].toString();

    for (i = 0; i < 7; i++) {
        if (course.charAt(3).toString() == "M" && $('#mon1').is(':empty') && $('#mon2').is(':empty') && $('#mon3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "T" && $('#tue1').is(':empty') && $('#tue2').is(':empty') && $('#tue3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "W" && $('#wed1').is(':empty') && $('#wed2').is(':empty') && $('#wed3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "H" && $('#thu1').is(':empty') && $('#thu2').is(':empty') && $('#thu3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "F" && $('#fri1').is(':empty') && $('#fri2').is(':empty') && $('#fri3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "S" && $('#sat1').is(':empty') && $('#sat2').is(':empty') && $('#sat3').is(':empty')) {
            AddCourseByInstructor();
        }
        else if (course.charAt(3).toString() == "U" && $('#sun1').is(':empty') && $('#sun2').is(':empty') && $('#sun3').is(':empty')) {
            AddCourseByInstructor();
        }
        else {
            alert("Conflict Sched!");
            break;
        }
    }
}

function ViewCourseDetailsTime() {
    var course = classchoicebytime.value.toString().split(" ");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseDescriptionAndPrice",
        data: "{" +
           "\"courseCode\":\"" + course[0].toString() + "\"" +
           "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {

            var myString = data.ShowCourseDescriptionAndPriceResult.toString();
            var mySplitResult = myString.split(",");

            lblDescription.value = mySplitResult[0].toString();
            lblPrice.value = "PRICE: " + mySplitResult[1].toString();

            },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}
function ViewCourseDetailsInstructors() {
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ShowCourseDescriptionAndPrice",
        data: "{" +
           "\"courseCode\":\"" + choiceschedbyprof.value + "\"" +
           "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var myString = data.ShowCourseDescriptionAndPriceResult.toString();
            var mySplitResult = myString.split(",");

            lblDescription.value = mySplitResult[0].toString();
            lblPrice.value = "PRICE: " + mySplitResult[1].toString();
        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}

function ComputeDiscounted() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ComputeDiscounted",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.ComputeDiscountedResult.toString();
            lblGrand.value = result.toString();
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}
function CheckIfDiscounted() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/CheckIfDiscounted",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.CheckIfDiscountedResult.toString();
            lblDiscount.value = result.toString();
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}
function ComputeTotal() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ComputeTotal",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.ComputeTotalResult.toString();
            lblTotal.value = result.toString();
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}
function GetCourses() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/BindEnrollSched",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var courses = [];
            var result = data.BindEnrollSchedResult.toString();

            var mySplitResult = result.split(" ");
            for (i = 0; i < mySplitResult.length; i++) {
                courses[i] = mySplitResult[i];
            }
            courses.remove("--");
            lblCourses.value = courses.toString();
            ComputeTotal();
            CheckIfDiscounted();
            ComputeDiscounted();
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function PaymentMode(mode) {
    var sess = sessionStorage.getItem("ID");
    //alert(sess.toString());

    if (mode == "Gym")
    {      
        document.getElementById("lblMode").style.visibility = "visible";
        document.getElementById("lblCredit").style.visibility = "hidden";
        document.getElementById("CreditCard").style.visibility = "hidden";
        document.getElementById("btnConfirmPayment").style.visibility = "hidden";
        
        $.ajax({
            type: "POST",
            url: "http://localhost/Tagurooo/Service.svc/UpdateInventoryGym",
            data: "{" +
                "\"custID\":\"" + sess.toString() + "\"," +
                "\"amount\":\"" + lblGrand.value.toString() + "\"" +
                "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            async: false,
            beforeSend: function (xhr) {
                xhr.withCredentials = true;
                xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
            },
            success: function (data) {
                var result = data.UpdateInventoryGymResult.toString();
                alert("Enrollment Sent! Please pay at our gym.");
            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });

    }
    else if (mode == "Credit")
    {
        document.getElementById("lblMode").style.visibility = "hidden";
        document.getElementById("lblCredit").style.visibility = "visible";
        document.getElementById("CreditCard").style.visibility = "visible";
        document.getElementById("btnConfirmPayment").style.visibility = "visible";

    }
    
}
function FinalizePayment() {
    var sess = sessionStorage.getItem("ID");
    //alert(sess.toString());
    //alert(lblGrand.value.toString());
   
    //alert(CreditCard.value.toString());
        $.ajax({
            type: "POST",
            url: "http://localhost/Tagurooo/Service.svc/UpdateInventoryCredit",
            data: "{" +
                "\"custID\":\"" + sess.toString() + "\"," +
                "\"amount\":\"" + lblGrand.value.toString() + "\"," +
                "\"credit\":\"" + CreditCard.value.toString() + "\"" +
                "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            async: false,
            beforeSend: function (xhr) {
                xhr.withCredentials = true;
                xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
            },
            success: function (data) {
                var result = data.UpdateInventoryCreditResult.toString();
                alert(result.toString());
                alert("Enrollment Sent!");
            },
            error: function (msg) {
                alert(msg.responseText + "aaww");
            }

        });
    }

function ViewProfile() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ViewCustomerProfile",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.ViewCustomerProfileResult;
            var day = [];

            var myString =result[4].toString();
            var mySplitResult = myString.split("/");

            for (i = 0; i < mySplitResult.length; i++) {
                day[i] = mySplitResult[i];
            }

            mySplitResult = day[2].toString().split(" "); 

            FirstNameProfile.value = result[0].toString();
            MiddleNameProfile.value = result[1].toString();
            LastNameProfile.value = result[2].toString();
            EmailProfile.value = result[3].toString();
            MonthProfile.value = day[1].toString();
            DayProfile.value = day[0].toString();
            YearProfile.value = mySplitResult[0].toString();

        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function ViewPayment() {
    var sess = sessionStorage.getItem("ID");
    var paid;
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/ViewInventory",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.ViewInventoryResult;

            if (result.toString() == "You are not yet paid!") {
                alert(result.toString());
                location.href = "Main.html";
            }
            else {

                if (result[4].toString() == "False") {
                    paid = "Not yet Confirmed."
                }
                else { paid = "Payment Confirmed." };
                lblSalesIDPayment.value = result[0].toString();
                lblAmountPayment.value = result[1].toString();
                lblModePayment.value = result[2].toString();
                lblCreditPayment.value = result[3].toString();
                lblConfirmed.value = paid.toString();
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function GetQuizQuestions() {
    $.ajax({
        type: "GET",
        data: "",
        url: "http://localhost/Tagurooo/Service.svc/GetQuizQuestions",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var question = [];
            var answer = [];
            var myString = data.GetQuizQuestionsResult.toString();
            var mySplitResult = myString.split(",");

            //alert(mySplitResult.toString());

            for (i = 0; i < mySplitResult.length; i++) {
                var SplitedString = mySplitResult[i].toString().split("|");
                question[i] = SplitedString[1];
                answer[i] = SplitedString[0];
            }
            //alert(question[8].toString());
            //alert(answer.toString());
            lblQuestion1.value = question[0].toString();
            lblQuestion2.value = question[1].toString();
            lblQuestion3.value = question[2].toString();
            lblQuestion4.value = question[3].toString();
            lblQuestion5.value = question[4].toString();
            lblQuestion6.value = question[5].toString();
            lblQuestion7.value = question[6].toString();
            lblQuestion8.value = question[7].toString();
            lblQuestion9.value = question[8].toString();
            lblQuestion10.value = question[9].toString();
            //var temp = CheckAnswers(answer);
            globalVar = answer;
        },
        error: function (msg) {
            alert(msg.responseText);

        }

    });

}
function CheckAnswers() {
    var checkAnsw = window.globalVar;
    //alert(checkAnsw.toString());
    //alert(txtAnswer1.value.toString() + " " + checkAnsw[0].toString());

    if ((txtAnswer1.value.toString() == checkAnsw[0].toString()) && (txtAnswer2.value.toString() == checkAnsw[1].toString()) && (txtAnswer3.value.toString() == checkAnsw[2].toString()) && (txtAnswer4.value.toString() == checkAnsw[3].toString()) && (txtAnswer5.value.toString() == checkAnsw[4].toString()) && (txtAnswer6.value.toString() == checkAnsw[5].toString()) && (txtAnswer7.value.toString() == checkAnsw[6].toString()) && (txtAnswer8.value.toString() == checkAnsw[7].toString()) && (txtAnswer9.value.toString() == checkAnsw[8].toString()) && (txtAnswer10.value.toString() == checkAnsw[9].toString())) {
        alert("You have availed our 10% discount!");
        var sess = sessionStorage.getItem("ID");
        $.ajax({
            type: "POST",
            url: "http://localhost/Tagurooo/Service.svc/PromoAvailed",
            data: "{" +
                "\"custID\":\"" + sess.toString() + "\"" +
                "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            async: false,
            beforeSend: function (xhr) {
                xhr.withCredentials = true;
                xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
            },
            success: function (data) {
                var result = data.PromoAvailedResult.toString();
                //alert(result.toString());
                
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });

    }
             
    else {
        alert("Sorry! Try again next time!");
    }
}

function GetRandomFeedback() {
    $.ajax({
        type: "GET",
        data: "",
        url: "http://localhost/Tagurooo/Service.svc/GetRandomFeedback",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var feedback = [];
            var myString = data.GetRandomFeedbackResult.toString();
            var mySplitResult = myString.split(",");
            //alert(myString.toString());

            for (i = 0; i < mySplitResult.length; i++) {
                feedback[i] = mySplitResult[i];
            }
            //alert(feedback.toString());
            lblFeedack1.value = feedback[0].toString();
            lblFeedack2.value = feedback[1].toString();
            lblFeedack3.value = feedback[2].toString();
        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}
function SendFeedback() {
    var sess = sessionStorage.getItem("ID");
    var feedback = txtFeedback.value.toString();

    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/SubmitFeedback",
        data: "{" +
            "\"feedback\":\"" + feedback + "\"," +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back.  The data will come back in JSON format
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var result = data.SubmitFeedbackResult;
            alert("Feedback Sent!");
        },
        error: function (msg) {
            alert(msg.responseText);
        }

    });
}


function CheckSched() {
    var sess = sessionStorage.getItem("ID");
    var temp = window.globalClear;
    //alert(temp.toString());

    if (temp.toString() == "enrolled") {
        $.ajax({
            type: "POST",
            url: "http://localhost/Tagurooo/Service.svc/ClearSchedule",
            data: "{" +
                "\"custID\":\"" + sess.toString() + "\"" +
                "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            async: false,
            beforeSend: function (xhr) {
                xhr.withCredentials = true;
                xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
            },
            success: function (data) {
                var result = data.ClearScheduleResult;
                alert("Schedule cleared!");
                location.href = "Main.html";
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });
    }
    else {
        alert("You are not yet enrolled!");
        location.href = "Main.html";}
}
function ClearSchedule() {
    var sess = sessionStorage.getItem("ID");
    $.ajax({
        type: "POST",
        url: "http://localhost/Tagurooo/Service.svc/BindEnrollSched",
        data: "{" +
            "\"custID\":\"" + sess.toString() + "\"" +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        async: false,
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
            xhr.setRequestHeader("Authorization", "Basic " + btoa("melleth:marcelo"));
        },
        success: function (data) {
            var courses = [];
            var temp = [];
            var temp2 = [];
            var j = 0;
            var k = 0;
            var result = data.BindEnrollSchedResult.toString();
            var mySplitResult = result.split(" ");
            for (i = 0; i < mySplitResult.length; i++) {
                courses[i] = mySplitResult[i];
                if (courses[i].toString() != "--") {
                    temp[j] = "enrolled";
                    j++;
                }
                else {
                   // temp2[k] = "--";
                   // k++;
                }
            }
            if (temp[0].toString() != null)
            {
                globalClear = "enrolled";
            }
            else {
                globalClear = "not enrolled"
            }
            //alert(globalClear.toString());
            CheckSched();
            
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

Array.prototype.remove = function () {
    var args = Array.apply(null, arguments);
    var indices = [];
    for (var i = 0; i < args.length; i++) {
        var arg = args[i];
        var index = this.indexOf(arg);
        while (index > -1) {
            indices.push(index);
            index = this.indexOf(arg, index + 1);
        }
    }
    indices.sort();
    for (var i = 0; i < indices.length; i++) {
        var index = indices[i] - i;
        this.splice(index, 1);
    }
}
