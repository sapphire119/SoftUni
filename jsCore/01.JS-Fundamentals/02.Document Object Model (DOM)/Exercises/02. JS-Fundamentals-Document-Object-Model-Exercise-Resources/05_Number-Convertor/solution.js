function solve() {
    let selectTag = document.getElementById('selectMenuTo');
    selectTag.children[0].value = 'binary';
    selectTag.children[0].textContent = 'Binary';

    let hexOption = document.createElement('option');
    hexOption.value = 'hexadecimal';
    hexOption.textContent = 'Hexadecimal';

    selectTag.appendChild(hexOption);

    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', e => handler(e,selectTag));

    function handler(e,selectTag) {
        debugger;
        let selectedValue = selectTag.options[selectTag.selectedIndex].value;

        let input = document.getElementById('input').value;
        let element = "";
        if (selectedValue === 'hexadecimal') {
            element = Number(input).toString(16).toUpperCase();
        } else if(selectedValue === 'binary'){
            element = Number(input).toString(2);
        }

        let result = document.getElementById('result');
        result.value = element;
    }
}