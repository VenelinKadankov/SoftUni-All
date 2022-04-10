function solve(input) {

    let firstEggs = Number(input.shift());
    let secondEggs = Number(input.shift());

    let command = input.shift();

    while (command !== 'End of battle') {

        switch (command) {
            case 'one':
                secondEggs--;
                break;
            case 'two':
                firstEggs--;
                break;
        }

        if (firstEggs <= 0) {
            console.log(`Player one is out of eggs. Player two has ${secondEggs} eggs left.`);
            break;
        } else if (secondEggs <= 0) {
            console.log(`Player two is out of eggs. Player one has ${firstEggs} eggs left.`);
            break;
        }

        command = input.shift();
        if (command === 'End of battle') {
            console.log(`Player one has ${firstEggs} eggs left.`);
            console.log(`Player two has ${secondEggs} eggs left.`);
            break;
        }
    }
}

// solve([5,
//     4,
//     'one',
//     'two',
//     'one',
//     'two',
//     'two',
//     'End of battle'
// ])

solve([6,
    3,
    'one',
    'two',
    'two',
    'one',
    'one'])