function solve(inputArr) {
    const commandProcessor = (function process() {
        let currentString = "";
        debugger;

        return {
            append: (str) => currentString += str,
            removeStart: (n) => currentString = currentString.substr(n),
            removeEnd: (n) => currentString = currentString.substr(0, currentString.length - n),
            print: () => console.log(currentString)
        }
    })();

    for (let inputArrElement of inputArr) {
        let [command, value] = inputArrElement.split(" ");
        // let command = tokens[0];
        // let value = tokens[1];
        debugger;
        commandProcessor[command](value);
        debugger;
    }
}

solve(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']
);

solve(['append 123',
    'append 45',
    'removeStart 2',
    'removeEnd 1',
    'print']
);