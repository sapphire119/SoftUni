function solve(arrInput) {

    // let test = ['test', 'Deny', 'omen', 'Default'];
    // test.sort((a, b) => orderAlphabetically(a, b));
    // function orderAlphabetically(a, b) {
    //     let firstString = a.toString().toLowerCase();
    //     let secondString = b.toString().toLowerCase();
    //
    //     let result = firstString.localeCompare(secondString);
    //
    //     return result;
    // }

    let resultingArr = arrInput.sort((a, b) => a.length - b.length || a.localeCompare(b));

    resultingArr.forEach(e => console.log(e));
}

// solve(['alpha', 'beta', 'gamma']);

// solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);

solve(['test', 'Deny', 'omen', 'Default']);

// solve(['a', 'b', 'c', 'd', 'e', 'a', 'a', 'c', 'd', 'f', 'g']);