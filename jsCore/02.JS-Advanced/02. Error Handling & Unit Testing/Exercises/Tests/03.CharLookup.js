function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

console.log(lookupChar(" ", 0));

const assert = require('chai').assert;

describe("CharLookup tests", function () {
    it('should return 0 for first occurrence of index', function () {
        let str = "aaaaaa";

        let inputIndex = 1;
        let inputIndex1 = 0;
        let inputIndex2 = 2;

        let expected = 0;

        let strResult = lookupChar(str, inputIndex);
        let strResult1 = lookupChar(str, inputIndex1);
        let strResult2 = lookupChar(str, inputIndex2);

        let strActual = str.indexOf(strResult);
        let strActual1 = str.indexOf(strResult1);
        let strActual2 = str.indexOf(strResult2);

        assert.equal(strActual, expected);
        assert.equal(strActual1, expected);
        assert.equal(strActual2, expected);
    });
    it('should return a valid index from input str', function () {
        let str = "asd";

        let inputIndex = 1;
        let inputIndex1 = 0;
        let inputIndex2 = 2;

        let expected = 1;
        let expected1 = 0;
        let expected2 = 2;

        let result = lookupChar(str, inputIndex);
        let result1 = lookupChar(str, inputIndex1);
        let result2 = lookupChar(str, inputIndex2);

        let actual = str.indexOf(result);
        let actual1 = str.indexOf(result1);
        let actual2 = str.indexOf(result2);

        assert.equal(actual, expected);
        assert.equal(actual1, expected1);
        assert.equal(actual2, expected2);
    });
    it('should return a valid letter if all checks pass', function () {
        let str = "asd";
        let num = "123.45";
        let whiteSpace = "       ";

        let test = "undefined";
        let test1 = "null";

        let strInputIndex = 0;
        let strInputIndex1 = 1;
        let strInputIndex2 = 2;

        let numInputIndex = 1;
        let numInputIndex1 = 3;
        let numInputIndex2 = 4;

        let strExpected = "a";
        let strExpected1 = "s";
        let strExpected2 = "d";

        let numExpected = "2";
        let numExpected1 = ".";
        let numExpected2 = "4";

        let spaceExpected = " ";

        let strActual = lookupChar(str, strInputIndex);
        let strActual1 = lookupChar(str, strInputIndex1);
        let strActual2 = lookupChar(str, strInputIndex2);

        let numActual = lookupChar(num, numInputIndex);
        let numActual1 = lookupChar(num, numInputIndex1);
        let numActual2 = lookupChar(num, numInputIndex2);

        let spaceActual = lookupChar(whiteSpace, numInputIndex);
        let spaceActual1 = lookupChar(whiteSpace, numInputIndex1);
        let spaceActual2 = lookupChar(whiteSpace, numInputIndex2);

        let testActual = lookupChar(test, strInputIndex);
        let testActual1 = lookupChar(test, strInputIndex1);
        let testActual2 = lookupChar(test, strInputIndex2);

        let test1Actual = lookupChar(test1, strInputIndex);
        let test1Actual1 = lookupChar(test1, strInputIndex1);
        let test1Actual2 = lookupChar(test1, strInputIndex2);

        assert.equal(testActual, "u");
        assert.equal(testActual1, "n");
        assert.equal(testActual2, "d");

        assert.equal(test1Actual, "n");
        assert.equal(test1Actual1, "u");
        assert.equal(test1Actual2, "l");

        assert.equal(strExpected, strActual);
        assert.equal(strExpected1, strActual1);
        assert.equal(strExpected2, strActual2);

        assert.equal(numExpected, numActual);
        assert.equal(numExpected1, numActual1);
        assert.equal(numExpected2, numActual2);

        assert.equal(spaceActual, spaceExpected);
        assert.equal(spaceActual1, spaceExpected);
        assert.equal(spaceActual2, spaceExpected);
    });
    it('should return "Incorrect index" if index is bigger than or equal to current str length or less than zero', function () {
        let str = "pesho";
        let str1 = "";

        let str1Input = 0;

        let input = -1;
        let input1 = str.length;
        let input2 = str.length + 1;

        let expected = "Incorrect index";

        let actual = lookupChar(str, input);
        let actual1 = lookupChar(str, input1);
        let actual2 = lookupChar(str, input2);

        let str1Actual = lookupChar(str1, str1Input);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(str1Actual, expected);
    });
    it('should return undefined if second argument is not an integer', function () {
        let validFirstArg = "asd";

        let index = "123";
        let index1 = "123.4321";
        let index2 = {};
        let index3 = [];
        let index4 = function () { };
        let index5 = "pesho";
        let index6 = "";
        let index7 = 123.432;
        let index8 = undefined;
        let index9 = null;

        let expected = undefined;

        let actual = lookupChar(validFirstArg, index);
        let actual1 = lookupChar(validFirstArg, index1);
        let actual2 = lookupChar(validFirstArg, index2);
        let actual3 = lookupChar(validFirstArg, index3);
        let actual4 = lookupChar(validFirstArg, index4);
        let actual5 = lookupChar(validFirstArg, index5);
        let actual6 = lookupChar(validFirstArg, index6);
        let actual7 = lookupChar(validFirstArg, index7);
        let actual8 = lookupChar(validFirstArg, index8);
        let actual9 = lookupChar(validFirstArg, index9);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
        assert.equal(actual4, expected);
        assert.equal(actual5, expected);
        assert.equal(actual6, expected);
        assert.equal(actual7, expected);
        assert.equal(actual8, expected);
        assert.equal(actual9, expected);
    });
    it('should return undefined if first argument is not a string', function () {
        let secondArg = 45;

        let input = 123;
        let input1 = 123.432;
        let input2 = {};
        let input3 = [];
        let input4 = function () { };
        let input7 = undefined;
        let input8 = null;



        let expected = undefined;

        let actual = lookupChar(input, secondArg);
        let actual1 = lookupChar(input1, secondArg);
        let actual2 = lookupChar(input2, secondArg);
        let actual3 = lookupChar(input3, secondArg);
        let actual4 = lookupChar(input4, secondArg);
        let actual7 = lookupChar(input7, secondArg);
        let actual8 = lookupChar(input8, secondArg);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
        assert.equal(actual4, expected);
        assert.equal(actual7, expected);
        assert.equal(actual8, expected);
    });
});