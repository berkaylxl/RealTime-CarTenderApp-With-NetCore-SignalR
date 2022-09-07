
var button = document.getElementById("upPriceBtn")
var priceTextBox = document.getElementById("teklifText")
var bidText = document.getElementById("bidText")
var newBid = ""
var LastBid = 0
let BidsList = []
var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:44354/tenderHub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets

    })
    .build();

function getList(tenderId) {
    connection.start().then(function () {
        console.log("connection Start")
        connection.invoke("SendBidsList", tenderId).catch(function (err) {
            return console.error(err.toString());
        });
    }).catch(function (err) {
        return console.error(err.toString());
    });

}

connection.on("GetBidsList", function (_bidsList) {
    document.querySelector('#myList').innerHTML = ""
    _bidsList.forEach((item) => {
        document.querySelector('#myList').innerHTML
            += `
									   	   <div class="d-flex justify-content-between mt-1">
												<font class="fs-6"> <i class="fa-solid fa-user"></i>${item.userId.substring(0, 7)}***</font>
												<font class="fs-6">${item.bidPrice}₺</font>
											</div>
											`;
    })

});

priceTextBox.addEventListener("change", function () {
    newBid = priceTextBox.value.toString();
})

function sendTenderData(userId, price, tenderId) {
    if (price == "") {
        Swal.fire({
            icon: 'error',
            text: 'Belirli bir tutar giriniz!'
        })
    }
    else if (price < 50||price>50000) {
        Swal.fire({
            icon: 'info',
            text: '50 ₺ - 50.000 ₺ Aralığında bir tutar girmelisiniz!'
        })
    }
    else {
        connection.invoke("UpPrice", userId, price, tenderId).catch(function (err) {
            return console.error(err.toString());
        });

    }



}

connection.on("SendDataJs", function (_lastBidOwner, _lastBidPrice, _bidsList) {

    BidsList = _bidsList;
    bidText.innerHTML = _lastBidPrice + " ₺"
    console.log(_lastBidOwner);
    console.log(_lastBidPrice)
    console.log(_bidsList);
    document.querySelector('#myList').innerHTML = ""
    BidsList.forEach((item) => {
        document.querySelector('#myList').innerHTML
            += `
									   	   <div class="d-flex justify-content-between mt-1">
												<font class="fs-6"> <i class="fa-solid fa-user"></i>${item.userId.substring(0, 7)}***</font>
												<font class="fs-6">${item.bidPrice}₺</font>
											</div>
											`;
    })

});


