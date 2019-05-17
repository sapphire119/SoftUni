function acceptance() {
    let $warehouse = $("#warehouse");

    let $shippingCompany = $("[name='shippingCompany']");
    let $productName = $("[name='productName']");
    let $productQuantity = $("[name='productQuantity']");
    let $productScrape = $("[name='productScrape']");

    if ($shippingCompany.val() && $productName.val() &&
        $productQuantity.val() && $productScrape.val() &&
        !isNaN($productQuantity.val()) && !isNaN($productScrape.val())) {
        let quantityToAdd = Number($productQuantity.val()) - Number($productScrape.val());
        if (quantityToAdd > 0) {
            let $div = $("<div>")
                .append($(`<p>[${$shippingCompany.val()}] ${$productName.val()} - ${quantityToAdd} pieces</p>`))
                .append(
                    $("<button type='button'>")
                        .text("Out of stock")
                        .on("click", (e) => $(e.target).parent().remove()));

            $warehouse.append($div);
        }

        resetFields();
    }

    function resetFields() {
        $shippingCompany.val("");
        $productName.val("");
        $productQuantity.val("");
        $productScrape.val("");
    }
}