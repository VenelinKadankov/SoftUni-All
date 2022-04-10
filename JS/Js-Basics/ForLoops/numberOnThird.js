function solve(num) {

    num = Number(num);

    for (let i = 1; i <= num; i++) {
        if (i % 2 === 0 && num % 2 === 0) {
            console.log(`Current number: ${i}. Cube: ${Math.pow(i, 3)}`);
        } else if (i % 2 !== 0 && num % 2 !== 0) {
            console.log(`Current number: ${i}. Cube: ${Math.pow(i, 3)}`);
        }
    }
}

solve(6)