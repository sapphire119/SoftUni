function solve() {
    debugger;
    let firstNumberInput = document.getElementById('num1');
    let firstNumber = Number(firstNumberInput.value);
    if (isNaN(firstNumber)) return;

    let secondNumberInput = document.getElementById('num2');
    let secondNumber = Number(secondNumberInput.value);

    if (isNaN(secondNumber)) return;
    let result = document.getElementById('result');

    if (firstNumber > secondNumber){
        return result.innerHTML = "Try with other numbers.";
    }

    for(let i = firstNumber; i <= secondNumber; i++){
        let p = document.createElement('p');
        p.innerHTML = `${i} * ${secondNumber} = ${i * secondNumber}`;
        result.appendChild(p);
    }
}