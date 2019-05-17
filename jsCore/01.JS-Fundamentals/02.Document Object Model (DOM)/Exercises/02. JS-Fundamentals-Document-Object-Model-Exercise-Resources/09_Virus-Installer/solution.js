function solve() {
    let selectedElemIndex = -1;

    let section = document.getElementsByTagName('section')[0];

    let buttons = Array.from(document.querySelectorAll('#buttons button')).forEach((btn) => {
        btn.addEventListener('click', clickEvent);
    });

    function clickEvent(event) {
        let currentButton = event.target;

        let content = document.getElementById('content');

        let currentChild = content.children[selectedElemIndex];
        debugger;

        switch (currentButton.innerHTML){
            case 'Next':
                if (selectedElemIndex === -1){
                    content.style.backgroundImage = 'none';
                    content.children[0].style.display = 'block';
                    selectedElemIndex++;
                    break;
                }
                switch(currentChild.id){
                    case 'firstStep':
                        let selectedInput = Array.from(currentChild.getElementsByTagName('input')).filter((inp) => inp.checked)[0];

                        let selectedInputName = selectedInput.name;
                        let selectedInputValue = selectedInput.value;

                        if (selectedInputName === 'license' && selectedInputValue === 'agree') {
                            currentChild.style.display = 'none';
                            content.children[selectedElemIndex + 1].style.display = 'block';
                            currentButton.setAttribute('hidden','');
                            setTimeout(function () {
                                currentButton.removeAttribute('hidden');
                            }, (3000));
                            selectedElemIndex++;
                        }
                        break;
                    case 'secondStep':
                        currentChild.style.display = 'none';
                        content.children[selectedElemIndex + 1].style.display = 'inline-block';
                        let nextBtn = currentButton.nextElementSibling;
                        nextBtn.setAttribute('hidden', '');
                        currentButton.innerHTML = 'Finished';
                        selectedElemIndex++;
                        break;
                }
                break;
            case 'Cancel':
            case 'Finished':
                section.setAttribute('hidden', '');
                break;
        }
    }
}