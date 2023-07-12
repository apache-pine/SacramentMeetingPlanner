// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var textInputs = document.querySelectorAll('input[type="text"]');
textInputs.forEach(function (input) {
    input.addEventListener('click', function () {
        this.select(); // Automatically select the text inside the input field
    });
});