function result(inputNumber) {
    return (function() {
        let sum = 0;
        let add = function(inputNumber) {
            let currentNumber = Number(inputNumber);
            sum += currentNumber;
            return add;
        };
        add.toString = () => sum;
        return add(inputNumber);
    })();
}

console.log(result(1)(2)(3).toString());