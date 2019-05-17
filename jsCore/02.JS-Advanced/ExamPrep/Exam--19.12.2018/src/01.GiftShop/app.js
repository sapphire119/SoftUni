function solution() {
    let $button = $("button");
    let $shop = $("#christmasGiftShop");

    $button.on('click', clickEvent);

    function clickEvent(e) {
        debugger;
        let $shop = $("#christmasGiftShop");
        let $toyType = $("#toyType");

        let $toyPrice = $("#toyPrice");

        let $toyDescription = $("#toyDescription");

        let toyTypeValue = $toyType.val();
        let toyDescriptionVal = $toyDescription.val();
        let toyPriceVal = $toyPrice.val();
        // let test = isNaN(toyPriceVal);
        // debugger;

        if (toyTypeValue !== "" &&
            !isNaN(toyPriceVal) &&
            toyDescriptionVal !== "" && toyDescriptionVal.length >= 50) {

        let $div = $("<div class='gift'></div>");
        $div.append($("<img src='gift.png'>"));

        let $h2 = $("<h2>");
        $h2.text(toyTypeValue);
        // $div.append($(`<h2>${}</h2>`))
        let $p = $("<p>");
        $p.text(toyDescriptionVal);

        let $button = $("<button>");
        $button.text(`Buy it for \\$${toyPriceVal}`);
        $button.on("click", (e) => $(e.target).parent().remove())

        $shop.append($div);
        }
    }
}