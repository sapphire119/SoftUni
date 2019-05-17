function solve(inputObj) {
    if (inputObj.handsShaking === true) {
        let currentBloodAlcoholLevelToAdd = inputObj.weight * inputObj.experience * 0.1;
        inputObj.bloodAlcoholLevel += currentBloodAlcoholLevelToAdd;
        inputObj.handsShaking = false;
    }

    return inputObj;
}

console.log(solve({
        weight: 80,
        experience: 1,
        bloodAlcoholLevel: 0,
        handsShaking: true
    }
));

console.log(solve({
        weight: 120,
        experience: 20,
        bloodAlcoholLevel: 200,
        handsShaking: true
    }
));

console.log(solve({
        weight: 95,
        experience: 3,
        bloodAlcoholLevel: 0,
        handsShaking: false
    }
));