function solve(inputArr, command) {
    function ascendingComparer(a, b) {
        return a - b;
    }

    function descendingComparer(a, b) {
        return b - a;
    }

    let sortingComparers = {
        'asc': ascendingComparer,
        'desc': descendingComparer
    };

    return inputArr.sort(sortingComparers[command]);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));

console.log(solve([14, 7, 17, 6, 8], 'desc'));