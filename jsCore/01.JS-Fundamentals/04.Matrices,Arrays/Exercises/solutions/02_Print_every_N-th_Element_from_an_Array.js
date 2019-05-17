function solve(arrInput) {
    let step = Number(arrInput[arrInput.length - 1]);

    let inputArr = arrInput.slice(0, arrInput.length - 1);

    for (let i = 0; i < inputArr.length; i+= step) {
        console.log(inputArr[i]);
    }
}

// solve(['5', '20', '31', '4', '20', '2']);
//
solve(['dsa', 'asd', 'test', 'tset', '2']);

// solve(['1', '2', '3', '4', '5', '6']);