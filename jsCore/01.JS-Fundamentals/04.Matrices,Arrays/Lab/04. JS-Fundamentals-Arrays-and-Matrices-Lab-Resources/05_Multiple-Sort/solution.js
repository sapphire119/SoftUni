function solve() {
    let arr = JSON.parse(document.getElementById('arr').value);
    let temp = arr.slice();

    debugger;
    let sortedByAscending = temp.sort((a, b) => a - b);
    let alpabeticalSort = arr.sort();
    debugger;
    let divSortedAscending = document.createElement('div');
    let divAlpabetical = document.createElement('div');

    divSortedAscending.innerHTML = sortedByAscending.join(', ');
    divAlpabetical.innerHTML = alpabeticalSort.join(', ');

    let output = document.getElementById('result');
    output.appendChild(divSortedAscending);
    output.appendChild(divAlpabetical);
}