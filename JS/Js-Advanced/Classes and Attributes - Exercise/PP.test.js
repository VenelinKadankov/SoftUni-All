const { expect, assert } = require("chai");

class PaymentPackage {
  constructor(name, value) {
    this.name = name;
    this.value = value;
    this.VAT = 20;      // Default value    
    this.active = true; // Default value
  }

  get name() {
    return this._name;
  }

  set name(newValue) {
    if (typeof newValue !== 'string') {
      throw new Error('Name must be a non-empty string');
    }
    if (newValue.length === 0) {
      throw new Error('Name must be a non-empty string');
    }
    this._name = newValue;
  }

  get value() {
    return this._value;
  }

  set value(newValue) {
    if (typeof newValue !== 'number') {
      throw new Error('Value must be a non-negative number');
    }
    if (newValue < 0) {
      throw new Error('Value must be a non-negative number');
    }
    this._value = newValue;
  }

  get VAT() {
    return this._VAT;
  }

  set VAT(newValue) {
    if (typeof newValue !== 'number') {
      throw new Error('VAT must be a non-negative number');
    }
    if (newValue < 0) {
      throw new Error('VAT must be a non-negative number');
    }
    this._VAT = newValue;
  }

  get active() {
    return this._active;
  }

  set active(newValue) {
    if (typeof newValue !== 'boolean') {
      throw new Error('Active status must be a boolean');
    }
    this._active = newValue;
  }

  toString() {
    const output = [
      `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
      `- Value (excl. VAT): ${this.value}`,
      `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
    ];
    return output.join('\n');
  }
}

describe('Test class PaymentPackage', function () {
  let current;
  beforeEach(() => {
    current = new PaymentPackage('Pesho', 100);
  });

  it("Test ctor", function () {
    assert.equal(current._name, 'Pesho');
    assert.equal(current._value, 100);
    assert.equal(current._VAT, 20);
    assert.equal(current._active, true);
  });

  it('Test name getter', () => {
    assert.equal(current.name, 'Pesho');
  });

  it('Test name setter', () => {
    assert.throws(() => current.name = '')
    assert.throws(() => current.name = 0);
    assert.doesNotThrow(() => current.name = 'Gosho');
  });

  it('Test value getter', () => {
    assert.equal(current.value, 100);
  });

  it('Test value setter', () => {
    assert.throws(() => current.value = 'f');
    assert.throws(() => current.value = -1);
    assert.doesNotThrow(() => current.value = 0);
  });

  it('Test VAT getter', () => {
    assert.equal(current.VAT, 20);
  });

  it('Test VAT setter', () => {
    assert.throws(() => current.VAT = -1.1);
    assert.throws(() => current.VAT = '1');
    assert.doesNotThrow(() => current.VAT = 2);
  });

  it('Test active getter', () => {
    assert.equal(current.active, true);
  });

  it('Test active setter', () => {
    assert.throws(() => current.active = '1');
    assert.throws(() => current.active = 1);
    assert.doesNotThrow(() => current.active = false);
  });

  it('Test toString return type', () => {
    const result = current.toString();

    assert.equal(typeof result, 'string');
  });

  it('Test toString contain "inactive" if active == false', () => {
    current.active = false;
    const result = current.toString();
    let index = result.indexOf('inactive');

    assert.equal(index != -1, true);
  });

  it('Test toString text', () => {
    const result = current.toString();

    const expected = 'Package: Pesho\n' +
      '- Value (excl. VAT): 100\n' +
      '- Value (VAT 20%): 120';

    assert.equal(result, expected);

    current.active = false;
    const resultInactive = current.toString();

    const expectedInactive = 'Package: Pesho (inactive)\n' +
      '- Value (excl. VAT): 100\n' +
      '- Value (VAT 20%): 120';

    assert.equal(resultInactive, expectedInactive);
  });

});
