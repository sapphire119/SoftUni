function solve() {
    let objs = [{}];
    let index = 0;
    debugger;

    Array.from(document.querySelectorAll(".product")).forEach(prod => {
        prod.children[prod.children.length - 1].addEventListener('click', e => clickEvent(e, objs));
    });

    function clickEvent(event, objs) {
        let parent = event.target.parentNode;

        let parags = Array.from(parent.children).slice(1);
        parags = parags.slice(0, parags.length - 1);

        let productName = parags[0].textContent;

        let productPrice = parags[1].textContent.split(" ").filter(e => e !== "")[1];

        let currentProduct = {
            productName: productName,
            price: Number(productPrice)
        };
        objs[index++] = currentProduct;

        document.querySelector("textarea").value += `Added ${productName} for ${productPrice} to the cart.` + "\n";
    }

    let buttons = Array.from(document.querySelectorAll("button"));
    let buyButton = buttons[buttons.length - 1];
    buyButton.addEventListener('click', buyProducts);
    
    function buyProducts(event) {
        let totalPrice = objs.map(e => e.price).reduce((a, b) => a + b).toFixed(2); //Round to second digit
        let uniqueElements = [...new Set(objs.map(e => e.productName))].join(", ");

        document.querySelector("textarea").value += `You bought ${uniqueElements} for ${totalPrice}.\n`;
        debugger;
    }
}