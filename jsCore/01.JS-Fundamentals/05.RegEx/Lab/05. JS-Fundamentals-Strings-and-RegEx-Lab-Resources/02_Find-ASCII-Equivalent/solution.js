function solve() {
    let input = document.getElementById('str').value;
    let charCodesResult = input.split(' ').filter(e => !Number(e))
    for (let i = 0; i < charCodesResult.length; i++) {
        let word = charCodesResult[i];
        charCodesResult[i] = word.split('').map(c => c.charCodeAt(0)).join(' ');
    }

    let charCodes = input.split(' ').filter(e => Number(e)).map(Number);
    let test = String.fromCharCode(...charCodes); // Spread Operator
    let wordResult = charCodes.map(e => String.fromCharCode(e)).join("");
    debugger;

    let output = document.getElementById('result');
    charCodesResult.forEach(e => {
        let p = document.createElement('p');
        p.innerHTML = e;
        output.appendChild(p);
    });

    let wordP = document.createElement('p');
    wordP.innerHTML = wordResult;

    output.appendChild(wordP);
}