function solve(arrArgm){
    let products = {
        'coffee': 0.80,
        'tea': 0.80
    };

    let modifiers = {
        'decaf' : 0.10,
        'caffeine': 0,
    };

    function milkFunc(productArg){
        let unformattedPrice = products[productArg] * 0.10;
        let milkPrice = round(unformattedPrice, 1);
        return milkPrice;
    }

    function round(value, precision) {
        var multiplier = Math.pow(10, precision || 0);
        return Math.round(value * multiplier) / multiplier;
    }


    let totalMoneyEarned = 0;
    for(let element of arrArgm){
        let currentElementsArgs = element.split(', ');

        let currentAvaibleFunds = Number(currentElementsArgs[0]);

        let moneyRequired = 0;

        let drinkType = currentElementsArgs[1];

        let sugarAmount = Number(currentElementsArgs[currentElementsArgs.length - 1]) === 0 ? 0 : 0.10;

        let milkArg = currentElementsArgs[currentElementsArgs.length - 2];
        let milkPrice = 0;
        let modifiersPrice = 0;
        
        if(milkArg === 'milk') {
            milkPrice += milkFunc(drinkType);
        };

        if(drinkType === 'coffee'){
            let coffeeModififer = currentElementsArgs[2];
            modifiersPrice += modifiers[coffeeModififer];
        }

        moneyRequired += (products[drinkType] + modifiersPrice + milkPrice + sugarAmount);

        let diffrence = currentAvaibleFunds - moneyRequired;
        if(diffrence >= 0){
            console.log(`You ordered ${drinkType}. Price: ${moneyRequired.toFixed(2)}$ Change: ${diffrence.toFixed(2)}$`);
            totalMoneyEarned += moneyRequired;
        } else{
            console.log(`Not enough money for ${drinkType}. Need ${Math.abs(diffrence).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalMoneyEarned.toFixed(2)}$`);
}