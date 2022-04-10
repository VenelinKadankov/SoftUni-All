function solve(input) {

    let startPoints = Number(input.shift());
    let isWon = false;
    let isBullseye = false;
    let counter = 0;


    while (startPoints >= 0) {
        let sector = input.shift();
        let points = Number(input.shift());
        counter++;

        switch (sector) {
            case 'number section':

                break;
            case 'double ring':
                points *= 2;
                break;
            case 'triple ring':
                points *= 3;
                break;
            case 'bullseye':
                isBullseye = true;
                break;
        }

        startPoints -= points;

        if (isBullseye) {
            break;
        }

        if (startPoints === 0) {
            isWon = true;
            break;
        } else if (startPoints < 0) {
            isWon = false;
            break;
        }

    }

    if (isBullseye) {
        console.log(`Congratulations! You won the game with a bullseye in ${counter} moves!`);
    } else if (isWon) {
        console.log(`Congratulations! You won the game in ${counter} moves!`);
    } else {
        console.log(`Sorry, you lost. Score difference: ${Math.abs(startPoints)}.`);
    }
}

// solve([150,
//     'double ring',
//     '20',
//     'triple ring',
//     10,
//     'number section',
//     20,
//     'triple ring',
//     20])

solve([75,
    'triple ring',
    17,
    'number section',
    16,
    'triple ring',
    13,
    'double ring',
    10])