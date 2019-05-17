function subtract() {
    let $firstInput = $("#firstNumber");
    let $secondInput = $("#secondNumber");

    let result = $("#result");

    result.text(Number($firstInput.val()) - Number($secondInput.val()));
}