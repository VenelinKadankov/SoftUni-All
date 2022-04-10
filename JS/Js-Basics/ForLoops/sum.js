function sum(num) {

    let n = Number(num);
    let result = 0;

    for (let i = 1; i <= n; i++) {
        result += i * i;
    }
    console.log(result);
}

sum(7)