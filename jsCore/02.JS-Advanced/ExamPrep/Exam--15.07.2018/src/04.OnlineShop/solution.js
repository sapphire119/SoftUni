function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);

    let $button = $("#submit");
    let $inputName = $(".custom-select");
    let $inputPrice = $("#price");
    let $inputQuantity = $("#quantity");

    let $list = $(".display");
    let $capacity = $("#capacity");

    $inputName.on("input", inputEvent);

    $button.on("click", clickEvent);

    function clickEvent(e) {
        let $li = $("<li>")
            .text(`Product: ${$inputName.val()} Price: ${$inputPrice.val()} Quantity: ${$inputQuantity.val()}`);

        $list.append($li);

        calcSum();

        let currentCapacityVal = Number($capacity.val());
        let newCapacity = currentCapacityVal + Number($inputQuantity.val());

        if (newCapacity < 150) {
            $capacity.val(newCapacity);
        } else {
            disableSetFields();
        }

        resetToInitialState();
    }

    function calcSum() {
        let $sum = $("#sum");
        $sum.val((_, e) => Number(e) + Number($inputPrice.val()));
    }

    function disableField($field) {
        $field.prop("disabled", true);
    }

    function disableSetFields() {
        $capacity
            .addClass("fullCapacity")
            .val("full");
        disableField($button);
        disableField($inputName);
        disableField($inputPrice);
        disableField($inputQuantity);
    }

    function resetToInitialState() {
        $inputName.val("");
        $inputName.trigger("input");
        $inputPrice.val(1);
        $inputQuantity.val(1);
    }

    function inputEvent() {
        if ($inputName.val() === "") {
            disableField($button);
        } else {
            $button.prop('disabled', '');
        }
    }
}
