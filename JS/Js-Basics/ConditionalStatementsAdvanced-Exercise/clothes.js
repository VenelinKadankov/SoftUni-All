function clothes(degrees, period) {
    degrees = Number(degrees);
    let outfit = '';
    let shoes = '';

    if (degrees >= 10 && degrees <= 18) {
        switch (period) {
            case 'Morning':
                outfit = 'Sweatshirt';
                shoes = 'Sneakers';
                break;
            case 'Afternoon':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            default:
                break;
        }
    } else if (18 < degrees && degrees <= 24) {
        switch (period) {
            case 'Morning':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            case 'Afternoon':
                outfit = 'T-Shirt';
                shoes = 'Sandals';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            default:
                break;
        }
    } else if (25 <= degrees) {
        switch (period) {
            case 'Morning':
                outfit = 'T-Shirt';
                shoes = 'Sandals';
                break;
            case 'Afternoon':
                outfit = 'Swim Suit';
                shoes = 'Barefoot';
                break;
            case 'Evening':
                outfit = 'Shirt';
                shoes = 'Moccasins';
                break;
            default:
                break;
        }
    }
    console.log(`It's ${degrees} degrees, get your ${outfit} and ${shoes}.`);
}

clothes(16,
    'Morning')