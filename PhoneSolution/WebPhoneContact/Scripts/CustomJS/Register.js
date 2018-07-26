
//bind function welcome() to event
function welcome() {
    var data = document.querySelectorAll("input");
    alert("Welcome" + articles);

}
function checkAdd() {


    var check = document.querySelector("#chkPermanentAddress").value;
    if (check == 'on') {
        //debugger;
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