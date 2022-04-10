function solve(input) {

    let days = Number(input[0]);
    let dailyPlunder = Number(input[1]);
    let expectedPlunder = Number(input[2]);
    let acumulatedPlunder = 0;

    for (let i = 1; i <= days; i++) {
        let daily = dailyPlunder;

        if (i % 3 === 0) {
            daily = 1.5 * dailyPlunder;
        }

        acumulatedPlunder += daily;

        if (i % 5 === 0){
            acumulatedPlunder *= 0.7;
        }
    }

    let percentage = acumulatedPlunder / expectedPlunder * 100;

    if (acumulatedPlunder >= expectedPlunder){
        console.log(`Ahoy! ${acumulatedPlunder.toFixed(2)} plunder gained.`);
    } else {
        console.log(`Collected only ${percentage.toFixed(2)}% of the plunder.`);
    }

}

solve([5,
    40,
    100])