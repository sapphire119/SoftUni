function solve(inputArr) {
    //Sum
    console.log(`Sum = ${inputArr.reduce((acc, val) => acc += val, 0)}`);
    //Min
    console.log(`Min = ${inputArr.reduce((acc, val) => acc > val ? val : acc, Number.MAX_SAFE_INTEGER)}`);
    //Max
    console.log(`Max = ${inputArr.reduce((acc, val) => acc < val ? val : acc, Number.MIN_SAFE_INTEGER)}`);
    //Product
    console.log(`Product = ${inputArr.reduce((acc, val) => acc *= val, 1)}`);
    //Join // Concat
    console.log(`Product = ${inputArr.reduce((acc, val) => acc += val, '')}`);
}

// solve([2, 3, 10, 5]);

solve([5, -3, 20, 7, 0.5]);