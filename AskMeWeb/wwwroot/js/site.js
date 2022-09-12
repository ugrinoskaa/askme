// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function search(term) {
    let val = document.getElementById('search-input').value;
    window.location.href = '/Question?q=' + val;

}