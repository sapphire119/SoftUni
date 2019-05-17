function printDeckOfCards(cards) {
    function makeCard(face, suit) {
        let invalidCardMessage = `Invalid card: ${face}${suit}`;

        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        };

        if (validFaces.indexOf(face) < 0) {
            throw Error(invalidCardMessage);
        }

        if (!validSuits[suit]) {
            throw Error(invalidCardMessage);
        }

        let card = {
            face: face,
            suit: validSuits[suit],
            toString: function () {
                return this.face + this.suit;
            }
        };

        return card;
    }

    if (!Array.isArray(cards)) {
        throw Error("Error");
    }

    if (!cards.every(e => typeof e === "string") || !(cards.length > 0)){
        throw Error("Error");
    }

    try {
        let result = [];
        for (const currentCard of cards) {
            let face = currentCard.substr(0, currentCard.length - 1);
            let suit = currentCard.substr(currentCard.length - 1);
            result.push(makeCard(face, suit));
        }
        return console.log(result.join(" "));
    } catch (ex) {
        return console.log(ex.message);
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);
