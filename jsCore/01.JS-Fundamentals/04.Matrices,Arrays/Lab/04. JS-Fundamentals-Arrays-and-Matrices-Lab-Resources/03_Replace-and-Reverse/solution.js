function solve() {
    let arrInput = document.getElementById('arr');
    let arrInputValue = JSON.parse(arrInput.value);
    for (let i = 0; i < arrInputValue.length; i++) {
        let arrInputValueElement = arrInputValue[i];
        let word = arrInputValueElement.split('').reverse().join('');
        word = word.charAt(0).toUpperCase().concat(word.substring(1));

        arrInputValue[i] = word;
    }

    let output = document.getElementById('result');
    output.textContent = arrInputValue.join(' ');
}