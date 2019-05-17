function solve() {
    let buttons = Array.from(document.getElementsByTagName("button"));

    buttons.forEach(btn => {
        btn.addEventListener("click", clickEvent);
    });

    let objs = [{}];
    let totalProfit = 0;
    function clickEvent(event) {
        let currentButton = event.target;

        let log = Array.from(document.getElementsByTagName("textarea"))[2];
        switch (currentButton.textContent) {
            case "Load": loadFunc(currentButton, log); break;
            case "Buy": buyFunc(currentButton, log); break;
            case "End Day": endDayFunc(currentButton, log); break;
        }
    }

    function loadFunc(currentButton, log) {
        let loadArea = Array.from(document.getElementsByTagName("textArea"))[0];

        let loadAreaValues = JSON.parse(loadArea.value);
        let index = 0;
        for (let product of loadAreaValues) {
            if (objs.some(e => e["name"] === product["name"])) {
                let indexOfCurrentProd = objs.findIndex(value => value["name"] === product["name"]);
                let currentObj = objs[indexOfCurrentProd];
                currentObj["quantity"] += product["quantity"];
                currentObj["price"] = product["price"];
            } else {
                objs[index++] = product;
            }

            log.innerHTML += `Successfully added ${product["quantity"]} ${product["name"]}. Price: ${product["price"]}\n`;
        }

        debugger;
    }
    
    function buyFunc(currentButton, log) {
        let buyArea = Array.from(document.getElementsByTagName("textArea"))[1];

        let objToBuy = JSON.parse(buyArea.value);
        let currentIndex = objs.findIndex(e => e["name"] === objToBuy["name"]);
        debugger;
        if (currentIndex >= 0) {
            let currentProduct = objs[currentIndex];
            if (currentProduct["quantity"] >= objToBuy["quantity"] && currentProduct["quantity"] !== 0){
                currentProduct["quantity"] -= objToBuy["quantity"];
                let orderTotal = objToBuy["quantity"] * currentProduct["price"];
                totalProfit += orderTotal;

                log.innerHTML += `${objToBuy["quantity"]} ${objToBuy["name"]} sold for ${orderTotal}.\n`;
                return;
            }
        }

        log.innerHTML += `Cannot complete order.\n`;
    }
    
    function endDayFunc(currentButton, log) {
        log.innerHTML += `Profit: ${totalProfit.toFixed(2)}.\n`;

        let oldElements = Array.from(document.getElementsByTagName("button"));
        let newElements = oldElements.map(e => e.cloneNode(true));
        oldElements.map((e, i) => e.parentNode.replaceChild(newElements[i], e));
    }
}