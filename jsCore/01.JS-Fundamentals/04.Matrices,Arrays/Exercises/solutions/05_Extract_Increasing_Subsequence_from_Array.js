function solve(arrInput) {
    let biggestElement = arrInput[0];
    let resultingArr = [biggestElement];

    for (let i = 0; i < arrInput.length; i++) {
        let arrInputElement = arrInput[i];
        if (arrInputElement >= biggestElement && i !== 0){
            biggestElement = arrInputElement;
            resultingArr.push(biggestElement);
        }
    }

    resultingArr.forEach(e => console.log(e));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);

// solve([1, -1, -2,-3, 1, 3, 4]);

// solve([20, 3, 2, 15, 6, 1]);