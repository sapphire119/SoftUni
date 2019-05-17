let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

const assert = require('chai').assert;

describe("Math enforcer test", function () {
    let range = 0.01;
    // function numberInRange(actualNumber, expectedResult){
    //     let currentNumber = Number(actualNumber);
    //
    //     let upperTolerance = Number((currentNumber + range).toFixed(2));
    //     let lowerTolerance = Number((currentNumber - range).toFixed(2));
    //
    //     if (currentNumber === expectedResult){
    //         return true;
    //     } else if(upperTolerance === expectedResult ) {
    //         return true;
    //     } else if (lowerTolerance === expectedResult) {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }
    //• addFive(num) - A function that accepts a single parameter:
    // o If the parameter is not a number, the function should return undefined.
    // o If the parameter is a number, add 5 to it, and return the result.
    describe('addFive tests', function () {
        it('should correctly handle negative argument', function () {
            let input = -4;
            let input1 = -5.472398;

            let expectedResult = 1;
            let expected1Result = -0.47;

            // .toFixed(2);
            // .toFixed(2);

            let result = mathEnforcer.addFive(input);
            let result1 = mathEnforcer.addFive(input1);

            // let actual = numberInRange(result, expectedResult);
            // let actual1 = numberInRange(result1, expected1Result);

            // let expected = true;
            assert.closeTo(result, expectedResult, range);
            assert.closeTo(result1, expected1Result, range);
            // assert.equal(actual, expected);
            // assert.equal(actual1, expected);
        });
        it('should add correct value and return result', function () {
            let input = 0;
            let input1 = 0.43945684;
            let input2 = 5.329457;
            let input3 = 453684.329457;

            let expectedResult = 5;
            let expected1Result = 5.44;
            let expected2Result = 10.33;
            let expected3Result = 453689.33;


            // .toFixed(2);
            // .toFixed(2);
            // .toFixed(2);
            // .toFixed(2);
            let result = mathEnforcer.addFive(input);
            let result1 = mathEnforcer.addFive(input1);
            let result2 = mathEnforcer.addFive(input2);
            let result3 = mathEnforcer.addFive(input3);

            // let actual =  numberInRange(result, expectedResult);
            // let actual1 = numberInRange(result1, expected1Result);
            // let actual2 = numberInRange(result2, expected2Result);
            // let actual3 = numberInRange(result3, expected3Result);

            // let expected = true;

            assert.closeTo(result, expectedResult, range);
            assert.closeTo(result1, expected1Result, range);
            assert.closeTo(result2, expected2Result, range);
            assert.closeTo(result3, expected3Result, range);
            // assert.equal(actual, expected);
            // assert.equal(actual1, expected);
            // assert.equal(actual2, expected);
            // assert.equal(actual3, expected);
        });
        it('should return undefined if arg is not a number', function () {
            let input = [];
            let input1 = {};
            let input2 = function () { };
            let input3 = "";
            let input4 = "123";
            let input5 = "123.456";
            let input6 = "pesho";
            let input7 = null;
            let input8 = undefined;

            let expected = undefined;

            let actual = mathEnforcer.addFive(input);
            let actual1 = mathEnforcer.addFive(input1);
            let actual2 = mathEnforcer.addFive(input2);
            let actual3 = mathEnforcer.addFive(input3);
            let actual4 = mathEnforcer.addFive(input4);
            let actual5 = mathEnforcer.addFive(input5);
            let actual6 = mathEnforcer.addFive(input6);
            let actual7 = mathEnforcer.addFive(input7);
            let actual8 = mathEnforcer.addFive(input8);

            assert.equal(actual, expected);
            assert.equal(actual1, expected);
            assert.equal(actual2, expected);
            assert.equal(actual3, expected);
            assert.equal(actual4, expected);
            assert.equal(actual5, expected);
            assert.equal(actual6, expected);
            assert.equal(actual7, expected);
            assert.equal(actual8, expected);
        });
    });
    //• subtractTen(num) - A function that accepts a single parameter:
    // o If the parameter is not a number, the function should return  undefined.
    // o If the parameter is a number, subtract 10 from it, and return the result.
    describe('subtractTen tests', function () {
        it('should correctly handle negative argument', function () {
            let input = -4;
            let input1 = -5.472398;

            let expectedResult = -14;
            let expected1Result = -15.47;
            // .toFixed(2);
            // .toFixed(2);

            let result = mathEnforcer.subtractTen(input);
            let result1 = mathEnforcer.subtractTen(input1);

            // let actual = numberInRange(result, expectedResult);
            // let actual1 = numberInRange(result1, expected1Result);

            // let expected = true;

            assert.closeTo(result, expectedResult, range);
            assert.closeTo(result1, expected1Result, range);
        });
        it('should subtract correct value and return result', function () {
            let input = 10;
            let input1 = 10.43;
            let input2 = 15.32;

            let expectedResult = 0;
            let expected1Result = 0.43;
            let expected2Result = 5.32;

            // .toFixed(2);
            // .toFixed(2);
            // .toFixed(2);
            let result =  mathEnforcer.subtractTen(input);
            let result1 = mathEnforcer.subtractTen(input1);
            let result2 = mathEnforcer.subtractTen(input2);

            // let actual =  numberInRange(result, expectedResult);
            // let actual1 = numberInRange(result1, expected1Result);
            // let actual2 = numberInRange(result2, expected2Result);

            // let expected = true;

            assert.closeTo(result, expectedResult, range);
            assert.closeTo(result1, expected1Result, range);
            assert.closeTo(result2, expected2Result, range);
        });
        it('should return undefined if arg is not a number', function () {
            let input = [];
            let input1 = {};
            let input2 = function () { };
            let input3 = "";
            let input4 = "123";
            let input5 = "123.456";
            let input6 = "pesho";

            let expected = undefined;

            let actual = mathEnforcer.subtractTen(input);
            let actual1 = mathEnforcer.subtractTen(input1);
            let actual2 = mathEnforcer.subtractTen(input2);
            let actual3 = mathEnforcer.subtractTen(input3);
            let actual4 = mathEnforcer.subtractTen(input4);
            let actual5 = mathEnforcer.subtractTen(input5);
            let actual6 = mathEnforcer.subtractTen(input6);

            assert.equal(actual, expected);
            assert.equal(actual1, expected);
            assert.equal(actual2, expected);
            assert.equal(actual3, expected);
            assert.equal(actual4, expected);
            assert.equal(actual5, expected);
            assert.equal(actual6, expected);
        });
    });
    //• sum(num1, num2) - A function that should accepts two parameters:
    // o If any of the 2 parameters is not a number, the function should return undefined.
    // o If both parameters are numbers, the function should return their sum.
    describe('sum tests', function () {
        it('should return correct value for sum of firstArg/secondArg and secondArg/firstArg', function () {
            let input = 10;
            let input1 = 14.537345734;

            let input2 = -25;
            let input3 = -345.3215;

            let expectedResult1 = 24.54;
            let expectedResult2 = -370.32;

            // .toFixed(2);
            // .toFixed(2);
            // .toFixed(2);
            // .toFixed(2);

            let result = mathEnforcer.sum(input, input1);
            let result1 = mathEnforcer.sum(input1, input);
            let result2 = mathEnforcer.sum(input2, input3);
            let result3 = mathEnforcer.sum(input3, input2);

            // let actual = numberInRange(result, expectedResult1);
            // let actual1 = numberInRange(result1, expectedResult1);
            //
            // let actual2 = numberInRange(result2, expectedResult2);
            // let actual3 = numberInRange(result3, expectedResult2);

            // let expected = true;

            assert.closeTo(result, expectedResult1, range);
            assert.closeTo(result1, expectedResult1, range);
            assert.closeTo(result2, expectedResult2, range);
            assert.closeTo(result3, expectedResult2, range);
        });
        it('should return undefined if second arg is not a number', function () {
            let validFirstNum = 2;

            let input = [];
            let input1 = {};
            let input2 = function () { };
            let input3 = "";
            let input4 = "123";
            let input5 = "123.456";
            let input6 = "pesho";
            let input7 = null;
            let input8 = undefined;

            let expected = undefined;

            let actual = mathEnforcer.sum(validFirstNum, input);
            let actual1 = mathEnforcer.sum(validFirstNum, input1);
            let actual2 = mathEnforcer.sum(validFirstNum, input2);
            let actual3 = mathEnforcer.sum(validFirstNum, input3);
            let actual4 = mathEnforcer.sum(validFirstNum, input4);
            let actual5 = mathEnforcer.sum(validFirstNum, input5);
            let actual6 = mathEnforcer.sum(validFirstNum, input6);
            let actual7 = mathEnforcer.sum(validFirstNum, input7);
            let actual8 = mathEnforcer.sum(validFirstNum, input8);

            assert.equal(actual, expected);
            assert.equal(actual1, expected);
            assert.equal(actual2, expected);
            assert.equal(actual3, expected);
            assert.equal(actual4, expected);
            assert.equal(actual5, expected);
            assert.equal(actual6, expected);
            assert.equal(actual7, expected);
            assert.equal(actual8, expected);
        });
        it('should return undefined if first arg is not a number', function () {
            let validSecondNum = 2;

            let input = [];
            let input1 = {};
            let input2 = function () { };
            let input3 = "";
            let input4 = "123";
            let input5 = "123.456";
            let input6 = "pesho";
            let input7 = null;
            let input8 = undefined;

            let expected = undefined;

            let actual = mathEnforcer.sum(input, validSecondNum);
            let actual1 = mathEnforcer.sum(input1, validSecondNum);
            let actual2 = mathEnforcer.sum(input2, validSecondNum);
            let actual3 = mathEnforcer.sum(input3, validSecondNum);
            let actual4 = mathEnforcer.sum(input4, validSecondNum);
            let actual5 = mathEnforcer.sum(input5, validSecondNum);
            let actual6 = mathEnforcer.sum(input6, validSecondNum);
            let actual7 = mathEnforcer.sum(input7, validSecondNum);
            let actual8 = mathEnforcer.sum(input8, validSecondNum);

            assert.equal(actual, expected);
            assert.equal(actual1, expected);
            assert.equal(actual2, expected);
            assert.equal(actual3, expected);
            assert.equal(actual4, expected);
            assert.equal(actual5, expected);
            assert.equal(actual6, expected);
            assert.equal(actual7, expected);
            assert.equal(actual8, expected);
        });
    });
});