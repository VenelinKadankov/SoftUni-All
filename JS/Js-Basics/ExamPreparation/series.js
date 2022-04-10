function solve(input) {

    let budget = Number(input.shift());
    let countSeries = Number(input.shift());
    let counter = 0;
    let moneySpent = 0;
    let diff = 0;
    let isNotEnough = false;

    for (let i = 0; i < countSeries; i++) {
        let name = input.shift();
        let price = Number(input.shift());

        switch (name) {
            case 'Thrones':
                price *= 0.5;
                break;
            case 'Lucifer':
                price *= 0.6;
                break;
            case 'Protector':
                price *= 0.7;
                break;
            case 'TotalDrama':
                price *= 0.8;
                break;
            case 'Area':
                price *= 0.9;
                break;
        }

        moneySpent += price;
        counter++;
        diff = Math.abs(moneySpent - budget);

        if(moneySpent > budget){
            counter--;
            isNotEnough = true;
           // break;
        }
    }

    if(isNotEnough){
        console.log(`You need ${diff.toFixed(2)} lv. more to buy the series!`);
    } else {
        console.log(`You bought all the series and left with ${diff.toFixed(2)} lv.`);
    }

}

// solve([10,
//     3,
//     'Thrones',
//     5,
//     'Riverdale',
//     5,
//     'Gotham',
//     2
// ])

solve([5,
    2,
    'Area',
    12,
    'Legendarie',
    48])