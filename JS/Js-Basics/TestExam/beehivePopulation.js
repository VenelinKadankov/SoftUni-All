function beehivePopulation(initialPopulation, years) {

    initialPopulation = Number(initialPopulation);
    years = Number(years);
    let beeCounter = initialPopulation;

    for (let i = 1; i <= years; i++) {

        let beeTenth = Math.floor(beeCounter / 10);
        beeCounter += beeTenth * 2;

        if(i % 5 === 0){
            let beeFifth = Math.floor(beeCounter / 50);
            beeCounter -= beeFifth * 5;
        }

            let beeTwent = Math.floor(beeCounter / 20);
            beeCounter -= beeTwent * 2;
        
    }

    console.log(`Beehive population: ${beeCounter}`);
}

beehivePopulation(100,
    6
)