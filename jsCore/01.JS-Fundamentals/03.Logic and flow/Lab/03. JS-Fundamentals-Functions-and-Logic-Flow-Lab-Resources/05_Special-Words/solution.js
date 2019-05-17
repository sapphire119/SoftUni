function solve() {
    let firstNumber = Number(document.getElementById('firstNumber').value);
    let secondNumber = Number(document.getElementById('secondNumber').value);

    let output = document.getElementById('result');

    let firstStr = document.getElementById('firstString').value;
    let secondStr = document.getElementById('secondString').value;
    let thirdStr = document.getElementById('thirdString').value;

    function getResult(p, num1) {
        if (num1 % 5 === 0 && num1 % 3 === 0){
            return p.innerHTML += `${num1} ${firstStr}-${secondStr}-${thirdStr}`;
        } else if (num1 % 3 === 0) {
            return p.innerHTML += p.innerHTML += `${num1} ${secondStr}`;
        } else if (num1 % 5 === 0) {
            return p.innerHTML += `${num1} ${thirdStr}`;
        } else {
            return p.innerHTML += num1.toString();
        }
    }

    function outputFunc(num1, num2){
        if (num2 >= num1){
            let p = document.createElement('p');
            getResult(p, num1);
            output.appendChild(p);
        }
        else {
            return;
        }

        return outputFunc(++num1, num2);
    }

    outputFunc(firstNumber, secondNumber);
}