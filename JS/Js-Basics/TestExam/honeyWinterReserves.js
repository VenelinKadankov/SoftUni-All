function honeyWinterReserves(input) {

    let targetHoney = Number(input.shift());
    let isEnough = false;
    let totalHoneyCounter = 0;

    let name = input.shift();

    while(name !== 'Winter has come'){
        let singleBeeHoney = 0;

        for(let i = 0; i < 6; i++){
            let collectedHoney = Number(input.shift());
            singleBeeHoney += collectedHoney;
        }

        if(singleBeeHoney < 0){
            console.log(`${name} was banished for gluttony`);
        }

        totalHoneyCounter += singleBeeHoney;

        if(totalHoneyCounter >= targetHoney){
            isEnough = true;
            break;
        }

        name = input.shift();

    }

    let diff = Math.abs(totalHoneyCounter - targetHoney);

    if(isEnough){
        console.log(`Well done! Honey surplus ${diff.toFixed(2)}.`);
    } else {
        console.log(`Hard Winter! Honey needed ${diff.toFixed(2)}.`);
    }
}

honeyWinterReserves([1000,
    'Maya',
    50,
    10.5,
    19.5,
    30,
    100,
    100,
    'Winter has come'
])

// honeyWinterReserves([1000,
//     'Maya',
//     -50,
//     -10,
//     -20.70,
//     20.40,
//     10.30,
//     40,
//     'Yama',
//     50,
//     10,
//     20,
//     30,
//     100,
//     100,
//     'Winter has come'
//     ])