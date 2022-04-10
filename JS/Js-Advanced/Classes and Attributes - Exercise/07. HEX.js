class Hex {
    constructor(number) {
        this.number = number;
    }

    valueOf() {
        return this.number;
    }

    toString() {
        return '0x' + this.number.toString(16).toUpperCase();
    }

    plus(number) {
        return new Hex(this.number + number);
    }

    minus(number) {
        return new Hex(this.number - number);
    }

    parse(string) {
        const result = parseInt(string, 16);;
        return result;
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');

//let Hex = result;
// let FF = new Hex(255);
// let actual = FF.toString();
// let expected = "0xFF";
// console.log(actual == expected);
// console.log(FF.valueOf() + 1 == 256);
// let a = new Hex(10);
// let b = new Hex(5);
// let act = a.plus(b).toString();
// let exp = "0xF";
// console.log(act == exp);
