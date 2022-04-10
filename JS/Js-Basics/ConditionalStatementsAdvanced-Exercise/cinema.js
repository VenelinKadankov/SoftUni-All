function cinema(type, row, col) {
    let r = Number(row);
    let c = Number(col);
    let isWrong = false;

    let premiere = 12;
    let normal = 7.5;
    let discount = 5;
    let totalWinnings = 0;

    switch (type) {
        case 'Premiere':
            totalWinnings = r * c * premiere;
            break;
        case 'Normal':
            totalWinnings = r * c * normal;
            break;
        case 'Discount':
            totalWinnings = r * c * discount;
            break;
        default:
            isWrong = true;
            console.log('Wrong input!');
            break;
    }
    if(!isWrong){
    console.log(`${totalWinnings.toFixed(2)} leva`);
    }
}

cinema('Premiere',
    10,
    12)