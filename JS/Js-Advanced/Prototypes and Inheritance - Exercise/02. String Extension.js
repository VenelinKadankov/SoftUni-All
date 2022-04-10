(function solve() {
    String.prototype.ensureStart = function (str) {
        let result = this.toString();
        if (!this.startsWith(str)) {
            return str + result;
        }
        return result;
    }
    String.prototype.ensureEnd = function (str) {
        let result = this.toString();
        if (!this.endsWith(str)) {
            return result + str;
        }
        return result;
    }
    String.prototype.isEmpty = function () {
        if (this.length) {
            return false;
        }
        return true;
    }
    String.prototype.truncate = function (n) {

        if (this.length <= n) {
            return this.toString();
        }

        if (n < 4) {
            return '.'.repeat(n);
        }

        if (!this.includes(' ')) {
            return this.toString().slice(0, n - 3) + '...';
        }

        const words = this.toString().split(' ');
        let result = '';

        for (const word of words) {
            let lengthWithNextWord = result.length + word.length + 3;

            if(lengthWithNextWord <= n){
                result += word + ' ';
            } else {
                result = result.trim();
                result += '...';
                return result;
            }

        }
        return this.toString();
    }

    String.format = function (string, ...params) {
        let words = string.split(' ');
        for (let i = 0; i < words.length; i++) {
            if (words[i].startsWith('{') && words[i].endsWith('}')) {
                if (params.length) {
                    words[i] = params.shift();
                }
            }
        }
        return words.join(' ');
    }
})();

var testString = 'quick brown fox jumps over the lazy dog';
// //expect(String.prototype.hasOwnProperty('ensureStart')).to.equal(true, "Couldn't find ensureStart() function");
// var answer = testString.ensureStart('the ');
// console.log(answer);
// answer = answer.ensureStart('the ');
// console.log(answer);

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');