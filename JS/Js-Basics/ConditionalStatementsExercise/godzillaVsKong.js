function movie(money, actors, clothes){
    let budget = Number(money);
    let extras = Number(actors);
    let priceCostume = Number(clothes);
    let moneyCostumes = extras * priceCostume;
    let decore = 0.1 * budget;

    if (extras > 150){
        moneyCostumes *= 0.9;
    }

    let moneyNeeded = moneyCostumes + decore;
    let difference = Math.abs(moneyNeeded - budget);

    if (moneyNeeded > budget){
        console.log('Not enough money!');
        console.log(`Wingard needs ${difference.toFixed(2)} leva more.`);   
    } else {
        console.log('Action!');
        console.log(`Wingard starts filming with ${difference.toFixed(2)} leva left.`); 
    }
}

movie(20000,
    120,
    55.5)