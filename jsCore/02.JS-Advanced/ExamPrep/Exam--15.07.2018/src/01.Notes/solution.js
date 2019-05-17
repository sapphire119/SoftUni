function addSticker() {
    let $title = $(".title");
    let $content = $(".content");

    if ($title.val() && $content.val()) {
        createSticker();
        clearFields();
    }

    function createSticker() {
        let $list = $("#sticker-list");
        // <li class="note-content">
        //             <a class="button">x</a>
        //             <h2>TODOs</h2>
        //             <hr>
        //             <p>To watch the finale tonight</p>
        //         </li>
        let $li = $("<li class='note-content'></li>")
            .append($("<a class='button'>x</a>").on("click", function (e) {
                $(e.target).parent().remove();
            }))
            .append($(`<h2>${$title.val()}</h2>`))
            .append($("<hr>"))
            .append($(`<p>${$content.val()}</p>`));
        debugger;

        $list.append($li);
    }

    function clearFields() {
        $title.val("");
        $content.val("");
    }
}