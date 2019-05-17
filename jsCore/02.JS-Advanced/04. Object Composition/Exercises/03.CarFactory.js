function solve(inputCar) {
    let engineStorage = {
        small: {power: 90, volume: 1800},
        normal: { power: 120, volume: 2400 },
        monster: { power: 200, volume: 3500 }
    };

    let carriageStorage = {
        hatchback: { type: 'hatchback', color: ""},
        coupe: { type: 'coupe', color: ""}
    };

    let outputObj = {};
    //model
    outputObj.model = inputCar.model;
    //engine
    if (inputCar.power <= 90) outputObj.engine = engineStorage.small;
    else if (90 < inputCar.power && inputCar.power <= 120) outputObj.engine = engineStorage.normal;
    else outputObj.engine = engineStorage.monster;
    //carriage
    if (carriageStorage[inputCar.carriage]) {
        outputObj.carriage = carriageStorage[inputCar.carriage];
        outputObj.carriage.color = inputCar.color;
    }

    let roundOddNumber = inputCar.wheelsize;
    if (roundOddNumber % 2 === 0) {
        roundOddNumber = 2 * Math.floor(inputCar.wheelsize / 2) - 1;
    }
    outputObj.wheels = [];
    for (let i = 0; i < 4; i++) { outputObj.wheels.push(roundOddNumber); }

    return outputObj;
}

console.log(solve({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));

console.log(solve({
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
));