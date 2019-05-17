(function () {
    Array.prototype.last = function () {
        let lastElement = this.pop();
        this.push(lastElement);
        return lastElement;
    };

    Array.prototype.skip = function (n) {
        return this.slice(n);
    };

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    };

    Array.prototype.sum = function () {
        return this.reduce((acc, val) => acc += val, 0);
    };

    Array.prototype.average = function () {
        let sum = this.sum();
        let average = sum / this.length;
        return average;
    };
})();

let test = [1,2,3,4,5];
console.log(test.average());