$("#aboutme").attr("href", "aboutme.html");

function validate() {

        if ($("#age").val() < 15 || $("#age").val() > 120) {
            $("#age").attr(border: 2px solid red);
        }
        else {
            $("#age").attr("");
        }
    }()


}