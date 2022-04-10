function clever(age, priceWasher, priceToy) {
    age = Number(age);
    priceWasher = Number(priceWasher);
    priceToy = Number(priceToy);
    let moneyFromBirthdays = 0;
    let increseMoney = 10;
    let moneyFromToys = 0;
    let toys = 0;
    let totalMoney = 0;

    for (let i = 1; i <= age; i++) {
        if (i % 2 === 0) {
            moneyFromBirthdays += increseMoney;
            moneyFromBirthdays -= 1;
            increseMoney += 10;
        }
        else if (i % 2 !== 0) {
            toys += 1;
        }
    }

    moneyFromToys = toys * priceToy;
    totalMoney = moneyFromToys + moneyFromBirthdays;
    let diff = Math.abs(totalMoney - priceWasher).toFixed(2);

    if (totalMoney >= priceWasher){
        console.log(`Yes! ${diff}`);
    } else {
        console.log(`No! ${diff}`);
    }

}

clever(10,
    170.00,
    6)