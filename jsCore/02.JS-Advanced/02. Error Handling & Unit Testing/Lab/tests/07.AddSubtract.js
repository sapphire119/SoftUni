function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; },
    }
}

const assert = require('chai').assert;

// Returns a module (object), containing the functions add, subtract and get as properties
// Keeps an internal sum which can’t be modified from the outside
// The functions add and subtract take a parameter that can be parsed as a number (either a number or a string containing a number) that is added or subtracted from the internal sum
// The function get returns the value of the internal sum

describe("AddSubtract tests", function () {
    it('should add or subtract correctly', function () {
        let calc = createCalculator();
        calc.add(10);

        let expectedAdd = 10;
        let actualAdd = calc.get();

        assert.equal(actualAdd, expectedAdd);

        calc.add("10");
        let expectedAdd1 = 20;
        let actualAdd1= calc.get();

        assert.equal(actualAdd1, expectedAdd1);

        calc.subtract(4.3213);
        let expectedSub = 15.6787;
        let actualSub = calc.get();

        assert.equal(actualSub, expectedSub);

        calc.subtract("5.6787");
        let expectedSub1 = 10;
        let actualSub1 = calc.get();

        assert.equal(actualSub1, expectedSub1);
    });
    it('should return 0 if given an empty array or an empty string as arg to Add or Subtract', function () {
        let calc = createCalculator();
        calc.add("");
        let calc1 = createCalculator();
        calc1.add([]);

        let expected = 0;

        let actualAddStrEmptyVal = calc.get();
        let actualAddEmptyArrVal = calc1.get();

        assert.equal(actualAddStrEmptyVal, expected);
        assert.equal(actualAddEmptyArrVal, expected);

        let calc2 = createCalculator();
        calc2.subtract("");
        let calc3 = createCalculator();
        calc3.subtract([]);

        let actualSubtractStrEmptyVal = calc.get();
        let actualSubtractEmptyArrVal = calc1.get();

        assert.equal(actualSubtractStrEmptyVal, expected);
        assert.equal(actualSubtractEmptyArrVal, expected);
    });
    it('should return a NaN when given wrong params to Add and Subtract', function () {
        let calc = createCalculator();
        calc.add("pesho");
        let calc1 = createCalculator();
        calc1.add([1, 2, 3]);
        let calc2 = createCalculator();
        calc2.add(function () { });
        let calc3 = createCalculator();
        calc3.add({});

        let expected = true;

        let actualAddStrWithValueResult = calc.get();
        let actualAddArrResult = calc1.get();
        let actualAddFuncResult = calc2.get();
        let actualAddObjResult = calc3.get();

        assert.equal(isNaN(actualAddStrWithValueResult), expected);
        assert.equal(isNaN(actualAddArrResult), expected);
        assert.equal(isNaN(actualAddFuncResult), expected);
        assert.equal(isNaN(actualAddObjResult), expected);

        let calc4 = createCalculator();
        calc4.subtract("pesho");
        let calc5 = createCalculator();
        calc5.subtract([1, 2, 3]);
        let calc6 = createCalculator();
        calc6.subtract(function () { });
        let calc7 = createCalculator();
        calc7.subtract({});

        let actualSubtractStrWithValueResult = calc4.get();
        let actualSubtractArrResult = calc5.get();
        let actualSubtractFuncResult = calc6.get();
        let actualSubtractObjResult = calc7.get();

        assert.equal(isNaN(actualSubtractStrWithValueResult), expected);
        assert.equal(isNaN(actualSubtractArrResult), expected);
        assert.equal(isNaN(actualSubtractFuncResult), expected);
        assert.equal(isNaN(actualSubtractObjResult), expected);
    });
    it('should keep an internal sum that cannot be modified', function () {
        let expectedGet = 0;
        let expectedAdd = 10;
        let expectedSubtract = 5;

        let obj = createCalculator();

        let actualGet = obj.get();

        obj.add(10);
        let actualAdd = obj.get();

        obj.subtract(5);
        let actualSubtract = obj.get();

        assert.equal(actualGet, expectedGet);
        assert.equal(actualAdd, expectedAdd);
        assert.equal(actualSubtract, expectedSubtract);
    });
    it('should have a return obj with three functions as properties', function () {
        let firstName = "add";
        let secondName = "subtract";
        let thirdName = "get";

        let actual = createCalculator();

        let expected = true;

        assert.equal(actual.hasOwnProperty(firstName), expected);
        assert.equal(actual.hasOwnProperty(secondName), expected);
        assert.equal(actual.hasOwnProperty(thirdName), expected);
    });
    it('should return three functions with names: add, subtract, get', function () {
        let expectedFirstName = "add";
        let expectedSecondName = "subtract";
        let expectedThirdName = "get";

        let actualObject = createCalculator();

        let actualFirstFuncName = actualObject.add.name;
        let actualSecondFuncName = actualObject.subtract.name;
        let actualThirdFuncName = actualObject.get.name;

        assert.equal(actualFirstFuncName, expectedFirstName);
        assert.equal(actualSecondFuncName, expectedSecondName);
        assert.equal(actualThirdFuncName, expectedThirdName);
    });
    it('should return an object', function () {
        let expected = typeof "object";

        let actual = typeof createCalculator();

        assert.typeOf(actual, expected);
    });
});