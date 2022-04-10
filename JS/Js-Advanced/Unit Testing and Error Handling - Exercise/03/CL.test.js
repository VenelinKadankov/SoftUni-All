const lookupChar = require('./03. Char Lookup.js');
const { assert} = require('chai');

describe('lookupChar test', () => {
    it('with first param not string is undefined', () => {
        assert.equal(lookupChar(4, 4), undefined);
    });

    it('with first param not string is undefined', () => {
        assert.equal(lookupChar('lll', 4.4), undefined);
    });

    it('with second param not int is undefined', () => {
        assert.equal(lookupChar('sffff', 'true'), undefined);
    });

    it('with params are correct type but out of range', () => {
        assert.equal(lookupChar('sff', 4), 'Incorrect index');
    });

    it('with all correct returns propper char', () => {
        assert.equal(lookupChar('sff', 1), 'f');
    });

    it('with negative index returns propper message', () => {
        assert.equal(lookupChar('sff', -1), 'Incorrect index');
    });

    it('with equal to length index returns propper message', () => {
        assert.equal(lookupChar('sff', 3), 'Incorrect index');
    });
})