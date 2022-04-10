function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }

        // get color() {
        //     return this._color;
        // }
        // set color(value) {
        //     if (typeof value != 'string') {
        //         throw new TypeError;
        //     }

        //     this._color = value;
        // }

        // get gasWeight() {
        //     return this._gasWeight;
        // }
        // set gasWeight(value) {
        //     if (typeof value != 'number') {
        //         throw new TypeError;
        //     }

        //     this._gasWeight = value;
        // }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength
            }
        }

        get ribbon() {
            return this._ribbon;
        }
        // set ribbon(value) {
        //     this._ribbon = value;
        // }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
        // set text(value) {
        //     this._text = value;
        // }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}

solve();