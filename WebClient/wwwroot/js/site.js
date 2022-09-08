

var myInput = document.getElementById('individual')
var myInput2 = document.getElementById('corporate')

myInput.addEventListener('click', function () {
    $('#staticBackdrop').modal('show')
})
myInput2.addEventListener('click', function () {
    $('#staticBackdrop2').modal('show')
})

function Message(status) {
    if (status == "1")
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Giriş Başarılı, Hoşgeldiniz',
            showConfirmButton: false,
            timer: 1500
        })
}
