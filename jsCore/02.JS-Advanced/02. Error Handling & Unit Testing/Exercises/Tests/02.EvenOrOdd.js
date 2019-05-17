function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}


const assert = require('chai').assert;

describe("tile", function () {
    it('should return "odd" if length is odd', function () {
        let str = "123";
        let str1 = "123.4";
        let str2 = "a";
        let str3 = "abc";
        let str4 = "odd";

        let expected = "odd";

        let actual = isOddOrEven(str);
        let actual1 = isOddOrEven(str1);
        let actual2 = isOddOrEven(str2);
        let actual3 = isOddOrEven(str3);
        let actual4 = isOddOrEven(str4);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
        assert.equal(actual4, expected);
    });
    it('should return "even" if length is even', function () {
        let str = "";
        let str1 = "aa";
        let str2 = "aabb";
        let str3 = "aabbcc";
        let str4 = "even";

        let expected = "even";

        let actual = isOddOrEven(str);
        let actual1 = isOddOrEven(str1);
        let actual2 = isOddOrEven(str2);
        let actual3 = isOddOrEven(str3);
        let actual4 = isOddOrEven(str4);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
        assert.equal(actual4, expected);
    });
    it('should return undefined if arg type is not a string', function () {
        let argm = 123;
        let argm1 = 123.4321;
        let argm2 = [];
        let argm3 = {};
        let argm4 = function () { };

        let expected = undefined;

        let actual = isOddOrEven(argm);
        let actual1 = isOddOrEven(argm1);
        let actual2 = isOddOrEven(argm2);
        let actual3 = isOddOrEven(argm3);
        let actual4 = isOddOrEven(argm4);

        assert.equal(actual, expected);
        assert.equal(actual1, expected);
        assert.equal(actual2, expected);
        assert.equal(actual3, expected);
        assert.equal(actual4, expected);
    });
});