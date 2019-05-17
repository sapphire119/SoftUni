function solve() {
    let firstMatrixInput = document.getElementById('mat1');
    let firstMatrixInputValue = firstMatrixInput.value;

    let firstMatrix = JSON.parse(firstMatrixInputValue);

    let secondMatrixInput = document.getElementById('mat2');
    let secondMatrixInputValue = secondMatrixInput.value;

    let secondMatrix = JSON.parse(secondMatrixInputValue);
    let resultingMatrix = [];
    for (let p = 0; p < firstMatrix.length; p++) {
        resultingMatrix[p] = new Array(secondMatrix.length)
    }

    function calculateSum(firstArray, secondMatrix) {
        let sumArray = [];
        let tempSum = 0;
        for (let i = 0; i < secondMatrix.length; i++) {
            for (let j = 0; j < secondMatrix[i].length; j++) {
                let product = firstArray[j] * secondMatrix[i][j];
                tempSum += product;
            }
            sumArray.push(tempSum);
            tempSum = 0;
        }
        return sumArray;
    }

    for (let i = 0; i < firstMatrix.length; i++) {
        let firstSumArr = calculateSum(firstMatrix[i], secondMatrix);
        for (let p = 0; p < resultingMatrix.length; p++) {
            resultingMatrix[i][p] = firstSumArr[p];
        }
    }

    debugger;
    let output = document.getElementById('result');

    for (let i = 0; i < resultingMatrix.length; i++) {
        let p = document.createElement('p');
        p.innerHTML = resultingMatrix[i].join(", ");
        output.appendChild(p);
    }

    debugger;
}