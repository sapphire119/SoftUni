function loadRepos() {
    let request = new XMLHttpRequest();
    let method = "GET";
    let url = "https://api.github.com/users/testnakov/repos";

    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200){
            document.getElementById("res").textContent =
                this.responseText;
        }
    };

    request.open(method, url, true);

    request.send();
}