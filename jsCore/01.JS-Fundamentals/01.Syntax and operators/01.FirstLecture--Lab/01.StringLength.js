function solve(firstArg, secondArg, thirdArg){
    let firstArgLength = firstArg.length;
    let secondArgLength = 
    secondArg.length;
    let thirdArgLength =
    thirdArg.length;

    let sumOfLength = 
    firstArgLength + secondArgLength + thirdArgLength;

    let averageLength = 
    Math.round(sumOfLength / 3);

    console.log(sumOfLength);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');