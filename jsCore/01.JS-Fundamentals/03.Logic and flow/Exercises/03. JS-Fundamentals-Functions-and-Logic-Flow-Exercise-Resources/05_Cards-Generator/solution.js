function solve() {
    let cards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = {
        'Hearts': "&hearts;",
        'Diamonds': "&diamond;",
        'Spades': "&spades;",
        'Clubs': "&clubs;"
    };

    function returnIndexOfCard(card) {
        return cards.indexOf(card);
    }

    let button = document.querySelector('#exercise button');

    button.addEventListener('click', clickEvent);

    function clickEvent(event) {
        let fromInput = document.getElementById('from');
        let fromInputValue = fromInput.value;

        let selectInput = document.querySelector('#exercise select');
        let selectInputText = selectInput.options[selectInput.selectedIndex].text;

        let selectTokens = selectInputText.split(' ');
        let suitInput = selectTokens[0];

        let toInput = document.getElementById('to');
        let toInputValue = toInput.value;

        debugger;
        let startingIndex = returnIndexOfCard(fromInputValue);
        let endingIndex = returnIndexOfCard(toInputValue);

        let output = document.getElementById('cards');


        for (let i = startingIndex; i <= endingIndex; i++) {
            let div = document.createElement('div');
            div.classList.add('card');

            let p1 = document.createElement('p');
            let p2 = document.createElement('p');
            let p3 = document.createElement('p');

            p1.innerHTML = suits[suitInput];
            p2.innerHTML = cards[i];
            p3.innerHTML = suits[suitInput];

            div.appendChild(p1);
            div.appendChild(p2);
            div.appendChild(p3);

            output.appendChild(div);
        }
    }
}