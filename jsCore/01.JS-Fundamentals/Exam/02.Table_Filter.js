function solve(inputArr, commandInput) {

    function hideFunc(headerRowArr, values, columnToDelete) {
        let currentEleToHide = columnToDelete[0];
        let indexOfEle = headerRowArr.indexOf(currentEleToHide);

        let resultingArr = [];
        resultingArr.push(headerRowArr.filter((e, _, arr) => e !== arr[indexOfEle]));
        for (let i = 0; i < values.length; i++) {
            let tempArr = [];
            tempArr = values[i].filter((_, i) => i !== indexOfEle).slice();
            // for (let j = 0; j < values[i].length; j++) {
            //     if (values[i][j] !== values[i][indexOfEle]) {
            //         tempArr.push(values[i][j]);
            //     }
            // }
            resultingArr.push(tempArr);
        }
        debugger;
        return resultingArr;
    }

    function sortFunc(headerRowArr, values, columnToSort) {
        let currentEleToSort = columnToSort[0];
        let indexOfEle = headerRowArr.indexOf(currentEleToSort);

        let tempArr = values.sort((a, b) => {
            let testA = a[indexOfEle];
            let testB = b[indexOfEle];

            return testA.localeCompare(testB);
            // a[indexOfEle].localeCompare(b[indexOfEle])
        });

        let resultingArr = [];
        resultingArr.push(headerRowArr);
        resultingArr.push(...tempArr);

        return resultingArr;

        // for (let i = 0; i < values.length; i++) {
        //     let currentValue = values[i][indexOfEle];
        //     tempArr.push(currentValue);
        // }
        //
        // tempArr.sort((a, b) => a.localeCompare(b));
        //
        // for (let i = 0; i < tempArr.length; i++) {
        //     let currentEle = tempArr[i];
        //
        //     debugger;
        // }
        // // for (let i = 0; i < values.length; i++) {
        // //     let tempValue = values[i][indexOfEle];
        // //     if(values[i][indexOfEle] === tempArr[i]){
        // //         let temp = values[i];
        // //         debugger;
        // //     }
        // // }
        //
        // resultingArr.push(...values);
        // debugger;

    }

    function filterFunc(headerRowArr, values, rowToFilter) {
        let currentEleToHide = rowToFilter[0];
        let valueToFind = rowToFilter[1];

        let indexOfEle = headerRowArr.indexOf(currentEleToHide);

        let indexesOfRows = [];
        let resultingArr = [];
        resultingArr.push(headerRowArr);

        for (let i = 0; i < values.length; i++) {
            let tempValue = values[i][indexOfEle];
            if (tempValue === valueToFind) {
                indexesOfRows.push(i);
            }
        }
        for (let i = 0; i < indexesOfRows.length; i++) {
            let currentIndex = indexesOfRows[i];
            resultingArr.push(values[currentIndex].slice());
        }

        // debugger;

        return resultingArr;
    }

    let headerRow = inputArr[0];
    let values = inputArr.slice(1);

    let commandTokens = commandInput.split(" ");

    let currentCommand = commandTokens[0];
    let result = [];

    switch (currentCommand) {
        case "hide":
            result = hideFunc(headerRow, values, commandTokens.slice(1)).slice();
            break;
        case "sort":
            result = sortFunc(headerRow, values, commandTokens.slice(1)).slice();
            break;
        case "filter":
            result = filterFunc(headerRow, values, commandTokens.slice(1)).slice();
            break;
    }

    for (let i = 0; i < result.length; i++) {
        let resultElement = result[i];
        console.log(resultElement.join(" | "));
    }
}

solve([['name', 'age', 'grade'],
        ['Peter', '25', '5.00'],
        ['George', '34', '6.00'],
        ['Marry', '28', '5.49']],
    'hide age'
);
//
// solve([['name', 'age', 'grade'],
//         ['Peter', '25', '5.00'],
//         ['George', '34', '6.00'],
//         ['Marry', '28', '5.49']],
//         'sort name'
// );
//
// solve([['firstName', 'age', 'grade', 'course'],
//         ['Marry', '25', '5.00', 'JS-Core'],
//         ['George', '34', '6.00', 'Marry'],
//         ['Marry', '28', '5.49', 'Ruby']],
//     'filter firstName Marry'
// );
