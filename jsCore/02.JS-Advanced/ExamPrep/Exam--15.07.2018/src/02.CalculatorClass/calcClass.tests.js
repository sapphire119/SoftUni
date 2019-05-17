const Calculator = require("./calcClass");
const assert = require('chai').assert;

// describe("asd", function () {
//     it('should work', function () {
//         console.log("pesho")
//     });
// })
describe('Calculator', function () {
    let calculator;
    beforeEach(function () {
        calculator = new Calculator();
    });

    it('should contain a property expenses that is initialized to an empty array', function () {
        assert.property(calculator, 'expenses');
        assert.isArray(calculator.expenses);
    });

    describe("Function add(data)", function () {
        it('should add any type of data to expenses', function () {
            calculator.add(123.456);
            calculator.add("");
            calculator.add("pesho");
            calculator.add("123");
            calculator.add("123.456");
            calculator.add([]);
            calculator.add([1, 2, 3]);
            calculator.add({});
            calculator.add({"stamat": "georgi"});
            // calculator.add(function f() {});
            // calculator.add(() => true);
            calculator.add(true);
            calculator.add(undefined);
            calculator.add(null);

            assert.deepEqual(calculator.expenses, [ 123.456,
                '',
                'pesho',
                '123',
                '123.456',
                [],
                [ 1, 2, 3 ],
                {},
                { "stamat": 'georgi' },
                // typeof function () {},
                // 'Function',
                true,
                undefined,
                null]);

            assert.equal(calculator.expenses.length, 12);
        });
    });

    describe("Function divideNums()", function () {
        it('should divide only the numbers (standard case)', function () {
            //normal nums
            calculator.add(100);
            calculator.add(1);
            calculator.add(4);
            calculator.add(5);

            let standardCase = calculator.divideNums();

            assert.equal(standardCase, 5);
        });

        it('should divide only the numbers (floats case)', function () {
            //floats
            calculator.add(100);
            calculator.add(1);
            calculator.add(4);
            calculator.add(4);

            let floats = calculator.divideNums();

            assert.closeTo(floats, 6.25, 0.01);
        });

        it('should divide only the numbers (mediary case)', function () {
            //normal nums
            calculator.add(100);
            calculator.add("100");
            calculator.add("asd");
            calculator.add(function () { });
            calculator.add(true);
            calculator.add(1);
            calculator.add(4);
            calculator.add(5);

            let standartCase = calculator.divideNums();

            assert.equal(standartCase, 5);
        });

        it('should return a string "Cannot divide by zero" if trying to divide by zero', function () {
            calculator.add(100);
            calculator.add(0);

            let expected = "Cannot divide by zero";
            let result = calculator.divideNums();

            assert.equal(result, expected);
        });

        it('should throw an exception if arr is empty', function () {
            assert.throws(() => calculator.divideNums(), "There are no numbers in the array!");
        });
    });

    describe("Function toString()", function () {
        it('should return standard case', function () {
            calculator.add("pesho");
            calculator.add("gosho");
            calculator.add("ivan");

            let expected = "pesho -> gosho -> ivan";
            let result = calculator.toString();

            assert.equal(result, expected);
        });

        it('should return single item', function () {
            calculator.add("pesho");

            assert.equal(calculator.toString(), "pesho");
        });

        it('should return "empty array" if no items are found', function () {
            assert.equal(calculator.toString(), "empty array");
        });
    });

    describe("Function orderBy()", function () {
        it('should return a string joined by ", " (standard case)', function () {
            calculator.add(1);
            calculator.add(-1);
            calculator.add(3);
            calculator.add(-5);
            calculator.add(6);
            calculator.add(11);

            let expected = "-5, -1, 1, 3, 6, 11";
            let result = calculator.orderBy();

            assert.equal(result, expected);
        });

        it('mixed data case for sorting', function () {
            calculator.add("pesho");
            calculator.add(6);
            calculator.add("bai ivan");
            calculator.add(function f() {});
            calculator.add([1, 2, 3]);
            calculator.add(-5);
            calculator.add({"pesho": "gosho"});
            calculator.add(11);

            let result = calculator.orderBy();
            let expected = "-5, 1,2,3, 11, 6, [object Object], bai ivan, function f() {}, pesho";

            assert.equal(result, expected);
        });

        it('should return "empty" if there is no data', function () {
            let result = calculator.orderBy();
            let expected = "empty";

            assert.equal(result, expected);
        });
    })
});