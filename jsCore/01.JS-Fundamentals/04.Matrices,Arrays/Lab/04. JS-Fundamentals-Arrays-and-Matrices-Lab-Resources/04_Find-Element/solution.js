function solve() {
    let number = parseInt(document.getElementById("num").value);
    let listInput = JSON.parse(document.getElementById("arr").value);
    let answer = [];
    function calc(searched, input) {
        debugger;
        for (let element of input) {
            let result = element.includes(searched);
            let index = element.indexOf(searched);
            answer.push(result + ' -> ' + index);
        }
        return answer;
    }
    debugger;
    let result = calc(number, listInput);
    document.getElementById("result").innerHTML = result;
}
