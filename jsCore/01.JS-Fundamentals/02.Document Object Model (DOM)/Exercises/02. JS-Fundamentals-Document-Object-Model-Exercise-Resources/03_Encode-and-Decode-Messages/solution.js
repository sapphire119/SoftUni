function solve() {
    let buttons = Array.from(document.getElementsByTagName('button')).forEach((btn) => {
        btn.addEventListener('click', (e) => clickEvent(btn, e));
    });

    function clickEvent(btn, event) {
        let buttons = Array.from(document.getElementsByTagName('button'));
        let textAreas = Array.from(document.getElementsByTagName('textarea'));

        if (btn.innerHTML === buttons[0].innerHTML){
            let valueToEncode = textAreas[0].value;
            let encodedString = "";
            debugger;
            for (let i = 0; i < valueToEncode.length; i++){
                let chCode = valueToEncode[i].charCodeAt(0) + 1;
                encodedString += `${String.fromCharCode(chCode)}`;
            }
            textAreas[0].value = "";
            textAreas[1].value = encodedString;

            debugger;
        } else {
            let valueToDecode = textAreas[1].value;
            let decodedString = "";
            for (let i = 0; i < valueToDecode.length; i++){
                let chCode = valueToDecode[i].charCodeAt(0) - 1;
                decodedString += `${String.fromCharCode(chCode)}`;
            }

            textAreas[1].value = "";
            textAreas[1].value = decodedString;
            debugger;
        }
    }
}