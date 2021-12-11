function showHidePassword() {
    var password = document.getElementById("tb_password");
    if (password.getAttribute("type") == "password")
        password.setAttribute("type", "text");
    else
        password.setAttribute("type", "password");

    var cpassword = document.getElementById("tb_cpassword");
    if (cpassword.getAttribute("type") == "password")
        cpassword.setAttribute("type", "text");
    else
        cpassword.setAttribute("type", "password");
}

function checkConfirmPassword() {
    var pass = document.getElementById("tb_password");
    var cpass = document.getElementById("tb_cpassword");
    var btnRegister = document.getElementById("btn_registerBody");

    if (pass.textContent != cpass.textContent) {
        cpass.setAttribute("style", "border-color: red");
        btnRegister.setAttribute("Enabled", "False");
    } else {

        cpass.setAttribute("style", "border-color: Silver");
        btnRegister.setAttribute("Enabled", "True");
    }
}