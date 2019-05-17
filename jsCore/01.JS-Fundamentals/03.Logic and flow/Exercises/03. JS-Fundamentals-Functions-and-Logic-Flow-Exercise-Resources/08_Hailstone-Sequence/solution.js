function getNext() {
    let inputNum = document.getElementById('num');
    let number = Number(inputNum.value);

    let sequnece = '';

    debugger;
    function solve(number){
        sequnece += (number + " ");

        if (number === 1){
            return;
        } else if (number % 2 === 0){
            number = number / 2;
        } else if (number % 2 === 1){
            number = ((number * 3) + 1)
        }

        solve(number);
    }

    solve(number);

    let output = document.getElementById('result');

    output.innerHTML = sequnece;
}