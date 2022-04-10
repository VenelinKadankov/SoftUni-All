function solve(pow) {

    pow = Number(pow);

    for (let i = 0; i <= pow; i++) {
        if (i % 2 === 0) {
            console.log(Math.pow(2, i));
        }
    }

}

solve(6)