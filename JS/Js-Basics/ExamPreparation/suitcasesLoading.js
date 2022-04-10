function solve(input) {

    let volume = Number(input.shift());
    let counter = 0;
    let isFull = false;

    let command = input.shift();

    while (command !== 'End') {
        let suitcase = Number(command);
        counter++;

        if (counter % 3 === 0) {
            suitcase *= 1.1;
        }

        if (suitcase <= volume) {
            volume -= suitcase;
            // if (volume === 0) {
            //     isFull = true;
            //     break;
            // }
        } else {
            isFull = true;
            counter--;
            console.log("No more space!");
            break;
        }

        command = input.shift();
        if(command === 'End'){
            console.log("Congratulations! All suitcases are loaded!");
        }
    }

    console.log(`Statistic: ${counter} suitcases loaded.`);
}

solve([1200.2,
    260,
    380.5,
    125.6,
    305,
    'End'
])