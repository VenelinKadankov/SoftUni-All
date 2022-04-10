function beehiveDefence(beeCount, bearHealth, bearAttack){

    // let beeCount = Number(input.shift());
    // let bearHealth = Number(input.shift());
    // let bearAttack = Number(input.shift());
    beeCount = Number(beeCount);
    bearHealth = Number(bearHealth);
    bearAttack = Number(bearAttack);
    let bearWon = false;

    while(bearHealth > 0){
        beeCount -= bearAttack;

        if(beeCount < 100){
            if (beeCount < 0){
                beeCount = 0;
            }

            bearWon = true;
            break;
        }

        bearHealth -= beeCount * 5;

    }

    if(bearWon){
        console.log(`The bear stole the honey! Bees left ${beeCount}.`);
    } else {
        console.log(`Beehive won! Bees left ${beeCount}.`);
    }
}

beehiveDefence(200,
    1000,
    10
    )