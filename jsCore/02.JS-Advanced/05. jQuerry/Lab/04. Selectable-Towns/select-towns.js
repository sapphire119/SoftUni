function attachEvents() {
    $("#items li").on("click", clickEvent);

    $("#showTownsButton").on("click", function (event) {
        let output = $("#items li[data-selected=true]").toArray().map(e => e.textContent).join(", ");
        $("#selectedTowns").append(output);
    });

    function clickEvent(event) {
        let attr = $(this).attr('data-selected');
        if (typeof attr !== typeof undefined && attr !== false) {
            $(this).removeAttr('data-selected');
            $(this).css('background-color', "");
        } else {
            $(this).attr('data-selected', "true");
            $(this).css('background-color', "#DDD");
        }
    }
}