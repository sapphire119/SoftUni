function solve(firstString, secondString){
    let firstNumber = Number(firstString);
    let secondNumber = Number(secondString);

    let result = 0;
    while(firstNumber <= secondNumber){
        result += firstNumber++;
    }

    console.log(result);
}