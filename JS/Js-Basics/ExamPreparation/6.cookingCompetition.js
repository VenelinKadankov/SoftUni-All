function cooking(input) {

    let competitors = Number(input.shift());
    let counter = 0;
    let money = 0;


    for (let i = 1; i <= competitors; i++) {
        let name = input.shift();
        let cookieCounter = 0;
        let cakeCounter = 0;
        let waffleCounter = 0;

        while (name !== 'Stop baking!') {
            let type = input.shift();
            if (type === 'Stop baking!') {
                break;
            }
            let count = Number(input.shift());
            counter += count;

            switch (type) {
                case 'cookies':
                    cookieCounter += count;
                    break;
                case 'cakes':
                    cakeCounter += count;
                    break;
                case 'waffles':
                    waffleCounter += count;
                    break;
            }
        }
        money += cookieCounter * 1.50 + cakeCounter * 7.80 + waffleCounter * 2.30;
        console.log(`${name} baked ${cookieCounter} cookies, ${cakeCounter} cakes and ${waffleCounter} waffles.`);
    }

    console.log(`All bakery sold: ${counter}`);
    console.log(`Total sum for charity: ${money.toFixed(2)} lv.`);

}

cooking([3,
    'Iva',
    'cookies',
    5,
    'cakes',
    3,
    'Stop baking!',
    'George',
    'cakes',
    7,
    'waffles',
    2,
    'Stop baking!',
    'Ivan',
    'cookies',
    6,
    'Stop baking!'])