function solve(inputObjs) {
    let townsByProfit = [];
    let index = 0;
    inputObjs.forEach(obj => {
        let currentTown = obj["town"];
        let currentPrice = obj["price"];
        // let currentModel = obj["model"];

        if (!townsByProfit.some(e => e["name"] === currentTown)) {
            let tempObj = {
                name: currentTown,
                price: currentPrice,
                // models: []
            };

            townsByProfit.push(tempObj);
        } else {
            for (let i = 0; i < townsByProfit.length; i++) {
                let townsByProfitElement = townsByProfit[i]["name"];
                if (townsByProfitElement === currentTown) {
                    townsByProfit[i].price += currentPrice;
                    break;
                }
                debugger;
            }
        }

    });

    debugger;
}

solve([ { model: 'BMW', regNumber: 'B1234SM', town: 'Varna', price: 2},
    { model: 'BMW', regNumber: 'C5959CZ', town: 'Sofia', price: 8},
    { model: 'Tesla', regNumber: 'NIKOLA', town: 'Burgas', price: 9},
    { model: 'BMW', regNumber: 'A3423SM', town: 'Varna', price: 3},
    { model: 'Lada', regNumber: 'SJSCA', town: 'Sofia', price: 3} ]
);