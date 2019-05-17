function focus() {
    $("input")
        .on('focus', function(e) {
            let $currentButton = $(e.target);
            let $parent = $currentButton.parent();
            $parent.addClass('focused');
        })
        .on('blur', function (e) {
            let $currentButton = $(e.target);
            let $parent = $currentButton.parent();
            $parent.removeClass('focused');
        })
}