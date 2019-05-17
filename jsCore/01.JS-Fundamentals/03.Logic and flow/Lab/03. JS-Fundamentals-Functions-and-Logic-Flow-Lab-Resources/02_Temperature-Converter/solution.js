function solve() {
    let numberToConvertInput = document.getElementById('num1');

    let numToConv = Number(numberToConvertInput.value);
    if (isNaN(numToConv)) return;

    let typeConverter = document.getElementById('type');
    let typeConvVal = typeConverter.value.toString().toLowerCase();

    let result = document.getElementById('result');

    switch (typeConvVal){
        case 'celsius':
            let fahrenheitDegrees = Math.round((numToConv * (9/5)) + 32);
            result.innerHTML = fahrenheitDegrees.toString();
            break;
        case 'fahrenheit':
            let celsiusDegrees = Math.round((numToConv - 32) * (5 / 9));
            result.innerHTML = celsiusDegrees.toString();
            break;
        default:
            return result.innerHTML = 'Error!';
    }
}