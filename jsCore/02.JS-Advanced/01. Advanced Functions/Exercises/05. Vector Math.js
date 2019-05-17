(function result() {
    let obj = {};
    obj.add = (firstArr, secondArr) => [firstArr[0] + secondArr[0], firstArr[1] + secondArr[1]];
    obj.multiply = (firstArr, scalar) => [firstArr[0] * scalar, firstArr[1] * scalar];
    obj.dot = (firstArr, secondArr) => firstArr[0] * secondArr[0] + firstArr[1] * secondArr[1];
    obj.cross = (firstArr, secondArr) => firstArr[0] * secondArr[1] - firstArr[1] * secondArr[0];
    obj.length = (firstArr) => Math.sqrt(Math.pow(firstArr[0], 2) + Math.pow(firstArr[1], 2));
    return obj;
})();
//
// console.log(result.add([1, 1], [1, 0]));
// console.log(result.multiply([3.5, -2], 2));
// console.log(result.dot([1, 0], [0, -1]));
// console.log(result.cross([3, 7], [1, 0]));
// console.log(result.length([3, -4]));
