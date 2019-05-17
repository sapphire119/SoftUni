function cars(arrArgs) {
    //The possible commands are as follows: instructions, addPart and repair
    let carModels = [];

    let parts = {};

    for (let i = 0; i < arrArgs.length; i++) {
        let inputRow = arrArgs[i];

        let tokens = inputRow.split(/ /gi);
        let command = tokens[0];

        let restOfArgs = tokens.slice(1);

        switch (command) {
            case "instructions": carModels.push(restOfArgs[0]); break;
            case "addPart": storePart(parts, restOfArgs); break;
            case "repair": repairCar(carModels, parts, restOfArgs); break;
        }
    }

    function storePart(parts, restOfArgs) {
        let currentCarModel = restOfArgs[0];
        let partName = restOfArgs[1];
        let partSerialNumber = restOfArgs[2];

        if (!parts.hasOwnProperty(currentCarModel)) {
            parts[currentCarModel] = {
                [partName]: [partSerialNumber]
            };
        } else {
            if (!parts[currentCarModel].hasOwnProperty(partName)) {
                parts[currentCarModel][partName] = [partSerialNumber];
            } else {
                parts[currentCarModel][partName].push(partSerialNumber);
            }
        }
    }

    function repairCar(carModels, parts, restOfArgs) {
        let currentCarModel = restOfArgs[0];
        let part = JSON.parse(restOfArgs[1]);

        if (!carModels.includes(currentCarModel))  {
            console.log(`${currentCarModel} is not supported`);
        }
        else {
            for (let partName in part) {
                if (part[partName] === "broken" &&
                    parts.hasOwnProperty(currentCarModel) &&
                    parts[currentCarModel].hasOwnProperty(partName) &&
                    parts[currentCarModel][partName].length > 0) {

                    replacePart(currentCarModel, parts, partName, part);
                }
            }

            console.log(`${currentCarModel} client - ${JSON.stringify(part)}`);
        }
    }

    function replacePart(currentCarModel, parts, partName, part) {
        let partSerialNumber = parts[currentCarModel][partName].shift();
        part[partName] = partSerialNumber;
        // if (parts.hasOwnProperty(currentCarModel) && parts[currentCarModel].hasOwnProperty(partName)) {
        //
        // }
    }

    let orderedParts = {};
    Object.keys(parts).sort().forEach(function(key) {
        orderedParts[key] = parts[key];
    });

    if (parts){
        for (let key in orderedParts) {
            console.log(`${key} - ${JSON.stringify(orderedParts[key])}`);
        }
    }
}


// cars([
//         'repair mazda {"engine":"broken"}',
//         'instructions bmw',
//         'addPart opel engine GV1399SSS'
//     ]
// );
cars([
        'instructions bmw',
        'instructions bmw',
        'instructions bmw',
        'instructions bmw',
        'instructions bmw',
        'instructions bmw',
        'addPart bmw engine GV1399SSS',
        'repair bmw {"engine":"broken"}',
        // 'repair mazda {"engine":"broken"}',
        // 'addPart opel engine GV1399SSS'
    ]
);

//output
//mazda is not supported
// opel - {"engine":["GV1399SSS"]}

cars([

]);

// cars([
//         'instructions opel',
//         'addPart opel engine GV1399SSS',
//         'addPart opel transmission SMF556SRG',
//         'repair opel {"engine":"broken","transmission":"OP8766TRS"}',
//         'repair opel {"engine":"broken","transmission":"OP8766TRS"}',
//     ]
// );




//output
// opel client - {"engine":"GV1399SSS","transmission":"OP8766TRS"}
// bmw client - {"engine":"ENG999FPH","transmission":"SMF444ORG","wheels":"broken"}
// bmw - {"engine":["GV1399SSS"],"transmission":[]}
// opel - {"engine":[],"transmission":["SMF556SRG","SMF444ORG"]}