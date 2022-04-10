function solve(input){
    let command = input.shift();

    while (command !== 'End'){
        let destination = command;
        let budgetNeeded = Number(input.shift());
        let moneySaved = 0;

        while(budgetNeeded > moneySaved){
            let money = Number(input.shift());
            moneySaved += money;

        }

        console.log(`Going to ${destination}!`);

        command = input.shift();
    }

}

solve(['Greece',
    1000,
    200,
    200,
    300,
    100,
    150,
    240,
    'Spain',
    1200,
    300,
    500,
    193,
    423,
    'End'])