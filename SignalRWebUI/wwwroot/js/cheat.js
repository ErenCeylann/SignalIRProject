﻿var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7112/SignalRHub").build();
document.getElementById("sendButton").disabled = true;

connection.on("ReceiverMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.appendChild(document.createTextNode(` ${message} - ${currentHour}:${currentMinute}`));

    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
});

