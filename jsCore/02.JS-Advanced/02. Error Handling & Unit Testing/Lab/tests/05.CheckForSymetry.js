function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let firstArr = JSON.stringify(arr);
    let secondArr = JSON.stringify(reversed);
    let equal = (firstArr == secondArr);
    return equal;
}

//Input vars; [[asdasd], [asdasdasd], [asdasd]]

const assert = require('chai').assert;
// •	Takes an array as argument
// •	Returns false for any input that isn’t of the correct type
// •	Returns true if the input array is symmetric (first half is the same as the second half mirrored)
// •	Otherwise, returns false


describe("isSymmetric tests", function () {
    it('should return true if a single element is passed', function () {
        let arr = [123];
        let arr1 = ["pesho"];
        let arr2 = [{"pesho":"asd"}];
        let arr3 = [ function () { }];
        let arr4 = [123.4443];

        let expect = true;

        let actual = isSymmetric(arr);
        let actual1 = isSymmetric(arr1);
        let actual2 = isSymmetric(arr2);
        let actual3 = isSymmetric(arr3);
        let actual4 = isSymmetric(arr4);

        assert.equal(actual, expect);
        assert.equal(actual1, expect);
        assert.equal(actual2, expect);
        assert.equal(actual3, expect);
        assert.equal(actual4, expect);
    });
    it('should return false if arr is not symmetric', function () {
        let arr = [1, 2, 3];
        let arr1 = ["asd", "asd", "asd", "dsa"];
        let arr2 = ["a", "b", "c", "d"];
        let arr3 = [[],[],[],['a']];

        let expected = false;

        let actual = isSymmetric(arr);
        let actual1 = isSymmetric(arr1);
        let actual2 = isSymmetric(arr2);
        let actual3 = isSymmetric(arr3);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
    });
    it('should return true if arr is symmetric', function () {
        let arr = [1, 2, 3, 2, 1];
        let arr1 = ["asd", "asd", "asd", "asd"];
        let arr2 = [[],[],[],[]];

        let expected = true;

        let actual = isSymmetric(arr);
        let actual1 = isSymmetric(arr1);
        let actual2 = isSymmetric(arr2);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
    });
    it('should take an array as argument', function () {
        let arr = [];

        let expected = true;
        let actual = isSymmetric(arr);

        assert.equal(actual, expected);
    });
    it('should return false if argument type is diff from Array', function () {
        //Arrange
        let inputStr = "";
        let inputNum = 123;
        let inputUndf = undefined;
        let inputnull = null;
        let inputFunc = function () { };
        let inputObj = {};

        let expected = false;
        //Act, Assert
        assert.equal(isSymmetric(inputStr), expected);
        assert.equal(isSymmetric(inputNum), expected);
        assert.equal(isSymmetric(inputUndf), expected);
        assert.equal(isSymmetric(inputnull), expected);
        assert.equal(isSymmetric(inputFunc), expected);
        assert.equal(isSymmetric(inputObj), expected);
    });
});