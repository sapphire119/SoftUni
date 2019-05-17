function solve() {
    function isChar(charValue){
        let pattern = /[a-zA-Z]{1}/;
        return pattern.test(charValue);
    }
    debugger;

    let stringValue = document.getElementById('string').value;
    let charValue = document.getElementById('character').value;

    if(typeof(stringValue) !== 'string' && !(stringValue instanceof  String)) return;

    if (!isChar(charValue)) return;

    let result = document.getElementById('result');

    debugger;

    let countOfOccurences = 0;
    for (let i = 0; i < stringValue.length; i++){
        if (stringValue[i] === charValue) countOfOccurences++;
    }

    result.innerHTML = `Count of ${charValue} is ${countOfOccurences % 2 === 0 ? 'even' : 'odd'}.`;
}