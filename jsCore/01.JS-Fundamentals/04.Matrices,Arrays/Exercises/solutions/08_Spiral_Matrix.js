function solve(rows, columns) {

    let initialNumber = 1;

    let resultingArr = [];
    for (let i = 0; i < rows; i++) {
        resultingArr[i] = new Array(columns);
    }

    let startingRow = 0;
    let startingColumn = 0;

    let endingRows = rows;
    let endingColumns = columns;
    while (true){
        for (let i = 0; i < endingColumns; i++) {
            if (resultingArr[startingRow][i] === null || resultingArr[startingRow][i] === undefined){
                resultingArr[startingRow][i] = initialNumber++;
            }
        }

        for (let i = 0; i < endingRows; i++) {
            let currentCol = endingColumns - 1;

            if (resultingArr[i][currentCol] === null || resultingArr[i][currentCol] === undefined) {
                resultingArr[i][currentCol] = initialNumber++;
            }
        }

        for (let i = endingColumns - 1; i >= 0 ; i--) {
            let currentRow = endingRows - 1;
            if (resultingArr[currentRow][i] === null || resultingArr[currentRow][i] === undefined) {
                resultingArr[currentRow][i] = initialNumber++;
            }
        }

        for (let i = endingRows - 1; i >= 0; i--) {
            if (resultingArr[i][startingColumn] === null || resultingArr[i][startingColumn] === undefined) {
                resultingArr[i][startingColumn] = initialNumber++;
            }
        }

        startingRow++;
        startingColumn++;
        endingRows--;
        endingColumns--;

        if (startingRow > endingRows || startingColumn > endingColumns){
            break;
        }
    }
    for (let i = 0; i < resultingArr.length; i++) {
        console.log(resultingArr[i].join(' '));
    }
}

// solve(5, 4);

solve(5, 5);
//
// solve(3, 3);

// solve(1, 2);