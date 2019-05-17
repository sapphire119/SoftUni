function solve(fruitTypeArg,
     weightInGramsArg,
     pricePerKileArg) {
        if(typeof(fruitTypeArg) !== 'string' || typeof(weightInGramsArg) !== 'number' ||
        typeof(pricePerKileArg) !== 'number')
        {
            return console.log('Invalid input');
        }

        let fruitName = fruitTypeArg;
        let weightInKg = weightInGramsArg / 1000;
        let totalRequired = weightInKg * pricePerKileArg;
        
        console.log(`I need ${totalRequired.toFixed(2)} leva to buy ${weightInKg.toFixed(2)} kilograms ${fruitName}.`);
}