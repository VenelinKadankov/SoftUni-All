function solve(input) {

    let a1 = Number(input.shift());
    let a2 = Number(input.shift());
    let n = Number(input.shift());

    for (let i = a1; i <= (a2 - 1); i++) {
        for (let j = 1; j <= (n - 1); j++) {
            for (let k = 1; k <= (n / 2 - 1); k++) {
                let first = String.fromCharCode(i);

                if (i % 2 !== 0 && (i + j + k) % 2 !== 0) {
                    console.log(`${first}-${j}${k}${i}`);
                }

            }
        }

    }

}

solve([71,
    74,
    6
])