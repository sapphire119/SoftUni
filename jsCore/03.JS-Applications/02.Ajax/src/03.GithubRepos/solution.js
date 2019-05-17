function loadRepos() {
    let id = $("#username").val();
    let url = `https://api.github.com/users/${id}/repos`;

    let $repos = $("#repos");

    $.ajax({
        method: "GET",
        url,
        success: onLoadReposSuccess,
        error: onLoadReposError
    });

    function onLoadReposSuccess(repos) {
        $repos.empty();
        for (let repo of repos) {
            let $li = $("<li>")
                .append(
                    $("<a>")
                        .attr("href", repo["html_url"])
                        .text(repo["full_name"]));

            $repos.append($li);
        }
    }

    function onLoadReposError(err) {
        debugger;
        $repos.empty();
        let $li = $("<li>");
        $li.text("Error");

        $repos.append($li);
    }
}