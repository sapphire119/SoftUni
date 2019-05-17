function solve() {
    return (function () {
        let productCosts = {
            apple: {
                carbohydrate: 1,
                flavour: 2
            },
            coke: {
                carbohydrate: 10,
                flavour: 20
            },
            burger: {
                carbohydrate: 5,
                fat: 7,
                flavour: 3,
            },
            omelet: {
                protein: 5,
                fat: 1,
                flavour: 1
            },
            cheverme: {
                protein: 10,
                carbohydrate: 10,
                fat: 10,
                flavour: 10
            },
        };

        let avaibleSupply = {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0
        };

        return function (input) {
            let tokens = input.split(" ").filter(e => e !== "");
            let currentCommand = tokens[0];

            switch (currentCommand) {
                case "restock":
                    let typeSupply = tokens[1];
                    let supplyQuantity = Number(tokens[2]);
                    avaibleSupply[typeSupply] += supplyQuantity;
                    return "Success";
                case "prepare":
                    debugger;
                    let ingredientToPrepare = tokens[1];
                    let quantityToPreapre = Number(tokens[2]);

                    let currentProductReq = productCosts[ingredientToPrepare];

                    for (let key in currentProductReq) {
                        let currentSupply = avaibleSupply[key];
                        let currentRequiredSupply = currentProductReq[key] * quantityToPreapre;

                        if (currentRequiredSupply > currentSupply) {
                            return `Error: not enough ${key} in stock`;
                        }
                    }

                    for (let key in currentProductReq) {
                        avaibleSupply[key] -= (currentProductReq[key] * quantityToPreapre);
                    }

                    return `Success`;
                case "report":
                    return `protein=${avaibleSupply.protein} carbohydrate=${avaibleSupply.carbohydrate} fat=${avaibleSupply.fat} flavour=${avaibleSupply.flavour}`;
            }
        };
    })();
}

let manager = solve();
//Demo
// manager("restock flavour 2"); // Success
// manager("restock carbohydrate 1"); // Success
// manager("prepare apple 1");

//first
// console.log(manager("restock carbohydrate 10"));
// console.log(manager("restock flavour 10"));
// console.log(manager("prepare apple 1"));;
// console.log(manager("restock fat 10"));;
// console.log(manager("prepare burger 1"));;
// console.log(manager("report"));;
//second
console.log(manager("prepare cheverme 1"));
console.log(manager("restock protein 10"));
console.log(manager("prepare cheverme 1"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("prepare cheverme 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare cheverme 1"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare cheverme 1"));
console.log(manager("report"));
