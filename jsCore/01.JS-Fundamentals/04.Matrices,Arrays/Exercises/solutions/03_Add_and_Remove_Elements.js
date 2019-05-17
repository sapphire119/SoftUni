function solve(inputArr) {
    let initialNumber = 1;

    let resultingArr = [];

    function executeCommand(command, resultingArr) {
        switch (command){
            case 'add': resultingArr.push(initialNumber); break;
            case 'remove': resultingArr.pop(); break;
        }
    }

    for (let i = 0; i < inputArr.length; i++) {
        const command = inputArr[i];
        executeCommand(command, resultingArr);
        initialNumber++;
    }

    resultingArr.length >= 1 ? resultingArr.forEach(el => console.log(el)) : console.log('Empty');
}

solve(['add']);
// solve(['add', 'add', 'add', 'add']);
//
// solve(['add', 'add', 'remove', 'add', 'add']);

// solve(['remove', 'remove', 'remove']);