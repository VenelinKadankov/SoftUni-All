function sum(start, end, divider) {
    start = Number(start);
    end = Number(end);
    divider = Number(divider);

    let result = 0;
    let special = 0;

    for (let i = start; i <= end; i++) {
        if(i % divider === 0){
            special = i;
            result += special;
        }
    }
    console.log(result);
}

sum(10,
    30,
    7)