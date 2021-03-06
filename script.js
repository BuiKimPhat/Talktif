document.querySelector(".img-btn").addEventListener("click", function() {
    document.querySelector(".cont").classList.toggle("s-signup");
});

function CheckDangNhap(event) {
    var email = document.getElementById("login_email").value;
    var password = document.getElementById("login_password").value;
    var error_email = document.getElementById("error_email");
    var error_password = document.getElementById("error_password");
    event.preventDefault();
    if (email == '') {
        document.getElementById("login_email").style.backgroundColor = "yellow";
        error_email.innerHTML = "Not Invalid Email";
    } else if (email != "") {
        if (email.indexOf("@") == -1) {
            document.getElementById("login_email").style.backgroundColor = "yellow";
            error_email.innerHTML = "Email Error";
        } else if (email.indexOf("@") != -1) {
            document.getElementById("login_email").style.backgroundColor = "#fff";
            error_email.innerHTML = "";
        }
    }
    if (password == '') {
        document.getElementById("login_password").style.backgroundColor = "yellow";
        error_password.innerHTML = "Not Invalid Password";
    } else {
        document.getElementById("login_password").style.backgroundColor = "#fff";
        error_password.innerHTML = "";
    }
}
document.getElementById("login_email").onchange = function() { ChangeEmail() };

function ChangeEmail() {
    var email = document.getElementById("login_email").value;
    if (email != "" && email.indexOf("@") != -1) {
        error_email.innerHTML = "Email Correct";
    }
}
// function ChangeEmail(event) {
//     var email = document.getElementById("login_email").value;
//     event.preventDefault();
//     if (email != "" && email.indexOf("@") != -1) {
//         error_email.innerHTML += "Email Correct";
//     }
// }

function Check_Login() {
    CheckDangNhap(event);
}