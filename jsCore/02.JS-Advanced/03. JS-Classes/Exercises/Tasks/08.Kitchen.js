class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(productArr) {
        for (let i = 0; i < productArr.length; i++) {
            const currentProduct = productArr[i];
            let [productName, productQuantity, productPrice] = currentProduct.split(" ");

            let currentCost = Number(productPrice);
            if (this.budget - currentCost >= 0) {
                this.budget -= currentCost;
                if (!this.productsInStock.hasOwnProperty(productName)) {
                    this.productsInStock[productName] = {
                        quantity: Number(productQuantity)
                    };
                } else {
                    this.productsInStock[productName]["quantity"] += Number(productQuantity);
                }
                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }
    }

    addToMenu(meal, neededProductsArr, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            let currentProducts = {};
            for (let i = 0; i < neededProductsArr.length; i++) {
                const currentProduct = neededProductsArr[i];
                let tokens = currentProduct.split(" ");

                let productName = tokens[0];
                let productQuantity = Number(tokens[1]);
                currentProducts[productName] = productQuantity;
            }

            this.menu[meal] = {
                products: currentProducts,
                price: Number(price)
            };
            this.actionsHistory.push(`Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`);
        } else {
            this.actionsHistory.push(` The ${meal} is already in our menu, try something different.`);
        }
    }

    showTheMenu(){
        let output = "";
        if (Object.entries(this.menu).length > 0) {
            for (let menuItem in this.menu) {
                this.actionsHistory.push(`${menuItem} - $ ${this.menu[menuItem]["price"]}`);
            }
        } else {
            this.actionsHistory.push(`Our menu is not ready yet, please come later...`);
        }
    }

    makeTheOrder(meal) {
        if (this.menu.hasOwnProperty(meal)) {
            let currentMenuProducts = this.menu[meal]["products"];

            let areAllProductsInStock = true;
            for (let mealProduct in currentMenuProducts) {
                if (!this.productsInStock.hasOwnProperty(mealProduct)) {
                    this.actionsHistory.push(`For the time being, we cannot complete your order (${meal}), we are very sorry...`);
                    areAllProductsInStock = false;
                    break;
                    // this.productsInStock[mealProduct]["quantity"] -= currentMenuProducts[mealProduct];
                }
            }
            if (areAllProductsInStock) {
                for (let mealProduct in currentMenuProducts) {
                    this.productsInStock[mealProduct]["quantity"] -= currentMenuProducts[mealProduct];
                }
                this.budget += this.menu[meal]["price"];
                this.actionsHistory.push(`Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal]["price"]}.`);
            }
        } else {
            this.actionsHistory.push(`There is not ${meal} yet in our menu, do you want to order something else?`);
        }
    }
}

let test = new Kitchen(5000);

test.loadProducts(['Yogurt 100 1', 'Honey 100 1', 'Banana 100 1', 'Strawberries 100 1']);

test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
test.showTheMenu();
test.makeTheOrder("frozenYogurt");
// console.log(test.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
