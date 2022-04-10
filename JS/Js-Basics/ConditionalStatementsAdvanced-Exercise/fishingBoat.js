function fishingBoat(budget, season, fishermen) {
    budget = Number(budget);
    fishermen = Number(fishermen);
    let priceBoat = 0;
    let discount = 0;

    switch (season) {
        case 'Spring':
        priceBoat = 3000;
            break;
        case 'Summer':
            priceBoat = 4200;
            break;
        case 'Autumn':
            priceBoat = 4200;
            break;
        case 'Winter':
        priceBoat = 2600;
            break;
        default:
            break;
    }

    if (fishermen <= 6) {
        discount = 0.1;
    } else if (fishermen <= 11) {
        discount = 0.15;
    } else {
        discount = 0.25;
    }

    let additionalDiscount = 0;
    if(fishermen % 2 == 0 && season !== 'Autumn'){
        additionalDiscount = 0.05;
    }

    let totalPrice = (priceBoat * (1 - discount)) * (1 - additionalDiscount);
    let difference = Math.abs(totalPrice - budget);

    if (budget >= totalPrice){
        console.log(`Yes! You have ${difference.toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${difference.toFixed(2)} leva.`);
    }

}

fishingBoat(2000,
    'Winter',
    12)