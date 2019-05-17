function solve() {
    let inputField = Array.from(document.getElementsByTagName('input')).forEach((inp) => {
        inp.addEventListener('click', clickEvent);
    });

    function clickEvent(event) {
        let radioButton = event.target;

        let radioButtonName = radioButton.name;
        let radioButtonValue = radioButton.value;

        let user = radioButtonName.substring(0, radioButtonName.length - 6);
        let hiddenElement = document.getElementById(`${user}HiddenFields`);
        let button = hiddenElement.nextElementSibling;

        if(radioButtonValue === 'lock'){
            debugger;
            let newButton = button.cloneNode(true);
            button.parentNode.replaceChild(newButton, button);
        } else if (radioButtonValue === 'unlock'){
            button.addEventListener('click', e => toggle(e, hiddenElement));
        }
    }

    function toggle(event, elementToExpand) {
        let currentButton = event.target;
        if(currentButton.textContent === 'Show more'){
            elementToExpand.style.display = 'inline';
            currentButton.textContent = 'Hide it';
        } else{
            elementToExpand.style.display = 'none';
            currentButton.textContent = 'Show more';
        }
    }
} 