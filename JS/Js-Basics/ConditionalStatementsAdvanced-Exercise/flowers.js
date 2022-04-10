function flowersForHouse(type, count, budget) {
    count = Number(count);
    budget = Number(budget);
    let price = 0;
    let discount = 0;

    switch (type) {
        case 'Roses':
            price = 5;
            break;
        case 'Dahlias':
            price = 3.8;
            break;
        case 'Tulips':
            price = 2.8;
            break;
        case 'Narcissus':
            price = 3;
            break;
        case 'Gladiolus':
            price = 2.5;
            break;
        default:
            break;
    }

    if (type == 'Roses' && count > 80){
        discount = 0.1;
    } else if (type == 'Dahlias' && count > 90){
        discount = 0.15;
    } else if (type == 'Tulips' && count > 80){
        discount = 0.15;
    } else if (type == 'Narcissus' && count < 120){
        discount = -0.15;
    } else if (type == 'Gladiolus' && count < 80){
        discount = -0.2;
    }
    let finalPrice = price * count * (1 - discount);
    let difference = Math.abs(budget - finalPrice);
    
    if (finalPrice > budget){
        console.log(`Not enough money, you need ${difference.toFixed(2)} leva more.`);
    } else {
        console.log(`Hey, you have a great garden with ${count} ${type} and ${difference.toFixed(2)} leva left.`);
    }
}

flowersForHouse('Roses',
    55,
    250)