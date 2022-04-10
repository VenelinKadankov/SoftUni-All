function solve(input) {

    let command = input.shift();
    let stepsWalked = 0;
    let isGoingHome = false;
    let isReached = false;

    while (command !== 'Going home') {
        let steps = Number(command);

        stepsWalked += steps;

        if (stepsWalked >= 10000) {
            isReached = true;
            break;
        }

        command = input.shift();

    }

    if (command === 'Going home') {
        steps = Number(input.shift());
        stepsWalked += steps;
        isGoingHome = true;
    }
    if (stepsWalked >= 10000) {
        isReached = true;
    }

    let diff = Math.abs(10000 - stepsWalked);
    if (isReached) {
        console.log('Goal reached! Good job!');
    } else {
        console.log(`${diff} more steps to reach goal.`);
    }

}

// solve(['1000',
//     '1500',
//     '2000',
//     '6500'])

// solve(['1500',
//     '3000',
//     '250',
//     '1548',
//     '2000',
//     'Going home',
//     '2000'])

// solve(['1500',
//     '300',
//     '2500',
//     '3000',
//     'Going home',
//     '200'])

solve(['125',
    '250',
    '4000',
    '30',
    '2678',
    '4682'])