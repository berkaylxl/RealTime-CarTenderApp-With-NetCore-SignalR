
$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44354/tenderHub", {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets

        })
        .build();



    connection.start().then(function () {
        console.log("connection Start")
    }).catch(function (err) {
        return console.error(err.toString());
    });


});

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
   
//    li.textContent = `${user} says ${message}`;
//});



//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});
