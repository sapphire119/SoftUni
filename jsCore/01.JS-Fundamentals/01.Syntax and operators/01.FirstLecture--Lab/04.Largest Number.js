function solve(firstNumber, secondNumber, thirdNumber){
    let result = Math.max(Math.max(firstNumber, secondNumber), thirdNumber);

    return console.log(`The largest number is ${result}.`);
}