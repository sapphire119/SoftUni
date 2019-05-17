function loadCommits() {
    let usernameVal = $("#username").val();
    let repositoryVal = $("#repo").val();

    let url = `https://api.github.com/repos/${usernameVal}/${repositoryVal}/commits`;

    let $commits = $("#commits");

    function onReposLoadSuccess(args) {
        $commits.empty();
        for (const currentEntry of args) {
            let $li = $("<li>")
                .text(`${currentEntry["commit"]["author"]["name"]}: ${currentEntry["commit"]["message"]}`);

            $commits.append($li);
        }
    }

    $.get({
        url,
        success: onReposLoadSuccess,
        error: (error) => {
            $commits.empty();

            let $li = $("<li>")
                .text(`Error: ${error.status} (${error.statusText})`);

            $commits.append($li);
        }
    })
}