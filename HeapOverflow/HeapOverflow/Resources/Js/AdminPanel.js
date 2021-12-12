function showHideFilter() {
    var filter = document.getElementById("filter");
    if (filter.classList.contains("hide"))
        filter.classList.remove("hide");
    else
        filter.classList.add("hide");
}