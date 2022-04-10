const mathEnforcer = require('./04.MathEnforcer.test.js');
const {assert, expect} = require('chai');

describe('test mathEnforcer', () => {
    it('add not number', () => {
        assert.isUndefined(mathEnforcer.addFive('a'));
    });

    it('add number', () => {
        assert.equal(mathEnforcer.addFive(3.3), 8.3);
        expect(mathEnforcer.addFive(-3.3)).to.be.closeTo(1.7, 0.01);
    });

    it('subtract not number', () => {
        assert.isUndefined(mathEnforcer.subtractTen('a'));
    });

    it('subtract number', () => {
        assert.equal(mathEnforcer.subtractTen(3.3), -6.7);
        expect(mathEnforcer.subtractTen(-3.3)).to.be.closeTo(-13.3, 0.01);
    });

    it('sum two not numbers', () => {
        assert.isUndefined(mathEnforcer.sum(3.3, 'k'));
        assert.isUndefined(mathEnforcer.sum('k', 'k'));
        assert.isUndefined(mathEnforcer.sum('k', 4));
        assert.isUndefined(mathEnforcer.sum());
    });

    it('sum numbers', () => {
        expect(mathEnforcer.sum(1, 1)).to.be.closeTo(2, 0.01);
        expect(mathEnforcer.sum(1.1, 1)).to.be.closeTo(2.1, 0.01);
        expect(mathEnforcer.sum(1, 1.1)).to.be.closeTo(2.1, 0.01);
    });
})