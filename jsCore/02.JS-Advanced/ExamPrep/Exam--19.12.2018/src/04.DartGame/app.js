function dart(){
    let colourTable = {
        "firstLayer": 0,
        "secondLayer": 1,
        "thirdLayer": 2,
        "fourthLayer": 3,
        "fifthLayer": 4,
        "sixthLayer": 5
    };

    let $playBoard = $("#playBoard");

    $playBoard.on("click", "div", clickEvent);

    let scoreTable = Array.from($("tbody > tr > td:nth-child(2)"))
        .map(e => e.textContent)
        .map(e => Number(e.split(" ")[0]));

    let $turns = $("#turns");

    let isHome = true;
    function clickEvent(e) {
        e.stopPropagation();
        let currentTargetLayer = e.target.id;
        let currentTurn = giveStrRepresentOfTurn(isHome);

        let $currentPlayer = $(`#${currentTurn}`);

        let pointsScored = scoreTable[colourTable[currentTargetLayer]];

        //TODO: Check for end condition either points >= 100
        $currentPlayer.find("p").eq(0).text((_, e) => Number(e) + pointsScored);

        checkIfPlayerHasWon($currentPlayer, isHome);

        isHome = !isHome;
        //switchCurrentPlayer
        switchTurn(isHome);
    }

    function checkIfPlayerHasWon($currentPlayer, isHome) {
        let currentPlayerPoints = Number($currentPlayer.find("p").eq(0).text());
        if (currentPlayerPoints >= 100) {
            let $otherPlayer = $(`#${giveStrRepresentOfTurn(!isHome)}`);

            $currentPlayer.find("p").eq(1).css('background-color', 'green');
            $otherPlayer.find("p").eq(1).css('background-color', 'red');

            $playBoard.off();
        }
            // .off("click", "div", clickEvent);
    }

    function switchTurn(isHome) {
        let $parags = $turns.children();
        $parags.eq(0).text(`Turn on ${giveStrRepresentOfTurn(isHome)}`);
        $parags.eq(1).text(`Next is ${giveStrRepresentOfTurn(!isHome)}`);
    }

    function giveStrRepresentOfTurn(isHome) {
        return isHome ? "Home" : "Away";
    }
}