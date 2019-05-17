function solve() {
    let $rebuildButton = $("#kingdom > div > button");
    let $joinButton = $("#characters > div > button");
    let $attackButton = $("#actions > button");

    debugger;
    let validKingdomNames = ["CASTLE", "DUNGEON", "FORTRESS", "INFERNO", "NECROPOLIS", "RAMPART", "STRONGHOLD", "TOWER", "CONFLUX"];
    let validRoles = ["TANKS", "FIGHTERS", "MAGES"];

    function clearField($field) {
        $field.val("");
    }

    function giveCharacter(value) {
        return {
            "MAGES": {
                attack: 70,
                defenses: 30
            },
            "FIGHTERS": {
                attack: 50,
                defenses: 50
            },
            "TANKS": {
                attack: 20,
                defenses: 80
            }
        }[value];
    }

    function isKingdomValid(kingdomVal) {
        return validKingdomNames.indexOf(kingdomVal.toUpperCase());
    }

    function isRoleValid(role) {
        return validRoles.indexOf(role.toUpperCase());
    }

    $rebuildButton.on("click", function (e) {
        let $inputs = $("#kingdom > div > input:text");

        let $kingdom = $($inputs[0]);
        let $king = $($inputs[1]);
        debugger;
        if (typeof $king.val() === "string" && $king.val().length >= 2 &&
            isKingdomValid($kingdom.val()) >= 0) {
            let currentKingdom = $(`#${$kingdom.val().toLowerCase()}`);

            let $h1 = $("<h1>")
                .text($kingdom.val().toUpperCase());

            let $div = $("<div class='castle'></div>");

            let $h2 = $("<h2>")
                .text($king.val().toUpperCase());

            let $fieldSet = $("<fieldset>");
            $fieldSet.append($("<legend>Army</legend>"))
                .append($("<p>TANKS - 0</p>"))
                .append($("<p>FIGHTERS - 0</p>"))
                .append($("<p>MAGES - 0</p>"))
                .append($("<div class='armyOutput'></div>"));

            currentKingdom.append($h1);
            currentKingdom.append($div);
            currentKingdom.append($h2);
            currentKingdom.append($fieldSet);

            currentKingdom.css('display', 'inline-block');
        } else {
            clearField($kingdom);
            clearField($king);
        }
    });

    $joinButton.on("click", function (e) {
        let currentRadioButton = $('input[type=radio]:checked', '#characters');

        let $inputs = $("#characters > div:last-child > input:text");

        let $character = $($inputs[0]);
        let $kingdom = $($inputs[1]);

        let $currentKingdom = $(`#${$kingdom.val().toLowerCase()}`);

        let firstKingdomCondition = isKingdomValid($kingdom.val()) >= 0;
        let secondKingdomCond = $currentKingdom.css('display') === 'inline-block';

        if (currentRadioButton.length > 0 &&
            typeof $character.val() === "string" &&
            $character.val().length >= 2 &&
            firstKingdomCondition && secondKingdomCond) {
            //
            let $currentRadioButton = $(currentRadioButton);

            Array.from($currentKingdom.find("fieldset").find("p"))
                .forEach(p => {
                    let $element = $(p);
                    if (p.textContent.includes($currentRadioButton.val().toUpperCase())) {
                        let tokens = $element.text().split(/ - /);
                        $element.text(`${tokens[0]} - ${Number(tokens[1]) + 1}`);
                    }
                });

            let $army = $currentKingdom.find("fieldset").find(".armyOutput");
            $army.text((_, e) => `${$character.val()} ` + e);
            // let characters = $army.text().split(" ");
            // characters.push($character.val());
            // $army.text(characters.join(" "));
        } else {
            clearField($character);
            clearField($kingdom);
        }
    });

    $attackButton.on("click", function (e) {
        let $inputs = $("#actions > input");

        let $attacker = $($inputs[0]);
        let $defender = $($inputs[1]);

        if (isKingdomValid($attacker.val()) >= 0 && isKingdomValid($defender.val()) >= 0) {
            let $attackingKingdom = $(`#${$attacker.val().toLowerCase()}`);
            let $defendingKingdom = $(`#${$defender.val().toLowerCase()}`);

            let attackKingdomCondition = $attackingKingdom.css('display') === 'inline-block';
            let defendingKingdomCondition = $defendingKingdom.css('display') === 'inline-block';

            if (attackKingdomCondition && defendingKingdomCondition) {
                let totalAttack = 0;
                Array.from($attackingKingdom.find("fieldset").find("p"))
                    .forEach(p => {
                        let $element = $(p);
                        let tokens = $element.text().split(/ - /);

                        let numberOfCharacters = Number(tokens[1]);
                        let attributes = giveCharacter(tokens[0]);

                        totalAttack += attributes.attack * numberOfCharacters;
                    });

                let totalDefense = 0;
                Array.from($defendingKingdom.find("fieldset").find("p"))
                    .forEach(p => {
                        let $element = $(p);
                        let tokens = $element.text().split(/ - /);

                        let numberOfCharacters = Number(tokens[1]);
                        let attributes = giveCharacter(tokens[0]);

                        totalDefense += attributes.defenses * numberOfCharacters;
                    });

                if (totalAttack > totalDefense) {
                    debugger;
                    let attackingKing = $attackingKingdom.find("h2").text();
                    $defendingKingdom.find("h2").text(attackingKing);
                }
            } else {
                clearField($attacker);
                clearField($defender);
            }
        } else {
            clearField($attacker);
            clearField($defender);
        }
    });
}