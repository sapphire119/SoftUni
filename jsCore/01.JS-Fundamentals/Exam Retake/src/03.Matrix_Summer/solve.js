function solve(firstArr, secondArr) {
    let result = [];
    for (let i = 0; i < firstArr.length; i++) {
        let firstArrRow = firstArr[i];
        let secondArrRow = secondArr[i];

        result.push(sumRows(firstArrRow, secondArrRow));
    }

    function sumRows(firstRow, secondRow) {
        let output = [];
        let remainder = 0;
        for (let i = 0; i < firstRow.length; i++) {
            let firstRowElement = firstRow[i];
            let secondRowElement = secondRow[i];

            //if sum < 10 ==> calculate
            let sum = firstRowElement + secondRowElement + remainder;
            if (sum < 10) {
                output.push(sum);
                remainder = 0;
            } else if (sum >= 10) {
                //if next sum < 10 ==> add remainder, and add in next calc, reset remainder
                remainder = (sum - 9);
                output.push(9);
            }
        }

        //if next sum > 10 ==> if arr length is over push remainder in output;
        if (0 < remainder && remainder < 10){
            output.push(remainder);
        } else if (remainder >= 10) {
            while (remainder >= 10) {
                output.push(9);
                remainder -= 9;
            }

            if (remainder > 0) {
                output.push(remainder);
            }
        }

        return output;
    }

    console.log(JSON.stringify(result));
}


solve([[1, 2, 3], [3, 4, 5], [5, 6, 7]],
    [[1, 1, 1], [1, 1, 1], [1, 1, 1]]
);

solve([[9, 2, 3], [4, 5, 6], [7, 8, 8]],
    [[1, 1, 1], [1, 1, 1], [1, 1, 1]]
);

solve([[9, 9], [4, 7]],
    [[7, 1], [1, 2]]
);