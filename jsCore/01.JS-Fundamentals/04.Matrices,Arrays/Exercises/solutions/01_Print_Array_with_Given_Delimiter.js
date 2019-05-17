function solve(arrInput) {
    let arr = arrInput.splice(0, arrInput.length - 1);

    let delimeter = arrInput[arrInput.length - 1];

    console.log(arr.join(delimeter));
}

solve(['One', 'Two', 'Three', 'Four', 'Five', '-']);

solve(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!',
    '_']
);