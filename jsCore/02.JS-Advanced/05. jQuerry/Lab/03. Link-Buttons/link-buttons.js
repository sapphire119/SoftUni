function attachEvents() {
    debugger;
    $('a.button').on('click', clickEvent);

    function clickEvent(event) {
        $("a.button").removeClass("selected");
        $(this).addClass("selected")
    }
}