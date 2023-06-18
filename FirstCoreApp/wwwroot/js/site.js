// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var url = window.location.href;
function addProductClick() {

    //$.ajax({
    //    url: 'AddProduct/Index',
    //}).done(function () {
    //    //alert('Added');
    //});

    console.log('clicked');
    window.location.href = location.protocol + '//' + location.host + "/AddProduct/Index";  
}


function saveButtonClicked() {
    console.log('saved!');
    var productName = document.getElementById("txtProductName").value;
    var productPrice = document.getElementById("txtProductPrice").value;
    var productDesc = document.getElementById("txtProductDesc").value;

    window.location.href = location.protocol + '//' + location.host + "/AddProduct/Save?productName=" + productName
        + "&productPrice=" + productPrice + "&productDesc=" + productDesc; 

}

function updateButtonClicked() {
    console.log('updated!');
    var productName = document.getElementById("txtProductName").value;
    var productPrice = document.getElementById("txtProductPrice").value;
    var productDesc = document.getElementById("txtProductDesc").value;
    var SN = document.getElementById("txtProductSN").value;

    window.location.href = location.protocol + '//' + location.host + "/UpdateProduct/Update?id=" + SN + "&productName=" + productName
        + "&productPrice=" + productPrice + "&productDesc=" + productDesc;

}

function deleteButtonClicked(id) {
    window.location.href = location.protocol + '//' + location.host + "/Product/Delete?id=" + id;
} 

function editButtonClicked(id) {
    window.location.href = location.protocol + '//' + location.host + "/UpdateProduct/Index?id=" + id;
}