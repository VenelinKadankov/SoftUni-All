function solve(arr, steps) {

    for(let i = 0; i < steps; i++){

        let element = arr.pop();
        arr.unshift(element);
    }

    console.log(arr.join(' '));
}

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
);

solve(['1',
    '2',
    '3',
    '4'],
    2
);