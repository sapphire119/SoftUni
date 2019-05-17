function solve() {
    let inputValue = document.getElementById('string').value;

    debugger;
    let result = Array.from(inputValue.toString().split("")).filter((item, index, array) => {
        debugger;
        if(item === ' ') return true;
        let condtion = array.indexOf(item) === index;
        return condtion;
    });
    debugger;

    let output = document.getElementById('result');

    output.innerHTML = result.join("");
}