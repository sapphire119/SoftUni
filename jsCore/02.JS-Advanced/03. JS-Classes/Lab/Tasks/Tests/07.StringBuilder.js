class StringBuilder {
    constructor(string) {
        if (string !== undefined) {
            StringBuilder._vrfyParam(string);
            this._stringArray = Array.from(string);
        } else {
            this._stringArray = [];
        }
    }

    append(string) {
        StringBuilder._vrfyParam(string);
        for(let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }

    prepend(string) {
        StringBuilder._vrfyParam(string);
        for(let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }

    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }

    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }

    toString() {
        return this._stringArray.join('');
    }
}

const assert = require("chai").assert;

describe("String Builder tests", function () {
    // •	Can be instantiated with a passed in string argument or without anything
    it('should hold string elements with length 1', function () {
        let input = "asd123";

        let expected = true;

        let result = new StringBuilder(input);

        let actual = result._stringArray;

        assert.equal(actual.every(e => e.length === 1), true);
    });
    it('should throw an exception if argument is not of type string', function () {
        let input = [];
        let input1 = {};
        let input2 = function () {};
        let input3 = 123;
        let input4 = 123.456;
        // let input5 = "123.456";
        // let input6 = "123";
        // let input5 = undefined;
        let input5 = null;

        assert.throws(() => new StringBuilder(input), TypeError, "Argument must be string");
        assert.throws(() => new StringBuilder(input1), TypeError, "Argument must be string");
        assert.throws(() => new StringBuilder(input2), TypeError, "Argument must be string");
        assert.throws(() => new StringBuilder(input3), TypeError, "Argument must be string");
        assert.throws(() => new StringBuilder(input4), TypeError, "Argument must be string");
        // assert.throws(() => new StringBuilder(input5), "Argument must be string");
        assert.throws(() => new StringBuilder(input5), TypeError, "Argument must be string");
    });
    it('should be instantiated without an argument', function () {
        let actual = new StringBuilder();
        assert.instanceOf(actual, StringBuilder);
    });
    it('should be instantiated with a passed string argument', function () {
        let input = "pesho";
        let instance = new StringBuilder(input);

        assert.instanceOf(instance, StringBuilder);
    });
    describe('append tests', function () {
        // •	Function append(string) – converts the passed in string argument to an array and adds it to the end of the storage
        it('should throw an exception if argument is not of type string', function () {
            let input = [];
            let input1 = {};
            let input2 = function () {};
            let input3 = 123;
            let input4 = 123.456;
            // let input5 = "123.456";
            // let input6 = "123";
            let input5 = undefined;
            let input6 = null;

            let result = new StringBuilder();

            assert.throws(() => result.append(input), TypeError, "Argument must be string");
            assert.throws(() => result.append(input1), TypeError, "Argument must be string");
            assert.throws(() => result.append(input2), TypeError, "Argument must be string");
            assert.throws(() => result.append(input3), TypeError, "Argument must be string");
            assert.throws(() => result.append(input4), TypeError, "Argument must be string");
            // assert.throws(() => new StringBuilder(input5), "Argument must be string");
            assert.throws(() => result.append(input5), TypeError, "Argument must be string");
            assert.throws(() => result.append(input6), TypeError, "Argument must be string");
        });
        it('should convert value to array', function () {
            let input = "asd123";

            let result = new StringBuilder();

            let expected = Array.from(input);

            result.append(input);

            let actual = result._stringArray;

            assert.typeOf(actual, "array");
            assert.deepEqual(actual, expected);
        });
        it('should append string at the end of message', function () {
            let input = "asd123";
            let inputEnd = "pesho";
            let inputEnd1 = "ivan";

            let expected = [...input, ...inputEnd];
            let expected1 = [...input, ...inputEnd, ...inputEnd1];

            let result = new StringBuilder(input);
            result.append(inputEnd);

            let result1 = new StringBuilder(input);
            result1.append(inputEnd);
            result1.append(inputEnd1);

            let actual = result._stringArray;
            let actual1 = result1._stringArray;

            assert.deepEqual(actual, expected);
            assert.deepEqual(actual1, expected1);
        });
    });
    describe('prepend tests', function () {
        // •	Function prepend(string) – converts the passed in string argument to an array and adds it to the beginning of the storage
        it('should throw an exception if argument is not of type string', function () {
            let input = [];
            let input1 = {};
            let input2 = function () {};
            let input3 = 123;
            let input4 = 123.456;
            // let input5 = "123.456";
            // let input6 = "123";
            let input5 = undefined;
            let input6 = null;

            let result = new StringBuilder();

            assert.throws(() => result.prepend(input), TypeError, "Argument must be string");
            assert.throws(() => result.prepend(input1), TypeError, "Argument must be string");
            assert.throws(() => result.prepend(input2), TypeError, "Argument must be string");
            assert.throws(() => result.prepend(input3), TypeError, "Argument must be string");
            assert.throws(() => result.prepend(input4), TypeError, "Argument must be string");
            // assert.throws(() => new StringBuilder(input5), "Argument must be string");
            assert.throws(() => result.prepend(input5), TypeError, "Argument must be string");
            assert.throws(() => result.prepend(input6), TypeError, "Argument must be string");
        });
        it('should convert value to array', function () {
            let input = "asd123";

            let expected = Array.from(input);

            let result = new StringBuilder();
            result.prepend(input);

            let actual = result._stringArray;

            assert.typeOf(actual, "array");
            assert.deepEqual(actual, expected);
        });
        it('should prepend/append string at the beginning of message', function () {
            let input = "asd123";
            let inputStart = "pesho";
            let inputStart1 = "ivan";

            let expected = [...inputStart, ...input];
            let expected1 = [...inputStart1, ...inputStart, ...input];

            let result = new StringBuilder(input);
            result.prepend(inputStart);

            let result1 = new StringBuilder(input);
            result1.prepend(inputStart);
            result1.prepend(inputStart1);

            let actual = result._stringArray;
            let actual1 = result1._stringArray;

            assert.deepEqual(actual, expected);
            assert.deepEqual(actual1, expected1);
        });
    });
    describe('insertAt tests', function () {
        // Function insertAt(string, index) – converts the passed in string argument
        // to an array and adds it at the given index (there is no need to check if the index is in range)
        it('should throw an exception if argument is not of type string', function () {
            let input = [];
            let input1 = {};
            let input2 = function () {};
            let input3 = 123;
            let input4 = 123.456;
            // let input5 = "123.456";
            // let input6 = "123";
            let input5 = undefined;
            let input6 = null;

            let result = new StringBuilder();

            assert.throws(() => result.insertAt(input, 0), TypeError, "Argument must be string");
            assert.throws(() => result.insertAt(input1, 0), TypeError, "Argument must be string");
            assert.throws(() => result.insertAt(input2, 0), TypeError, "Argument must be string");
            assert.throws(() => result.insertAt(input3, 0), TypeError, "Argument must be string");
            assert.throws(() => result.insertAt(input4, 0), TypeError, "Argument must be string");
            // assert.throws(() => new StringBuilder(input5), "Argument must be string");
            assert.throws(() => result.insertAt(input5, 0), TypeError, "Argument must be string");
            assert.throws(() => result.insertAt(input6, 0), TypeError, "Argument must be string");
        });
        it('should convert value to array', function () {
            let input = "asd123";

            let result = new StringBuilder();

            result.insertAt(input, 0);

            let actual = result._stringArray;

            assert.typeOf(actual, "array");
        });
        it('should insert string at the given index', function () {
            let input = "asd123";
            let valueToInsert = "pesho";

            let expected = Array.from("asdpesho123");
            let expected1 = Array.from("pesho");
            let expected2 = Array.from("asd1          23");

            let result = new StringBuilder();
            result.append(input);
            result.insertAt(valueToInsert, 3);

            let result1 = new StringBuilder();
            result1.insertAt(valueToInsert, 0);

            let result2 = new StringBuilder(input);
            result2.insertAt(valueToInsert, -3);

            let result3 = new StringBuilder(input);
            result3.insertAt("          ", 4);

            let actual = result._stringArray;
            let actual1 = result1._stringArray;
            let actual2 = result2._stringArray;
            let actual3 = result3._stringArray;

            assert.deepEqual(actual, expected);
            assert.deepEqual(actual1, expected1);
            assert.deepEqual(actual2, expected);
            assert.deepEqual(actual3, expected2);
        });
    });
    describe('remove tests', function () {
        // Function remove(startIndex, length) – removes elements from the storage,
        // starting at the given index (inclusive),
        // length number of characters (there is no need to check if the index is in range)
        it('should remove elements from given index inclusive', function () {
            let input = "asd123";

            let expected = Array.from("as123");
            let expected1 = Array.from("asd123");
            let expected2 = Array.from("asd1");


            let result = new StringBuilder(input);
            result.remove(2, 1);

            let result1 = new StringBuilder(input);
            result1.remove(0,0);

            let result2 = new StringBuilder(input);
            result2.remove(-2, 2);

            let actual = result._stringArray;
            let actual1 = result1._stringArray;
            let actual2 = result2._stringArray;

            assert.deepEqual(actual, expected);
            assert.deepEqual(actual1, expected1);
            assert.deepEqual(actual2, expected2);
        });
    });
    describe('toString tests', function () {
        // •	Function toString() – returns a string with all elements joined by an empty string
        it('should return an argument of type string', function () {
            let input = "asd123";

            let expected = "string";

            let result = new StringBuilder(input);

            let actual = result.toString();

            assert.typeOf(actual, expected);
        });
        it('should return correct count of elements', function () {
            let input = "asd123";

            let expected = 6;

            let result = new StringBuilder(input);

            let actual = result.toString();

            assert.equal(actual.length, expected);
        });
        it('should return a string result', function () {
            let input = "asd123";
            let input1 = "asd1   23";

            let expected = "asd123";
            let expected1 = "asd1   23";

            let result = new StringBuilder(input);
            let result1 = new StringBuilder(input1);

            let actual = result.toString();
            let actual1 = result1.toString();

            assert.equal(actual, expected);
            assert.equal(actual1, expected1);
        });
    });
});