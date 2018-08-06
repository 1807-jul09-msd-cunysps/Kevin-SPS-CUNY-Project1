function validate() {
    var fName = $("firstName");
    var lName = $("lastName");
    var dob = $("Dob");
    var gender = $("input[name=gender]:checked").val();
    var address1 = $("address1");
    var state = $("State");
    var city = $("City");   
    var zipcode = $("ZipCode");
    var country = $("country")




}

function welcome() {
    var data = document.querySelectorAll("input");
    alert("Welcome" + articles);

}
function checkAdd() {


    var check = document.querySelector("#chkPermanentAddress").value;
    if (check == 'on') {
        //debugger;
        //checks if 'div layer called "divPermAddress" exists on the document
        if (!document.getElementById("divPermAddress")) {

            var permAddress = document.querySelector("#PermanentAddress");

            var divPermAddress = document.createElement("div");
            divPermAddress.id = "divPermAddress";



            var h3 = document.createElement("h3");
            h3.id = "permAddressh3";
            h3.innerText = "Permanent Address";
            divPermAddress.appendChild(h3);


            var originalAddress = document.getElementById("CurrentAddress");
            var clnAddress = originalAddress.cloneNode(true);
            divPermAddress.appendChild(clnAddress);


            permAddress.appendChild(divPermAddress);

        }
    }
   

}

function RevalidateAge() {
    debugger;
    var dob = $("#DoB").val();
    var present = new Date();
    var age = Date.DateDiff("yyyy", dob, present)
    var dob_element = $("#DoB");
  
    if (age < 15 || age > 110) {
 
        dob_element.removeClass("is-valid");
        dob_element.addClass("is-invalid");
        var dobHelp = $("#dobHelp");
        var content = document.createTextNode("Age not within 15:110 years of age");
          dobHelp.innerHTML = "Age not within 15: 110 years of age";
         }
     else {
        dob_element.addClass("is-valid");
        dob_element.removeClass("is-invalid");
        dobHelp.innerHTML = '';


    }

}
function checkZipcode() {
    debugger;
    var zipcode = document.getElementById("ZipCode").value;
    var clientKey = "js-jqtP0V5Muaay0aUDnqFKsN0VKAzmcDA90qziZngGVPqeUNQRCusYGgHXN2ZdJjCS";
    var url = "https://www.zipcodeapi.com/rest/" + clientKey + "/info.json/" + zipcode + "/radians";
    var xhr = new XMLHttpRequest();
   xhr.open('GET', url);

    xhr.onreadystatechange = function () {    //Call a function when the state changes.
        if (this.readyState == XMLHttpRequest.DONE && this.status == 200) {
            var result = xhr.responseText;
            if (result !== null || result !== "" || result !== undefined) {
                if (result.charAt(0) === '"' && result.charAt(result.length - 1) === '"') {
                    result = result.substr(1, result.length - 2);
                }
                debugger;
                zipCodeAPItoLocation(result);
            }

        }
        }
    xhr.send();
}

function zipCodeAPItoLocation(json) {
    debugger;
    var location = JSON.parse(json);
    var city = document.getElementById("City");
    var state = document.getElementById("State");

    console.log(location.city + " " + location.state);
    city.value = location.city;
    state.value= location.state;
}


function validFirstName() {
    var fName = document.forms["ContactForm"]["firstName"];
    fName.required = true;
    var fNameHelper = $("#fNameHelper")
    if (fName.value == "") {
        var p = document.createElement("p");
        p.id = "fNameHelperP";
        p.innerText = "Please enter a first name";
        if (fNameHelper.hasChildNodes()) {
            console.log('fNameHelper.hasNodes()');
            fNameHelper.replaceChild(p);
        }
        else {
            console.log('fNameHelper.appendChild');

            fNameHelper.appendChild(p);
        }
        return false;
    }
    else {
        if (fNameHelper.hasChildNodes()) {
            fNameHelper.RemoveChild(fNameHelper.firstChild());
        }
        
    }
    return true;
}

function validLastName() {
    var lName = document.forms["ContactForm"]["lastName"];
    lName.required = true;
    if (lName.value == "") {
        alert("Enter a last name");
        return false;
    }
    return true;
}
//e.preventDefault:     Prevents the submission from being submission
//$("#aboutme").attr("href", "aboutme.html");

function Address_Street(Address) {
    var addStr = "";
    Address.split(" ");

    for (var i in Address) {
        var charArray = Address.split("");
        if (isNaN(i)){
            break;
        }
        else
    }

}
$("form").submit(function ({

   

    $.ajax({
        type: "POST",
        url: "",
        dataType: "json",
        data: {
            FirstName: $("#firstName").val(),
            LastName: $("#lastName").val(),
            Gender: $("#Gender").val(),
            DoB: $("#DoB").val(),
            Address: {
                StreetName: $("Address1")

            }
        }

    })
}));