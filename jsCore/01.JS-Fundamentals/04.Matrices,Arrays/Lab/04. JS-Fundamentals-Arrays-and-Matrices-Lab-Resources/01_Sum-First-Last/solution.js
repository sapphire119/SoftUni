function solve() {
    debugger;
    let arrInput = document.getElementById('arr');
    let mappedArr = Array.from(JSON.parse(arrInput.value)).map(Number);

    let output = document.getElementById('result');
    for (let i = 0; i < mappedArr.length; i++) {
        let p = document.createElement('p');
        p.innerHTML = `${i} -> ${mappedArr[i] * mappedArr.length}`;
        output.appendChild(p);
    }
    debugger;
}