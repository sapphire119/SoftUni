let expect = require('chai').expect;


describe('reverse func test', function () {
    it('3 2 1 test', function () {
        let arr = [3,2,1];
        expect(arr.reverse()).to.be.eql([1,2,3]);
    });

    it('9 8 test', function () {
        let arr = [9,8];
        expect(arr.reverse()).to.be.eql([8, 9]);
    });
});