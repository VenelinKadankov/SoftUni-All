function solve(input) {

    let targets = input.shift().split(' ').map(a => a = Number(a));
    let indexes = input;
    let hitCounter = 0;

    let command = indexes.shift();

    while (command !== 'End') {
        let indexOfTarget = Number(command);

        for (let i = 0; i < targets.length; i++) {
            let targetValue = 0;
            if (i === indexOfTarget) {
                targetValue = Number(targets[i]);
                targets[i] = -1;
                hitCounter++;
            }

            for (let j = 0; j < targets.length; j++) {
                if (targets[j] <= targetValue && targets[j] !== -1) {
                    targets[j] = targets[j] + targetValue;
                } else if (targets[j] > targetValue && targets[j] !== -1) {
                    targets[j] = targets[j] - targetValue;
                }
            }
        }

        command = indexes.shift();
    }
    console.log(`Shot targets: ${hitCounter} -> ${targets.join(' ')}`);
}

solve(['24 50 36 70',
    0,
    4,
    3,
    1,
    'End'
])