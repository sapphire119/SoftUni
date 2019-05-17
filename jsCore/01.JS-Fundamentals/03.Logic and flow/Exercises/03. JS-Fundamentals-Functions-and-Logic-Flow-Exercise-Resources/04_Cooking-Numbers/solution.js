function solve() {
    let oldValue = 0;
    let newValue = 0;

    let operations = Array.from(document.getElementById('operations').children).forEach((btn) =>{
        btn.addEventListener('click', clickEvent);
    });

    function clickEvent(event) {
        debugger;
        let number = document.querySelector('#exercise input');
        let numberValue = Number(number.value);

        let output = document.getElementById('output');
        let outputValue = output.textContent;

        debugger;
        if (outputValue === '') {
            oldValue = numberValue;
        } else {
            oldValue = Number(outputValue);
        }

        let currentButton = event.target;
        debugger;
        switch (currentButton.innerHTML){
            case 'Chop': newValue = oldValue / 2; break;
            case 'Dice': newValue = Math.sqrt(oldValue); break;
            case 'Spice': newValue = oldValue + 1; break;
            case 'Bake': newValue = oldValue * 3; break;
            case 'Fillet': newValue = oldValue * 0.80; break;
        }

        debugger;
        output.textContent = newValue.toString();
    }
}
