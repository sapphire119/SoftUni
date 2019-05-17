function solve(arrInput) {
    let rotations = arrInput[arrInput.length - 1];

    let arr = arrInput.slice(0, arrInput.length - 1);

    if (rotations > arr.length) rotations %= arr.length;

    for (let i = 0; i < rotations; i++) {
        let arrElement = arr.pop();
        arr.unshift(arrElement);
    }

    console.log(arr.join(' '));
}

// solve(['1', '2', '3', '4', '2']);

solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']);