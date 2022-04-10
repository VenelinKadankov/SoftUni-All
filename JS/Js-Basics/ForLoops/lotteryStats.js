function lottery(num) {

    num = Number(num);
    let oddSingleCounter = 0;
    let allEvenCounter = 0;
    let oddFinish7 = 0;
    let dividerTo100 = 0;

    for (let i = 1; i <= num; i++) {
        if (i < 10 && i % 2 !== 0) {
            oddSingleCounter++;
        }
        if (i % 2 === 0) {
            allEvenCounter++;
        }
        if (i % 2 !== 0 && i % 10 === 7) {
            oddFinish7++;
        }
        if (100 % i === 0) {
            dividerTo100++;
        }

    }
    console.log(`${(oddSingleCounter / num * 100).toFixed(2)}%`);
    console.log(`${(allEvenCounter / num * 100).toFixed(2)}%`);
    console.log(`${(oddFinish7 / num * 100).toFixed(2)}%`);
    console.log(`${(dividerTo100 / num * 100).toFixed(2)}%`);
}

lottery(49)