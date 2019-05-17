function solve() {
    let firstValBtn;
    let secondValBtn;
    let resultBtn;

    return {
        init: function (selector1, selector2, resultSelector) {
            debugger;
            firstValBtn = document.querySelector(selector1);
            secondValBtn = document.querySelector(selector2);
            resultBtn = document.querySelector(resultSelector);
            debugger;
        },
        add: function (event) {
            debugger;
            let firstElemVal = Number(firstValBtn.value);
            let secondElemVal = Number(secondValBtn.value);
            let result = firstElemVal + secondElemVal;

            resultBtn.value = result;
            debugger;
        },
        subtract: function (event) {
            debugger;
            let firstElemVal = Number(firstValBtn.value);
            let secondElemVal = Number(secondValBtn.value);
            let result = firstElemVal - secondElemVal;

            resultBtn.value = result;
            debugger;
        }
    }
}