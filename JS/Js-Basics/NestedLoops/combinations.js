function solve(input) {
    let result = Number(input.shift());
    let counter = 0;

    for (let i = 0; i <= result; i++) {

        for (let j = 0; j <= result; j++) {

            for (let k = 0; k <= result; k++) {

                if (i + j + k === result) {
                    counter++;
                }

            }

        }

    }

    console.log(counter);
}

solve([25])