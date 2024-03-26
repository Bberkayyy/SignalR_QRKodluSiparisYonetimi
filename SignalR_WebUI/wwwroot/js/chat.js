
var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:20666/signalrhub").build();
document.getElementById("sendButton").disabled = true;

connection.on("receiveMessage", (user, message) => {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    currentHour = (currentHour < 10 ? "0" : "") + currentHour;
    currentMinute = (currentMinute < 10 ? "0" : "") + currentMinute;

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` : ${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(() => {
    document.getElementById("sendButton").disabled = false;

}).catch((err) => {
    return console.log(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch((err) => {
        return console.log(err.toString());
    });
    event.preventDefault();
});