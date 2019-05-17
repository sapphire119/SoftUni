function solve(firstNumber, secondNumber, mathOperator){
    let result = eval(`${firstNumber} ${mathOperator} ${secondNumber}`);

    console.log(result);
}

function solve2(firstNumber, secondNumber, mathOperator){
    let result = Number(0);
    switch(mathOperator){
        case '*': result = firstNumber * secondNumber; break;
        case '/': result = firstNumber / secondNumber; break;
        case '+': result = firstNumber + secondNumber; break;
        case '-': result = firstNumber - secondNumber; break;
        case '%': result = firstNumber % secondNumber; break;
        case '**': result = firstNumber ** secondNumber; break;
    }

    console.log(result);
}