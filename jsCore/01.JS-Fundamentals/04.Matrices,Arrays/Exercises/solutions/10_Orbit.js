function solve(arrInput) {
    let rows = arrInput[0];
    let columns = arrInput[1];

    let rowIndex = arrInput[2];
    let columnIndex = arrInput[3];

    let resultingMatrix = [];
    for (let i = 0; i < rows; i++) {
        resultingMatrix[i] = new Array(columns);
    }
    
    let initalNumber = 1;
    
    resultingMatrix[rowIndex][columnIndex] = initalNumber;

    let topRowIndex = rowIndex - 1;
    let bottomRowIndex = rowIndex + 1;

    let leftColumnIndex = columnIndex - 1;
    let rightColumnIndex = columnIndex + 1;

    while (topRowIndex >= 0 || leftColumnIndex >= 0 ||
    bottomRowIndex < resultingMatrix.length || rightColumnIndex < resultingMatrix[0].length){
        initalNumber++;

        let currentTopIndex = topRowIndex < 0 ? 0 : topRowIndex;
        let currentBottomIndex= bottomRowIndex > resultingMatrix.length - 1 ? resultingMatrix.length - 1 : bottomRowIndex;

        let currentLeftIndex = leftColumnIndex < 0 ? 0 : leftColumnIndex;
        let currentRightIndex = rightColumnIndex > resultingMatrix[0].length - 1 ? resultingMatrix[0].length - 1: rightColumnIndex;

        for (let rowStartingIndex = currentTopIndex; rowStartingIndex <= currentBottomIndex; rowStartingIndex++) {
            for (let colStartingIndex = currentLeftIndex; colStartingIndex <= currentRightIndex; colStartingIndex++) {
                let condition = (rowStartingIndex !== rowIndex || colStartingIndex !== columnIndex);
                let isEmpty = !resultingMatrix[rowStartingIndex][colStartingIndex];
                if (condition && isEmpty) {
                    resultingMatrix[rowStartingIndex][colStartingIndex] = initalNumber;
                }
            }
        }

        topRowIndex--;
        leftColumnIndex--;
        bottomRowIndex++;
        rightColumnIndex++;
    }

    for (let i = 0; i < resultingMatrix.length; i++) {
        console.log(resultingMatrix[i].join(' '));
    }
}

// solve([4, 4, 0, 0]);

// solve([5, 5, 2, 2]);

solve([3, 3, 2, 2]);