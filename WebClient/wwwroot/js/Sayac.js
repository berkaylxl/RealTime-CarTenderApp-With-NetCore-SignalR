
function geriSayim(date, id) {
    console.log("date= " + date)

    var countDownDate = new Date(date).getTime();

    console.log("countDown= "+countDownDate)
    var div = document.getElementById(id).children
    if (countDownDate) { 
        var x = setInterval(function () { 
            var now = new Date().getTime(); 

            console.log("now= "+now)
            var distance = countDownDate - now; 
            if (distance < 0) { 
                clearInterval(x); 
            }
            else {   
                var days = Math.floor(distance / (1000 * 60 * 60*24 )),
                    hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))+days*24,
                    minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60)),
                    seconds = Math.floor((distance % (1000 * 60)) / 1000);
                div[1].innerHTML = hours +" SA"
                div[2].innerHTML = minutes + " DK"
                div[3].innerHTML = seconds + " SN"
                
            }
        }, 1000); //1 saniyede bir sayaç güncellenecek
    }
}
