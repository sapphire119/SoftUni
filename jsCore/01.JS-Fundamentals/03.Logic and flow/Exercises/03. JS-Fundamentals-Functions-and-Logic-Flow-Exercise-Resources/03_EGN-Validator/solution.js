function validate() {
    let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];

    function getMonth(month){
        let temp = ['January', 'February', 'March', 'April', 'May', 'June', 'July',
        'August', 'September', 'October', 'November', 'December'].indexOf(month) + 1;

        if (temp < 10) return `0${temp}`;
        else return temp.toString();
    }

    function calcLastDigit(egn) {
        let sum = 0;
        for (let i = 0; i < weights.length; i++) {
            let product = Number(egn[i]) * weights[i];
            sum += product;
        }
        debugger;
        let result = (sum % 11 !== 10) ? (sum % 11) : 0;

        return result.toString();
    }

    let button = document.querySelector('#exercise div button');

    button.addEventListener('click', clickEvent);

    function clickEvent(event){
        let egn = '';

        let yearInput = document.getElementById('year');
        let yearInputValue = yearInput.value;

        let selectInput = document.getElementById('month');
        let selectInputValue = selectInput.options[selectInput.selectedIndex].value;
        let monthValueString = getMonth(selectInputValue);

        let dateInput = document.getElementById('date');
        let dateInputValue = dateInput.value;

        dateInputValue = Number(dateInputValue) < 10 ? `0${dateInputValue}` : dateInputValue;

        egn = `${yearInputValue.substring(2)}${monthValueString}${dateInputValue}`;

        let regionInput = document.getElementById('region');
        let regionInputValue = regionInput.value;


        egn += regionInputValue.substring(0, 2);

        let maleInput = document.getElementById('male');
        let femaleInput = document.getElementById('female');
        if(maleInput.checked){
            egn += "2";
        } else if(femaleInput.checked){
            egn += "1";
        }

        let lastDigit = calcLastDigit(egn);
        egn += lastDigit;

        debugger;
        let output = document.getElementById('egn');
        output.textContent = `Your EGN is: ${egn}`;

        debugger;
        yearInput.value = '';
        selectInput.selectedIndex = 0;
        dateInput.value = '';
        maleInput.checked = false;
        femaleInput.checked = false;
        regionInput.value = '';
        debugger;
    }
}