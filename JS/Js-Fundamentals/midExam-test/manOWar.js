function manOWar(input) {

    let statusPirate = input.shift().split('>').map(a => a = Number(a));
    let statusWarship = input.shift().split('>').map(a => a = Number(a));
    let healthCapacity = Number(input.shift());
    let warshipIsSunk = false;
    let pirateShipIsSunk = false;

    let command = input.shift();

    while (command !== 'Retire') {
        let tokens = command.split(' ');
        let action = tokens[0];
        let index = Number(tokens[1]);
        let damage = Number(tokens[2]);

        if (action === 'Fire') {
            if (index >= 0 && index < statusWarship.length) {
                statusWarship[index] = statusWarship[index] - damage;
                if (statusWarship[index] <= 0) {
                    warshipIsSunk = true;
                    break;
                }
            }
        } else if (action === 'Defend') {
            let index1 = Number(tokens[1]);
            let index2 = Number(tokens[2]);
            let damage = Number(tokens[3]);
            if (index1 >= 0 && index1 < statusPirate.length && index2 >= 0 && index2 < statusPirate.length) {

                for (let i = index1; i <= index2; i++) {

                    statusPirate[i] = statusPirate[i] - damage;
                    if (statusPirate[i] <= 0) {
                        pirateShipIsSunk = true;
                        break;
                    }
                }

            }
        } else if (action === 'Repair') {
            if (index >= 0 && index < statusPirate.length) {
                statusPirate[index] += damage;
                if (statusPirate[index] > healthCapacity) {
                    statusPirate[index] = healthCapacity;
                }
            }

        } else if (action === 'Status') {
            let counter = 0;
            statusPirate.forEach(a => a < 0.2 * healthCapacity ? counter++ : counter);
            console.log(`${counter} sections need repair.`);
        }

        command = input.shift();
    }

    if (pirateShipIsSunk) {
        console.log("You lost! The pirate ship has sunken.");
    } else if (warshipIsSunk) {
        console.log("You won! The enemy ship has sunken.");
    } else {
        console.log(`Pirate ship status: ${statusPirate.reduce((a, b) => a + b)}`);
        console.log(`Warship status: ${statusWarship.reduce((a, b) => a + b)}`);
    }
}

manOWar(['12>13>11>20>66',
    '12>22>33>44>55>32>18',
    '70',
    'Fire 2 11',
    'Fire 8 100',
    'Defend 3 6 11',
    'Defend 0 3 5',
    'Repair 1 33',
    'Status',
    'Retire',
])