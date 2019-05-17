function solve() {
    let buttons = Array.from(document.getElementsByTagName('button')).forEach((button) => {
            button.addEventListener('click', clickEvent);
        });

    function clickEvent(event) {
        let currentButton = event.target.name;

        let span = document.createElement('span');
        let parag = document.createElement('p');

        let chronology = document.getElementById('chatChronology');

        let result = document.createElement('div');
        debugger;
        if (currentButton === 'myBtn') {
            let myChatBox = document.getElementById('myChatBox');

            span.textContent += `Me`;
            parag.textContent += `${myChatBox.value}`;

            myChatBox.value = '';

        } else if (currentButton === 'peshoBtn') {
            let peshoChatBox = document.getElementById('peshoChatBox');

            span.textContent += `Pesho`;
            parag.textContent += `${peshoChatBox.value}`;

            peshoChatBox.value = '';
        }

        result.appendChild(span);
        result.appendChild(parag);

        currentButton === 'myBtn' ? result.style.textAlign = 'left' : result.style.textAlign = 'right';

        chronology.appendChild(result);
    }
}