document.querySelector(".img-btn").addEventListener("click", function() {
    document.querySelector(".cont").classList.toggle("s-signup");
});

function CheckEmail(event) {
    var email = document.getElementById("login_email").value;
    var error_email = document.getElementById("error_email");
    event.preventDefault();
    if (email == '') {
        document.getElementById("login_email").style.borderColor = "red";
        //  document.getElementById("login_email").style.backgroundColor = "yellow";
        error_email.innerHTML = "Not Invalid Email";
    } else {
        if (email.slice(-10) !== ("@gmail" + "." + "com")) {
            document.getElementById("login_email").style.borderColor = "red";
            //    document.getElementById("login_email").style.backgroundColor = "yellow";
            error_email.innerHTML = "Email Error";
        } else {
            document.getElementById("login_email").style.borderColor = "#2ecc71";
            document.getElementById("login_email").style.backgroundColor = "#fff";
            error_email.innerHTML = "";
        }
    }
}

function CheckPassword(event) {
    event.preventDefault();
    var password = document.getElementById("login_password").value;
    var error_password = document.getElementById("error_password");
    if (password == '') {
        document.getElementById("login_password").style.borderColor = "red";
        //   document.getElementById("login_password").style.backgroundColor = "yellow";
        error_password.innerHTML = "Not Invalid Password";
    } else {
        document.getElementById("login_password").style.borderColor = "#2ecc71";
        document.getElementById("login_password").style.backgroundColor = "#fff";
        error_password.innerHTML = "";
    }
}

// Function Sign-In

function CheckName(event) {
    event.preventDefault();
    var name = document.getElementById("name").value;
    var error_name = document.getElementById("error_name");
    if (name == "") {
        error_name.innerHTML = "Name is not empty";
        //   document.getElementById("name").style.backgroundColor = "yellow";
        document.getElementById("name").style.borderColor = "red";
    } else {
        document.getElementById("name").style.backgroundColor = "#fff";
        document.getElementById("name").style.borderColor = "#2ecc71";
        error_name.innerHTML = "";
    }
}

function CheckEmail_SignUp(event) {
    var email = document.getElementById("email").value;
    var error_email = document.getElementById("error_email_sign_up");
    if (email == "") {
        error_email.innerHTML = "Email is not empty";
        //   document.getElementById("email").style.backgroundColor = "yellow";
        document.getElementById("email").style.borderColor = "red";
    } else {
        if (email.slice(-10) !== ("@gmail" + "." + "com")) {
            error_email.innerHTML = "Email not correct";
            //       document.getElementById("email").style.backgroundColor = "yellow";
            document.getElementById("email").style.borderColor = "red";
        } else {
            document.getElementById("email").style.backgroundColor = "#fff";
            document.getElementById("email").style.borderColor = "#2ecc71";
            error_email.innerHTML = "";
        }
    }

}

function CheckPassword_SignUp(event) {
    var password = document.getElementById("password").value;
    var error_password = document.getElementById("error_password_sign_up");
    if (password == "") {
        error_password.innerHTML = "Password is not empty";
        //   document.getElementById("password").style.backgroundColor = "yellow";
        document.getElementById("password").style.borderColor = "red";
    } else {
        document.getElementById("password").style.backgroundColor = "#fff";
        document.getElementById("password").style.borderColor = "#2ecc71";
        error_password.innerHTML = "";
    }
}

function CheckConfirmPassword(event) {
    var password = document.getElementById("password").value;
    event.preventDefault();
    var confirm_password = document.getElementById("confirm_password").value;
    var error_confirm_password = document.getElementById("error_confirm_password");
    if (confirm_password == "") {
        error_confirm_password.innerHTML = "Confirm Password is not empty";
        //    document.getElementById("confirm_password").style.backgroundColor = "yellow";
        document.getElementById("confirm_password").style.borderColor = "red";
    } else {
        if (password != confirm_password) {
            error_confirm_password.innerHTML = "Confirm Password is not correct";
            //       document.getElementById("confirm_password").style.backgroundColor = "yellow";
            document.getElementById("confirm_password").style.borderColor = "red";
        } else {
            document.getElementById("confirm_password").style.backgroundColor = "#fff";
            document.getElementById("confirm_password").style.borderColor = "#2ecc71";
            error_confirm_password.innerHTML = "";
        }
    }
}

function Sign_In() {
    var email_value = document.getElementById("login_email").value;
    var password_value = document.getElementById("login_password").value;
    if (email_value.slice(-10) === ("@gmail" + "." + "com") && password_value != "") {
        location.assign("http://127.0.0.1:5500/DesignUI/Home/main.html");
    }
}

function Sign_Up() {
    var error_name = $("#error_name");
    var error_password = $("#error_password_sign_up");
    var error_email = $("#error_email_sign_up");
    var error_confirm_password = $("#error_confirm_password");
    if (error_name.html() == "" && error_email.html() == "" && error_password.html() == "" && error_confirm_password.html() == "") {
        $("#Confirm1").show();
        $("#Confirm2").hide();
    } else {
        $("#Confirm2").show();
        $("#Confirm1").hide();
    }

}