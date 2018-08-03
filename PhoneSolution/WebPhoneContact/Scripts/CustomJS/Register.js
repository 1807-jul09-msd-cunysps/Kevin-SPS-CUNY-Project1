

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

function RevalidateAge() {
    debugger;
    var dob = $("#DoB").val();
    alert(dob);
    var present = new Date();
    alert(present);
    var age = Date.DateDiff("yyyy", dob, present)
    alert(age);
    var dob_element = $("#DoB");
  
    if (age < 15 || age > 110) {
 
        dob_element.removeClass("is-valid");
        dob_element.addClass("is-invalid");
        var dobHelp = $("#dobHelp");
        var content = document.createTextNode("Age not within 15:110 years of age");
        dobHelp.appendChild(content);
    }
    else {
        dob_element.addClass("is-valid");
        dob_element.removeClass("is-invalid");
        


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


//e.preventDefault:     Prevents the submission from being submission
//$("#aboutme").attr("href", "aboutme.html");
