function solve(input) {

    let counter = 0;
    let command = input.shift();

    while (command !== 'Stop') {

        counter++;

        command = input.shift();
    }
    console.log(counter);
}

solve(['Nakov',
    'SoftUni',
    'Sofia',
    'Bulgaria',
    'SomeText',
    'Stop'])