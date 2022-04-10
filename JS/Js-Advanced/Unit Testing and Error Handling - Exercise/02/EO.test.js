const isOddOrEven = require('./02. Even Or Odd.js');
const {assert, expect} = require('chai');

describe('Test Even or Odd Function', () => {
    it('Test with even length', () => {
        assert.equal(isOddOrEven('even'), 'even');
    })

    it('Test with odd length', () => {
        assert.equal(isOddOrEven('odd'), 'odd');
    })

    it('Test with no paramether', () => {
        assert.equal(isOddOrEven(), undefined);
    })
    
    it('Test with no paramether', () => {
        assert.equal(isOddOrEven(1), undefined);
    })
    
    it('Test with no paramether', () => {
        assert.equal(isOddOrEven(true), undefined);
    })
    
    it('Test with no paramether', () => {
        assert.equal(isOddOrEven({}), undefined);
    })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven()).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven(1)).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven(NaN)).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven( )).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven(true)).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven([])).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven({})).to.undefined;
    // })

    // it('Test with no paramether with expect', () => {
    //     expect(isOddOrEven()).to.undefined;
    // })
})