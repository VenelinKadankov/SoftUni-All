function solve(input) {

    let availableEggs = Number(input.shift());
    let counter = 0;
    let isNotEnough = false;


    let command = input.shift();
    let count = Number(input.shift());

    while (command !== 'Close') {

        switch (command) {
            case 'Fill':
                availableEggs += count;
                break;
            case 'Buy':
                availableEggs -= count;
                counter += count;
                break;
        }

        if(availableEggs < 0){
            availableEggs += count;
            isNotEnough = true;
            break;
        }

        command = input.shift();
        count = Number(input.shift());
    }

    if(isNotEnough){
        console.log("Not enough eggs in store!");
        console.log(`You can buy only ${availableEggs}.`);
    } else {
        console.log("Store is closed!");
        console.log(`${counter} eggs sold.`);
    }

}

solve([20,
    'Fill',
    30,
    'Buy',
    '15',
    'Buy',
    20,
    'Close'
])