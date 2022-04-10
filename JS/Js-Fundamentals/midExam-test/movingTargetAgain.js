function solve(input) {

    let targets = input.shift().split(' ').map(a => a = Number(a));
    let shotsFired = input;
    let command = shotsFired.shift();

    while (command !== 'End') {
        shot = command.split(' ');
        let action = shot[0];
        let index = Number(shot[1]);
        let power = Number(shot[2]);

        for (let el of targets) {
            if (action === 'Shoot') {

                if (targets.length > index) {
                    targets[index] = targets[index] - power;

                    if (targets[index] <= 0) {
                        targets.splice(index, 1);
                    }
                }
                break;

            } else if (action === 'Add') {
                if (targets.length > index) {
                    targets.splice(index, 0, power);
                } else {
                    console.log("Invalid placement!");
                }
                break;

            } else if (action === 'Strike') {
                if (targets.length <= index || (index + power) >= targets.length) {
                    console.log("Strike missed!");
                } else {
                    targets.splice(index - power, 2 * power + 1);
                }
                break;
            }
        }

        command = shotsFired.shift();
    }

    for (let el of targets) {
        if (el === 0) {
            targets.splice(targets.indexOf(el), 1);
        }
    }
    
    console.log(targets.join('|'));
}


solve(['52 74 23 44 96 110',
    'Shoot 5 10',
    'Shoot 1 80',
    'Strike 2 1',
    'Add 22 3',
    'End'
])