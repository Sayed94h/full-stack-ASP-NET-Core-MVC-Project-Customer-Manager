// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const customAlert = document.querySelector(".custom-alert");
let activeId, token;
function deleteItem(event) {

    activeId = event.target.getAttribute("id")
    token = event.target.getAttribute("data_token")

    // display the customer alert
    customAlert.classList.remove("hidden")
}

function positiveAlert() {
    fetch("Customer/Delete/" + activeId, {
        method: "delete",
        headers: {
            RequestVerificationToken: token
        }
    }).then(response => response)
        .then(val => {
            console.log(val)
            window.document.location.reload()
        })
        .catch(er => console.log(er))
}

function negativeAlert() {
    // hide custom alert
    customAlert.classList.add("hidden")
}