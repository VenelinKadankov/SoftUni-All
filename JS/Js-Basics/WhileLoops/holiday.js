function solve(input) {
    let tripPrice = Number(input.shift());
    let availableMoney = Number(input.shift());
    let spendCounter = 0;
    let isImpossible = false;
    let dayCounter = 0;

    while (availableMoney < tripPrice) {
        let action = input.shift();
        let money = Number(input.shift());
        dayCounter++;

        if (action === 'spend') {
            availableMoney -= money;
            spendCounter++;

            if (availableMoney < 0) {
                availableMoney = 0;
            }

            if (spendCounter >= 5) {
                isImpossible = true;
                break;
            }

        } else {
            availableMoney += money;
            spendCounter = 0;
        }

    }

    if (isImpossible) {
        console.log(`You can't save the money.`);
        console.log(`${dayCounter}`);
    } else {
        console.log(`You saved the money for ${dayCounter} days.`);
    }

}

solve(['2000',
    '1000',
    'spend',
    '1200',
    'save',
    '2000'])