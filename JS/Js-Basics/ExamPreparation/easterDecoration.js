function solve(input) {

    let clients = Number(input.shift());
    let totalMoney = 0;
    let productsTotal = 0;

    for (let i = 0; i < clients; i++) {
        let pricePerClient = 0;
        let daylyCounter = 0;
        let command = input.shift();

        while (command !== 'Finish') {
            let priceProduct = 0;
            let product = command;
            daylyCounter++;

            switch (product) {
                case 'basket':
                    priceProduct = 1.50;
                    break;
                case 'wreath':
                    priceProduct = 3.80;
                    break;
                case 'chocolate bunny':
                    priceProduct = 7;
                    break;
            }
            pricePerClient += priceProduct;

            command = input.shift();
        }

        if(daylyCounter % 2 === 0){
            pricePerClient *= 0.8;
        }
        totalMoney += pricePerClient;
        console.log(`You purchased ${daylyCounter} items for ${pricePerClient.toFixed(2)} leva.`);

    }

    let average = (totalMoney / clients).toFixed(2);
    console.log(`Average bill per client is: ${average} leva.`);

}

solve([2,
    'basket',
    'wreath',
    'chocolate bunny',
    'Finish',
    'wreath',
    'chocolate bunny',
    'Finish'
])