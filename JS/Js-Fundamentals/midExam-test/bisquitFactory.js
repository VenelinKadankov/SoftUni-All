function biscuitFactory(input) {

    let biscuitsPerDay = Number(input.shift());
    let workers = Number(input.shift());
    let competingFactoryProduction = Number(input.shift());

    let biscuitsTotal = 0;

    for (let i = 1; i <= 30; i++) {
        let biscuitsPerDayAll = biscuitsPerDay * workers;

        if (i % 3 === 0) {
            biscuitsPerDayAll *= 0.75;
        }

        biscuitsPerDayAll = Math.floor(biscuitsPerDayAll);
        biscuitsTotal += biscuitsPerDayAll;
    }

    console.log(`You have produced ${biscuitsTotal} biscuits for the past month.`);

    let diff = Math.abs(biscuitsTotal - competingFactoryProduction);
    let percentDiff = diff / competingFactoryProduction * 100;

    if (biscuitsTotal > competingFactoryProduction) {
        console.log(`You produce ${percentDiff.toFixed(2)} percent more biscuits.`);
    } else {
        console.log(`You produce ${percentDiff.toFixed(2)} percent less biscuits.`);
    }
}

biscuitFactory([78,
    8,
    16000
])