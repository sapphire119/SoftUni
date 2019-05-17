function solve(firstNumberArg, secondNumberArg){
    let firstNumber = Number(firstNumberArg);
    let secondNumber = Number(secondNumberArg);

    if(firstNumber > 0 && secondNumber > 0){
        let firstNumberUsed = Math.max(firstNumber, secondNumber);

        let secondNumberUsed = Math.min(firstNumber, secondNumber);
        let greatestDivisor;
        for(let i = 1; i <= secondNumberUsed; i++){
            if(firstNumberUsed % i == 0 && secondNumberUsed % i == 0){
                greatestDivisor = i;
            }
        }

        console.log(greatestDivisor);
    }
}