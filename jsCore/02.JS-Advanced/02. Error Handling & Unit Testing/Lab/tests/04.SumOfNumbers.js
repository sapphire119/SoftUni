sum = function(arr) {
    let sum = 0;
    for (let num of arr)
        sum += Number(num);
    return sum;
};

const assert = require('chai').assert;

describe('sumOfNumbers', function () {
    // it('should throw an Error if string input', function () {
    //     let str = "";
    //     assert.throws(() => sum(str), Error);
    // });
    // it('should throw an Error if number input', function () {
    //     let number = 4;
    //     let expected = Error;
    //     let actual = () => sum(number);
    //     assert.throws(actual, Error);
    // });
    it('should return default sum', function () {
        let arr = [];
        let expected = 0;
        let actual = sum(arr);
        assert.equal(actual, expected);
    });
    it('should be a NaN if wrong input params', function () {
        let arr = ["pesho", 4, null, undefined];
        let expeced = true ;

        let actual = isNaN(sum(arr));

        assert.equal(actual, expeced);
    });
    it('should throw an Error if Function input', function () {
        let func = function () {
            return "pesho";
        };

        assert.throws(() => sum(func), Error);
    });

    it('should return a number', function () {
        //Arrange
        let arr = [1, 2, 3];
        let expected = "number";
        //Act
        let actual = typeof sum(arr);
        //Assert
        assert.equal(actual, expected);
    });
    it('should return sum of elements', function () {
        //Arrange
        let arr = [1, 2, 3, 4, 5];
        let expectedSum = 15;
        //Act
        let actualSum = sum(arr);
        //Assert
        assert.equal(actualSum, expectedSum);
    });
});
//Wrong Input: [], [null, undefined], [123, 456, "asd", "pesho", null], ["asd"], [function() { asd}]
//............ "", "asd", 123, 123.456,
//////////////