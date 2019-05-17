function solve() {
    let rightAnswers = { softUniYear: "2013", popularName: "Pesho", softUniFounder: "Nakov" };

    let myAnswers = { softUniYear: "", popularName: "", softUniFounder: "" };

    let sections = Array.from(document.getElementsByTagName('section')).forEach((sec) => {
        let button = Array.from(sec.getElementsByTagName('button'))[0];
        button.addEventListener('click', e => clickEvent(e, sec));
    });

    function clickEvent(event, section) {
        let currentButton = event.target;
        let parentEle = currentButton.parentElement;

        let selectedInputArr = Array.from(parentEle.getElementsByTagName('input')).filter((inp) => inp.checked);
        if (selectedInputArr.length > 0) {
            let inputName = selectedInputArr[0].name;
            let inputValue = selectedInputArr[0].value;

            myAnswers[inputName] = inputValue;

            // if(rightAnswers[inputName] === inputValue) rightAnswersCount++;
        }

        let nextSection = section.nextElementSibling;
        if (nextSection !== null && nextSection.tagName === 'SECTION'){
            nextSection.classList.remove('hidden');

            // nextSection.style.display = 'block';
        } else {
            let output = document.getElementById('result');
            let rightAnswersCount = 0;

            for(let category in myAnswers){
                if(myAnswers[category] === rightAnswers[category]){
                    rightAnswersCount++
                }
            }
            debugger;
            rightAnswersCount === 3 ?
                output.innerHTML = `You are recognized as top SoftUni fan!` :
                output.innerHTML = `You have ${rightAnswersCount} right answers`;
        }
        // let newButton = currentButton.cloneNode(true);
        // currentButton.parentNode.replaceChild(newButton, currentButton);
    }
}