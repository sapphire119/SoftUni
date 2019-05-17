function solve() {
    let arrInput = document.getElementById('arr');
    let arrInputValue = JSON.parse(arrInput.value).map(Number);

    let output = document.getElementById('result');

    let result = [];
    for (let i = 0; i < arrInputValue.length; i++) {
        if (i % 2 === 0) {
            result.push(arrInputValue[i]);
        }
    }

    output.textContent = result.join(" x ");
}