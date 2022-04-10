function solve(input) {

    let n = Number(input.shift());
    let l = Number(input.shift());
    let passwordsArray = [];

    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= n; j++) {
            for (let k = 97; k < 97 + l; k++) {
                for (let r = 97; r < 97 + l; r++) {
                    for (let t = 2; t <= n; t++) {
                        if (t > i && t > j) {
                            let letter1 = String.fromCharCode(k);
                            let letter2 = String.fromCharCode(r);
                            passwordsArray.push(`${i}${j}${letter1}${letter2}${t}`);
                        }
                    }
                }
            }
        }
    }
    console.log(passwordsArray.join(' '));
}

solve([4, 2])