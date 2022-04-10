function bonusPoints(arg) {
    let num = Number(arg);
    let bonus = 0;

    if (num <= 100){
        bonus += 5;
    } else if (num <= 1000){
        bonus = num * 0.2;
    } else {
        bonus = num * 0.1;
    }

    if (num % 2 === 0) {
        bonus++;
    }

    if (num % 10 === 5) {
        bonus += 2;
    }

    console.log(bonus);
    console.log(num + bonus);
}

bonusPoints(20)