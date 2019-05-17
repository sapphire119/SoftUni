function solve(matrixInput) {
    let results = [];

    let maxLength = 0;

    for (let row = 0; row < matrixInput.length; row++) {
        if (matrixInput[row].length > maxLength){
            maxLength = matrixInput[row].length;
        }
    }

    const arrayColumn = (arr, n) => arr.map(x => x[n]);

    for (let i = 0; i < maxLength; i++) {
        let columnSum = arrayColumn(matrixInput, i).filter(e => e !== undefined).reduce((a, b) => a + b, 0);
        results.push(columnSum);
    }

    for (let row = 0; row < matrixInput.length; row++) {
        let currentRow = 0;
        for (let col = 0; col < matrixInput[row].length; col++) {
            currentRow += matrixInput[row][col];
        }
        results.push(currentRow);
    }

    console.log(results.every((val, _, arr) => val === arr[0]));
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);

// solve([[11, 32, 45],
//     [21, 22, 1, 1],
//     [21, 1, 1]]
// );

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
);
//
// solve([[0, 0, 0],
//     [0, 0, 0],
//     [0, 0, 0]]
// );