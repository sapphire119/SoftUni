function solve() {
    let input = document.getElementById('str').value;
    let charactersToRemove = input.split('').map(Number).reduce((a, b) => a + b);

    while (charactersToRemove >= 10) {
        let tokens = charactersToRemove.toString().split('');
        let a = Number(tokens[0]);
        let b = Number(tokens[1]);
        charactersToRemove = a + b;
    }
    debugger;
    input = input
        .substr(charactersToRemove, (input.length - (2 * charactersToRemove)));
    debugger;
    let asciiCodes = [];

    while (input.length > 0) {
        debugger;
        let temp = input.substr(0, 8);
        asciiCodes.push(parseInt(temp, 2));
        input = input.substr(8);
    }

    let output = document.getElementById('result');
    debugger;

    let pattern = /^([A-Za-z]|\s)$/;

    // let testArr = ["a", "b", "c", " ", "!", "@", '_', ",", "$", "w", "Q"];
    let lettersResult = asciiCodes.map(e => String.fromCharCode(e)).filter(e => pattern.test(e)).join("");
debugger;
    output.textContent = lettersResult;
}