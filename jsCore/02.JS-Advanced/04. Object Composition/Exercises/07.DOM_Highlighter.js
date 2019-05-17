function solve(selector) {
    let element = document.querySelector(selector);
    if (element.children.length > 0) {
        let currentNodeElement;
        let maxDepth = -1;

        function findLastChild(currentElement) {
            //array
            if (currentElement.children.length > 0) {
                for (let i = 0; i < currentElement.children.length; i++) {
                    let currentElementChild = currentElement.children[i];
                    findLastChild(currentElementChild);
                }
            } else {
                let currentDepth = 0;
                let ele = currentElement;
                while (ele !== element) {
                    currentDepth++;
                    ele = ele.parentNode;
                }
                if (maxDepth < currentDepth) {
                    maxDepth = currentDepth;
                    currentNodeElement = currentElement;
                }
            }
        }

        findLastChild(element);
        debugger;
        while (currentNodeElement !== element.parentNode) {
            currentNodeElement.classList.add("highlight");
            currentNodeElement = currentNodeElement.parentNode;
        }

    } else {
        element.classList.add("highlight");
    }
}