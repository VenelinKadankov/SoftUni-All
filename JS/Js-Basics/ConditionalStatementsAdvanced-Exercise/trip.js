function holiday(budget, season) {
    budget = Number(budget);
    let accomodation = '';
    let moneySpent = 0;
    let area = '';

    if (budget <= 100) {
        area = 'Bulgaria';
        switch (season) {
            case 'summer':
            accomodation = 'Camp';
            moneySpent = budget * 0.3;
                break;
            case 'winter':
            accomodation = 'Hotel';
            moneySpent = 0.7 * budget;
                break;

            default:
                break;
        }
    } else if (budget <= 1000) {
        area = 'Balkans';
        switch (season) {
            case 'summer':
            accomodation = 'Camp';
            moneySpent = budget * 0.4;
                break;
            case 'winter':
            accomodation = 'Hotel';
            moneySpent = 0.8 * budget;
                break;

            default:
                break;
        }
    } else {
        area = 'Europe';
        accomodation = 'Hotel';
        moneySpent = budget * 0.9;
    }
    console.log(`Somewhere in ${area}`);
    console.log(`${accomodation} - ${moneySpent.toFixed(2)}`);
}

holiday(50,
    'summer')