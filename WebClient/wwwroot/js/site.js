// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var myInput = document.getElementById('individual')
var myInput2 = document.getElementById('corporate')

myInput.addEventListener('click', function () {
    $('#staticBackdrop').modal('show')
})
myInput2.addEventListener('click', function () {
    $('#staticBackdrop2').modal('show')
})