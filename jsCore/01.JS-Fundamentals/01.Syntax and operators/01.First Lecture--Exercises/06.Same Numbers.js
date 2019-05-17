function solve(inputNumbersArg){
    if(typeof(inputNumbersArg) === 'number' && Number.isInteger(inputNumbersArg)){
        let numbers = inputNumbersArg.toString().split('');
        let areSame = true;
        let firstNumber = parseInt(numbers[0]);
        let sum = 0;
        for(let number of numbers){
            let currentNumber = parseInt(number);
            if(currentNumber !== firstNumber){
                areSame = false;
            }
            sum += currentNumber;
        }
        console.log(areSame);
        console.log(sum);
    }
}