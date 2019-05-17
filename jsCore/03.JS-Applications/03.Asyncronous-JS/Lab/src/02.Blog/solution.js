function attachEvents() {
    let username = "guest";
    let password = "guest";

    let baseUrl = `https://baas.kinvey.com/appdata/kid_SJ8AvVrd4/posts`;

    let $posts = $("#posts");

    function userCredentials(jqXHR) {
        jqXHR.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
    }

    let $btnLoadPosts = $("#btnLoadPosts");

    $btnLoadPosts.on("click", (e) => {
        $posts.empty();
        $.get({
            beforeSend: userCredentials,
            url: baseUrl,
            success: (posts) => {
                for (const post of posts) {
                    let $option = $("<option>")
                        .val(post["_id"])
                        .text(post["title"]);

                    $posts.append($option);
                }
            },
            error: (error) => {
                console.error(error.message);
            }
        })
    });

    let $btnViewPost = $("#btnViewPost");

    $btnViewPost.on("click", (e) => {
        let currentPostId = $posts.val();
        let baseCommentsUrl = `https://baas.kinvey.com/appdata/kid_SJ8AvVrd4/comments/?query={"post_id":"${currentPostId}"}`;

        let getPostsPromise = $.get({
            beforeSend: userCredentials,
            url: baseUrl + `/${currentPostId}`
        });

        let getCommentsPromise = $.get({
            beforeSend: userCredentials,
            url: baseCommentsUrl
        });

        Promise.all([getPostsPromise, getCommentsPromise]).then(displayPostInfo);
    });

    function displayPostInfo([postInfo, comments]) {
        $('#post-title').text(postInfo.title);
        $('#post-body').text(postInfo.body);

        let $postComments = $('#post-comments');
        $postComments.empty();

        for (let comment of comments) {
            $postComments.append($('<li>').text(comment.text));
        }
    }
}
//
// function attachEvents2() {
//     // Закоментирах този ред и затварящите, защото в judge не трябва и гърми с тях
//     // $(document).ready(function () {
//     // Махнах наклонената черта от url-ла на постовете защото когато искаш да вземеш всички не трябва и гърми
//     let postsUrl = 'https://baas.kinvey.com/appdata/kid_BkyzcBAbe/posts';
//     let commentsUrl = 'https://baas.kinvey.com/appdata/kid_BkyzcBAbe/comments/';
//     let auth = {'Authorization': 'Basic ' + btoa('peter:p')};
//
//     $('#btnLoadPosts').click(function () {
//         $.get({url: postsUrl, headers: auth}).then(displayPosts).catch(displayError);
//     });
//
//     $('#btnViewPost').click(function () {
//         let selectedPostId = $('#posts').val();
//         if (!selectedPostId) return;
//
//         // Тук добавих наклонената черта, защото трябва, когато се избира определен пост
//         let postsRequest = $.get({url: postsUrl + `/${selectedPostId}`, headers: auth});
//         let commentsRequest =  $.get({url: commentsUrl + `?query={"post_id":"${selectedPostId}"}`, headers: auth});
//
//         Promise.all([postsRequest, commentsRequest]).then(displayPostInfo).catch(displayError);
//     });
//
//     function displayPosts(posts) {
//         $('#posts').empty();
//
//         for (let post of posts) {
//             $('#posts').append($('<option>').text(post.title).val(post._id));
//         }
//     }
//
//     function displayPostInfo([postInfo, comments]) {
//         $('#post-title').text(postInfo.title);
//         $('#post-body').text(postInfo.body);
//
//         $('#post-comments').empty();
//
//         for (let comment of comments) {
//             $('#post-comments').append($('<li>').text(comment.text));
//         }
//     }
//
//     function displayError(error) {
//         let errorDiv = $('<div>').text(`Error: ${error.status} (${error.statusText})`);
//         $(document.body).prepend(errorDiv);
//
//         setTimeout(() => errorDiv.fadeOut(() => errorDiv.remove()), 3000);
//     }
//     // });
// }