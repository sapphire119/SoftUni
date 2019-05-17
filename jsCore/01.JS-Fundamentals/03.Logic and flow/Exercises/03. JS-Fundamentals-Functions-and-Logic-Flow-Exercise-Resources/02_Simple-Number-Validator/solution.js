function validate() {
    let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];

    function calcProduct(number) {
        let numberToString = number.toString();
        let sum = 0;
        for (let i = 0; i < weights.length; i++) {
            let product = Number(numberToString[i]) * weights[i];
            sum += product;
        }
        debugger;
        let result = sum % 11 !== 10 ? sum % 11 : 0;

        return result;
    }

    let button = document.querySelector('#exercise fieldset div button');

    button.addEventListener('click', clickEvent);

    function clickEvent(event){
        debugger;
        let input = document.querySelector('#exercise fieldset div input');
        let numberValue = Number(input.value);

        let inputToString = input.value.toString();
        let areProductSumResultAndLastDigitEqual = calcProduct(numberValue).toString() === inputToString[inputToString.length - 1];

        let output = document.getElementById('response');
        output.textContent = areProductSumResultAndLastDigitEqual ? "This number is Valid!" : "This number is NOT Valid!";
    }

}