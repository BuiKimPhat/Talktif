("use strict");
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
<<<<<<< HEAD
var userCnnID;
=======
var userID;
>>>>>>> Chuong

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
  var msg = message
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
  // var encodedMsg = user + " says " + msg;
  var span = document.createElement("span");
  span.className =
<<<<<<< HEAD
    user != userCnnID
=======
    user != userID
>>>>>>> Chuong
      ? "msgtext p-2 mr-auto mb-1"
      : "msgtext-self p-2 ml-auto mb-1";
  span.textContent = msg;
  var div = document.createElement("div");
  div.className = "row w-100 m-0";
  div.appendChild(span);
  document.getElementById("chatMessages").appendChild(div);
<<<<<<< HEAD
  if (user != userCnnID) {
    var messAudio = new Audio('message.mp3');
    messAudio.play();  
  }
  document.getElementById("chatMessages").scrollTo(0,document.getElementById("chatMessages").scrollHeight);
=======
>>>>>>> Chuong
});

connection.on("BroadcastMessage", function (message) {
  var msg = message
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
  var encodedMsg = msg;
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  document.getElementById("chatMessages").appendChild(li);
<<<<<<< HEAD
  document.getElementById("chatMessages").scrollTo(0,document.getElementById("chatMessages").scrollHeight);
=======
>>>>>>> Chuong
});

connection
  .start()
  .then(function () {
<<<<<<< HEAD
    if (!userCnnID) userCnnID = connection.connectionId;
    document.getElementById("sendButton").disabled = false;
    connection.invoke("AddToQueue", userID, username, null).catch((err) => {
=======
    if (!userID) userID = connection.connectionId;
    document.getElementById("sendButton").disabled = false;
    connection.invoke("AddToQueue").catch((err) => {
>>>>>>> Chuong
      return console.error(err.toString());
    });
  })
  .catch(function (err) {
    return console.error(err.toString());
  });

window.onbeforeunload = function () {
<<<<<<< HEAD
  connection.invoke("LeaveChat", userID, username).catch((err) => {
=======
  connection.invoke("LeaveChat").catch((err) => {
>>>>>>> Chuong
    return console.error(err.toString());
  });
};

document
  .getElementsByTagName("form")[0]
  .addEventListener("submit", function (event) {
    event.preventDefault();
    var message = document.getElementById("messageInput").value;
    document.getElementById("messageInput").value = "";
    connection.invoke("SendMessage", message).catch(function (err) {
      return console.error(err.toString());
    });
  });

<<<<<<< HEAD
if (userID) {
  document
    .getElementById("addFriendButton")
    .addEventListener("click", function (event) {
      event.preventDefault();
      connection.invoke("AddFriend", token).catch((err) => {
        return console.error(err.toString());
      });
    });

  document
    .getElementById("saveFilter")
    .addEventListener("click", function (event) {
      event.preventDefault();
      var filterString = "";
      var filterInputs = document.getElementsByClassName("filter-option");
      if (filterInputs[0].checked) filterString += (filterString == "" ? "" : ",") + userHobbies;
      if (filterInputs[1].checked) filterString += (filterString == "" ? "" : ",") + userAddress;
      if (filterInputs[2].checked) filterString += (filterString == "" ? "" : ",") + (userGender ? "female" : "male");
      connection.invoke("SaveFilter", userID, username, filterString).catch((err) => {
        return console.error(err.toString());
      });
    });
}

=======
>>>>>>> Chuong
document
  .getElementById("skipButton")
  .addEventListener("click", function (event) {
    event.preventDefault();
<<<<<<< HEAD
    connection.invoke("SkipChat", userID, username).catch((err) => {
=======
    connection.invoke("SkipChat").catch((err) => {
>>>>>>> Chuong
      return console.error(err.toString());
    });
  });