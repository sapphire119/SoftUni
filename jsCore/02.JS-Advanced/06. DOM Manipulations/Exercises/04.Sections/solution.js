function create(sentences) { //Array of strings
    let $divContent = $("#content");
    for (const sentence of sentences) {
        let $divForEle = $("<div>");
        let $p = $("<p>")
            .text(sentence)
            .hide();

        $divForEle.on('click', function (e) {
            let $p = $(e.target.firstChild);
            $p.css('display', 'block');
        });
        $divForEle.append($p);
        $divContent.append($divForEle);
    }
}