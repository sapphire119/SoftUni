function solve() {
    let buttons = Array.from(document.getElementsByTagName("button")).forEach(btn => {
        btn.addEventListener('click', clickEvent);
    });

    function clickEvent(event) {
        let currentButton = event.target;
        switch (currentButton.innerHTML) {
            case "Generate": generateFunc(currentButton); break;
            case "Buy": buyFunc(currentButton); break;
        }
    }

    function generateFunc(currentButton) {
        let areas = Array.from(document.getElementsByTagName("textarea"));
        let generationArea = JSON.parse(areas[0].value);

        let divList = document.getElementById('furniture-list');
        debugger;

        generationArea.forEach(obj => {
            debugger;
            let div = document.createElement('div');
            // for (let property in obj) {
            //     debugger;
            //     let p = document.createElement('p');
            //     if (property !== "img"){
            //         let message = `${property.substr(0,1).toUpperCase().concat(property.substr(1))}: ${obj[property]}`;
            //         p.innerHTML = message;
            //         div.appendChild(p);
            //     } else {
            //         let img = document.createElement("img");
            //         img.src = obj[property];
            //         div.appendChild(img);
            //     }
            // }

            let pName = document.createElement('p');
            pName.innerHTML = `Name: ${obj["name"]}`;
            div.appendChild(pName);

            let img = document.createElement("img");
            if (obj.hasOwnProperty("img")) {
                img.src = obj["img"];
                div.appendChild(img);
            }

            let pPrice = pName.cloneNode();
            pPrice.innerHTML = `Price: ${obj["price"]}`;
            div.appendChild(pPrice);

            let pDecFactr = pName.cloneNode();
            pDecFactr.innerHTML = `Decoration factor: ${obj["decFactor"]}`;
            div.appendChild(pDecFactr);

            let input = document.createElement('input');
            input.type = "checkbox";
            div.appendChild(input);

            div.classList.add("furniture");

            divList.appendChild(div);
        })
    }

    function buyFunc(currentButton) {
        let checkedInputs = Array.from(document.querySelectorAll("input")).filter(e => e.checked);

        let checkedObjs = [{}];
        let index = 0;
        checkedInputs.forEach(inp => {
            let currentObj = {};

            let parent = inp.parentNode;
            let children = Array.from(parent.children);
            debugger;
            let parags = children.filter(p => p.localName === "p").map(e => e.innerHTML);
            parags.forEach(p => {
               let tokens = p.split(/[\:]/g).filter(e => e !== "").map(e => e.trim());
               let key = tokens[0].toLowerCase();
               let value = tokens[1];
               if (!isNaN(value)) currentObj[key] = Number(value);
                else currentObj[key] = value;
            });
            checkedObjs[index++] = currentObj;
        });

        let areas = Array.from(document.getElementsByTagName("textarea"));
        let outputArea = areas[1];

        let furnitureNames = checkedObjs.map(e => e["name"]).join(", ");
        let totalPrice = checkedObjs.map(e => e["price"]).reduce((a, b) => a + b).toFixed(2);
        let decFactorLength = checkedObjs.map(e => e["decoration factor"]);

        let averageDecFactor = decFactorLength.map(Number).reduce((a, b) => a + b) / decFactorLength.length;
        debugger;

        outputArea.value += `Bought furniture: ${furnitureNames}\n`;
        outputArea.value += `Total price: ${totalPrice}\n`;
        outputArea.value += `Average decoration factor: ${averageDecFactor}`;
        debugger;
    }
}