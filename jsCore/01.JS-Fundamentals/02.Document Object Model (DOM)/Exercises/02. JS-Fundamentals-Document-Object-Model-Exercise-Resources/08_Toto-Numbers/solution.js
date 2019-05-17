function solve() {
    let inputDiv = document.getElementById('myNumbers');
    let inputField = inputDiv.children[1];
    let button = inputDiv.children[2];

    button.addEventListener('click', e => clickEvent(e, inputField));

    function clickEvent(event, inputField) {
        debugger;
        let numbers = inputField.value.toString().trim().split(' ').filter(function (e1) {
            return e1 !== "";
        }).map(function (n) {
            return Number(n.trim());
        });

        debugger;
        let rangeCondition = numbers.filter(n => !(1 <= n && n <= 49));

        if (numbers.length === 6 && !numbers.some(isNaN) && rangeCondition.length === 0){
            let allNumbers = document.getElementById('allNumbers');
            for (let i = 1; i <= 49; i++){

                let divI = document.createElement('div');
                divI.innerHTML = i.toString();
                divI.classList.add('numbers');

                if (numbers.includes(i)){
                    divI.style.background = 'orange';
                }

                allNumbers.appendChild(divI);
            }
            button.setAttribute('disabled', '');
            inputField.setAttribute('disabled', '');
        }
        debugger;
    }
}