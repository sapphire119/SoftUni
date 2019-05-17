function addItem() {
    let $selectMenu = $("#menu");

    let $inputItemText = $("#newItemText");
    let $inputItemValue = $("#newItemValue");

    let $option = $("<option>")
        .text($inputItemText.val())
        .val($inputItemValue.val());

    $selectMenu.append($option);
    $inputItemText.val("");
    $inputItemValue.val("");
}