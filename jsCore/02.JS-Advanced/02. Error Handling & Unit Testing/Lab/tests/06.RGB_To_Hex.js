function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

// console.log(rgbToHexColor(255, 255, 255));

// Takes three integer numbers, representing the red, green and blue values of an RGB color, each within range [0…255]
// Returns the same color in hexadecimal format as a string (e.g. '#FF9EAA')
// Returns 'undefined' if any of the input parameters are of invalid type or not in the expected range

const assert = require('chai').assert;

describe("rgbToHexColor tests", function () {
    it('should have only three arguments', function () {

    });
    it('should return correct string result in hexadecimal format', function () {
        let expected = "#646464";
        let expected1 = "#FFFFFF";
        let expected2 = "#0EFF4E";
        let expected3 = "#000000";

        let actual = rgbToHexColor(100, 100 ,100);
        let actual1 = rgbToHexColor(255, 255 ,255);
        let actual2 = rgbToHexColor(14, 255, 78);
        let actual3 = rgbToHexColor(0,0,0);

        assert.equal(actual, expected);
        assert.equal(actual1, expected1);
        assert.equal(actual2, expected2);
        assert.equal(actual3, expected3);
    });
    it('should return undefined if arguments are out of range', function () {
        let input = 256;
        let input1 = -1;

        let expected = undefined;

        let firstNumberActual = rgbToHexColor(input);
        let firstNumberActual1 = rgbToHexColor(input1);

        assert.equal(firstNumberActual, expected);
        assert.equal(firstNumberActual1, expected);

        let secondNumberActual = rgbToHexColor(1,input);
        let secondNumberActual1 = rgbToHexColor(1, input1);

        assert.equal(secondNumberActual, expected);
        assert.equal(secondNumberActual1, expected);

        let thirdNumberActual = rgbToHexColor(1,1, input);
        let thirdNumberActual1 = rgbToHexColor(1, 1, input1);

        assert.equal(thirdNumberActual, expected);
        assert.equal(thirdNumberActual1, expected);
    });
    it('should return undefined if arguments are not of type integer', function () {
        let input = 12.43;
        let input1 = "";
        let input2 = [];
        let input3 = {};
        let input4 = function () { };
        let input5 = null;
        let input6 = undefined;

        let expected = undefined;

        let firstNumberActual = rgbToHexColor(input);
        let firstNumberActual1 = rgbToHexColor(input1);
        let firstNumberActual2 = rgbToHexColor(input2);
        let firstNumberActual3 = rgbToHexColor(input3);
        let firstNumberActual4 = rgbToHexColor(input4);
        let firstNumberActual5 = rgbToHexColor(input5);
        let firstNumberActual6 = rgbToHexColor(input6);

        assert.equal(firstNumberActual,  expected);
        assert.equal(firstNumberActual1, expected);
        assert.equal(firstNumberActual2, expected);
        assert.equal(firstNumberActual3, expected);
        assert.equal(firstNumberActual4, expected);
        assert.equal(firstNumberActual5, expected);
        assert.equal(firstNumberActual6, expected);

        let secondNumberActual =  rgbToHexColor(1, input);
        let secondNumberActual1 = rgbToHexColor(1, input1);
        let secondNumberActual2 = rgbToHexColor(1, input2);
        let secondNumberActual3 = rgbToHexColor(1, input3);
        let secondNumberActual4 = rgbToHexColor(1, input4);
        let secondNumberActual5 = rgbToHexColor(1, input5);
        let secondNumberActual6 = rgbToHexColor(1, input6);

        assert.equal(secondNumberActual,  expected);
        assert.equal(secondNumberActual1, expected);
        assert.equal(secondNumberActual2, expected);
        assert.equal(secondNumberActual3, expected);
        assert.equal(secondNumberActual4, expected);
        assert.equal(secondNumberActual5, expected);
        assert.equal(secondNumberActual6, expected);

        let thirdNumberActual =  rgbToHexColor(1,1, input);
        let thirdNumberActual1 = rgbToHexColor(1,1, input1);
        let thirdNumberActual2 = rgbToHexColor(1,1, input2);
        let thirdNumberActual3 = rgbToHexColor(1,1, input3);
        let thirdNumberActual4 = rgbToHexColor(1,1, input4);
        let thirdNumberActual5 = rgbToHexColor(1,1, input5);
        let thirdNumberActual6 = rgbToHexColor(1,1, input6);

        assert.equal(thirdNumberActual,  expected);
        assert.equal(thirdNumberActual1, expected);
        assert.equal(thirdNumberActual2, expected);
        assert.equal(thirdNumberActual3, expected);
        assert.equal(thirdNumberActual4, expected);
        assert.equal(thirdNumberActual5, expected);
        assert.equal(thirdNumberActual6, expected);
    });
});