
function RegisterMessage() {

    $.get("/Auth/Register", function (data) {
        console.log(data);
    });
  
}
