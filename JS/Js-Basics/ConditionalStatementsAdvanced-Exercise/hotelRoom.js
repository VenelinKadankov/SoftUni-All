function hotelRoom(month, nights) {
    nights = Number(nights);
    let priceStudio = 0;
    let priceApartment = 0;
    let discountStudio = 0;
    let discountApartment = 0

    switch (month) {
        case 'May':
        case 'October':
            priceStudio = 50;
            priceApartment = 65;
            break;
        case 'June':
        case 'September':
            priceStudio = 75.20;
            priceApartment = 68.70;
            break;
        case 'July':
        case 'August':
            priceStudio = 76;
            priceApartment = 77;
            break;
        default:
            break;
    }

   if (nights > 14 && (month === 'May' || month === 'October')) {
        discountStudio = 0.3;
    } else if (nights > 14 && (month === 'June' || month === 'September')) {
        discountStudio = 0.2;
    } else  if (nights > 7 && (month === 'May' || month === 'October')) {
        discountStudio = 0.05;
    }

    if (nights > 14) {
        discountApartment = 0.1;
    }

    let studio = priceStudio * nights * (1 - discountStudio);
    let apartment = priceApartment * nights * ( 1 - discountApartment);
    console.log(`Apartment: ${apartment.toFixed(2)} lv.`);
    console.log(`Studio: ${studio.toFixed(2)} lv.`);
}

hotelRoom('August',
20)