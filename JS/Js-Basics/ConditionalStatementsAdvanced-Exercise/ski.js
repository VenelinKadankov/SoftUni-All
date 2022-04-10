function skiTrip(days, typeOfAccomodation, review){
    let nights = Number(days) - 1;
    let discount = 0;
    let pricePerNight = 0;

    if(nights < 9){
        switch(typeOfAccomodation){
            case 'room for one person':
            discount = 0;
            break;
            case 'apartment':
            discount = 0.3;
            break;
            case 'president apartment':
            discount = 0.1;
            break;
        }
    } else if (nights < 14){
        switch(typeOfAccomodation){
            case 'room for one person':
            discount = 0;
            break;
            case 'apartment':
            discount = 0.35;
            break;
            case 'president apartment':
            discount = 0.15;
            break;
        }
    } else {
        switch(typeOfAccomodation){
            case 'room for one person':
            discount = 0;
            break;
            case 'apartment':
            discount = 0.5;
            break;
            case 'president apartment':
            discount = 0.2;
            break;
        }
    }

    switch(typeOfAccomodation){
        case 'room for one person':
        pricePerNight = 18;
        break;
        case 'apartment':
        pricePerNight = 25;
        break;
        case 'president apartment':
        pricePerNight = 35;
        break;
    }

    let priceToPay = pricePerNight * nights * (1 - discount);
    let additionalDiscount = 0;

    if (review === 'positive'){
        additionalDiscount = -0.25;
    } else if (review === 'negative'){
        additionalDiscount = 0.1;
    }

    let priceAfterAllDisc = priceToPay * (1 - additionalDiscount);
    console.log(priceAfterAllDisc.toFixed(2));
}

skiTrip(30,
    'president apartment',
    'negative')