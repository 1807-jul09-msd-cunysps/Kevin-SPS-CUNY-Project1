$(document).ready(function() { alert('Register.js works'); } ());
//bind function welcome() to event
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
    else {

    }

}
function validateAge() {
    alert('inside validateAge()');
    var age = $("#age").val();
    if (age < 15 || age > 110) {
        $("#ageGroup").addClass("form-group has-warning");
    }

}

function checkContactForm(e) {
    //Need to validate form before submission
    debugger;
    var mail = document.getElementById("mail").value;
    var name = document.getElementById("name").value;
    var msg = document.getElementById("msg").value;
    var error = document.getElementById("error").value;

}
$(document).on('blur', '#age', validateAge());


//e.preventDefault:     Prevents the submission from being submission
//$("#aboutme").attr("href", "aboutme.html");
