function showSpinnerAndRedirect(url) {

    document.getElementById("loading-spinner").style.display = "block";
    setTimeout(() => {
        window.location.href = url;
    }, 500);
}