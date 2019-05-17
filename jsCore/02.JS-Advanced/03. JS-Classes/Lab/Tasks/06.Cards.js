let result = (function(){
    let Suits = {
        SPADES: "♠",
        HEARTS: "♥",
        DIAMONDS: "♦",
        CLUBS: "♣",
    };

    class Card{
        constructor(face, suit){
            this.face = face;
            this.suit = suit;
        }

        get suit() {
            return this._suit;
        }

        set suit(value) {
            let isThereAValueSuit = Object.keys(Suits).some(key => Suits[key] === value);
            if (!isThereAValueSuit) {
                throw new Error();
            }
            this._suit = value;
        }

        get face() {
            return this._face
        }

        set face(value){
            if (["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"].indexOf(value) < 0){
                throw new Error();
            }
            this._face = value;
        }
    }

    return {
        Suits:Suits,
        Card:Card
    }
}());

let Card = result.Card;
let Suits = result.Suits;

let card = new Card("Q", Suits.CLUBS);
card.face = "A";
card.suit = Suits.DIAMONDS;
let card2 = new Card("1", Suits.DIAMONDS);