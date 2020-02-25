"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var resultReturned;
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});


connection.start().then(async function () {
    connection.invoke("GetHistory").then(result => populateHistory(result)).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

function populateHistory(messageHistory) {
    for (var message of messageHistory) {
        var li = document.createElement("li");
        li.textContent = message.userName + ": " + message.messageText;
        document.getElementById("messagesList").appendChild(li);
    }
}

document.getElementById("sendButton").addEventListener("click", function (event) {
    resultReturned
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});