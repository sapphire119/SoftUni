function solve() {

    let cards = Array.from(document.getElementsByTagName('img')).forEach((img) => {
        img.addEventListener('click', clickEvent)
    });

    function clickEvent(event) {
        let card = event.target;
        card.src = "./images/whiteCard.jpg";

        let parent = card.parentNode;
        let parentName = parent.id;

        let result = document.getElementById('result');
        if (parentName === 'player1Div') {
            result.children[0].textContent = `${card.getAttribute('name')}`;
        } else if (parentName === 'player2Div'){
            result.children[2].textContent = `${card.getAttribute('name')}`;
        }

        if(result.children[0].innerHTML  !== '' && result.children[2].innerHTML !== ''){
            let firstCard = Number(result.children[0].innerHTML);
            let secondCard = Number(result.children[2].innerHTML);

            let winner;
            let loser;

            if(firstCard > secondCard){
                winner = document.querySelector(`#player1Div img[name='${firstCard}']`);
                loser = document.querySelector(`#player2Div img[name='${secondCard}']`);
            } else {
                winner = document.querySelector(`#player2Div img[name='${secondCard}']`);
                loser = document.querySelector(`#player1Div img[name='${firstCard}']`);
            }
            debugger;
            winner.style.border = '2px solid green';
            loser.style.border = '2px solid darkred';


            result.children[0].innerHTML = '';
            result.children[2].innerHTML = '';

            let output = document.getElementById('history');
            output.innerHTML += `[${firstCard} vs ${secondCard}] `;

        }
    }
}