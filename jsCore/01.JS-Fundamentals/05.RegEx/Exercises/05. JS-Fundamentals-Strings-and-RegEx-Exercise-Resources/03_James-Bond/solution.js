function solve() {
    let decoder = {
        "!": 1,
        "%": 2,
        "#": 3,
        "$": 4,
    };

    debugger;
    let arrInput = JSON.parse(document.getElementById('arr').value);
    debugger;
    let validSpecialKeyPattern = /^(^| ?)[a-zA-Z]+$/gmi;

    let specialKeyWord = arrInput[0];

    specialKeyWord = specialKeyWord.trim();

    let validEncodedMessage = /(^| ?)([a-zA-Z]+)\s+([A-Z!%$#]{8,})([ .,]|$)/gm;

    debugger;
    let temp = arrInput.slice(1);
    let difference = [];
    let allMatches = [];
    for (let currentLine of temp) {
        let oldMatches = [];
        while (true) {
            let currentMatch = currentLine.match(validEncodedMessage);
            if (currentMatch === undefined || currentMatch === null) break;
            oldMatches = currentMatch.slice();
            oldMatches.forEach(m => {
                let tempWord = m.trim().substr(0, specialKeyWord.length);
                if (tempWord.toLowerCase() !== specialKeyWord.toLowerCase()) {
                    difference.push(m);
                }
            });
            while (difference.length > 0) {
                let currentDif = difference.pop();
                let indexOfDif = currentLine.indexOf(currentDif);
                let firstTokenWordInDiff = currentDif.split(' ')[0];
                currentLine = currentLine.substr(0, indexOfDif).concat(currentLine.substr(indexOfDif + firstTokenWordInDiff.length));
            }
            let currentMatches = currentLine.match(validEncodedMessage);
            if (currentMatches.every((m, i) => m === oldMatches[i])){
                break;
            }
        }
        allMatches.push(oldMatches);
    }

    let currentText = arrInput.slice(1);
    debugger;
    for (let i = 0; i < allMatches.length; i++) {
        let currentMatchArr = allMatches[i];
        if (currentMatchArr.length < 1) continue;
        for (let j = 0; j < currentMatchArr.length; j++) {
            let currentMatch = currentMatchArr[j];
            let tokens = currentMatch.split(' ').filter(w => w);
            let wordToChange = tokens[1];
            let newWord = "";
            let temmPattern = /^[A-Z.]+$/;
            for (let i = 0; i < wordToChange.length; i++) {
                let character = wordToChange[i];
                if(!temmPattern.test(character)){
                    newWord += decoder[character];
                    continue;
                }
                newWord += character.toLowerCase();
            }
            let newStr = currentMatch.replace(wordToChange, newWord);

            currentText[i] = currentText[i].replace(currentMatch, newStr);
        }
    }

    let output = document.getElementById('result');
    for (let i = 0; i < currentText.length; i++) {
        let currentTextElement = currentText[i];
        let p = document.createElement('p');
        p.innerHTML = currentTextElement;
        output.appendChild(p);
    }
}