function showHidePassword() {
    var element = document.getElementById("tb_password");
    if (element.getAttribute("type") == "password")
        element.setAttribute("type", "text");
    else
        element.setAttribute("type", "password");
}