"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/deviceHub").build();

connection.on("ReceiveDeviceUpdates", function (devices) {
    var deviceTableBody = document.getElementById("deviceTableBody");
    deviceTableBody.innerHTML = "";

    devices.forEach(function (device) {
        var row = deviceTableBody.insertRow();
        row.insertCell(0).innerText = device.deviceId;
        row.insertCell(1).innerText = device.intuneStatus;
        row.insertCell(2).innerText = device.azureAdJoinStatus;
        row.insertCell(3).innerText = device.userDetailsVerification;
        row.insertCell(4).innerText = device.onedriveUnlinking;
        row.insertCell(5).innerText = device.outlookProfileRemoval;
        row.insertCell(6).innerText = device.migrationProcess;
        row.insertCell(7).innerText = device.targetedUser;
    });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
