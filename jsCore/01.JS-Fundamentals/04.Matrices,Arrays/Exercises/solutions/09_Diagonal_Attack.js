function solve(inputArr) {
    let matrix = inputArr.map(e => e.split(' ').map(Number));

    let firstDiagonalSum = 0;
    let secondDiagnoalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (i === j){
                firstDiagonalSum += matrix[i][j];
                break;
            }
        }

        for (let p = matrix[i].length - 1; p >= 0; p--) {
            if (p + i === matrix.length - 1) {
                secondDiagnoalSum += matrix[i][p];
                break;
            }
        }
    }

    function printMatrix(matrix) {
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '));
        }
    }
    let resultingMatrix = matrix.slice();

    if (firstDiagonalSum === secondDiagnoalSum) {
        for (let i = 0; i < resultingMatrix.length; i++) {
            for (let j = 0; j < matrix[i].length; j++) {
                if (i !== j && i + j !== matrix.length - 1) {
                    resultingMatrix[i][j] = firstDiagonalSum;
                }
            }
        }
    }
    printMatrix(resultingMatrix);
}


solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);