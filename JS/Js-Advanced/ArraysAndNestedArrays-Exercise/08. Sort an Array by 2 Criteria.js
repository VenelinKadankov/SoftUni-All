function solve(arr) {

    let result = arr.sort((a, b) => a.length - b.length || a.localeCompare(b));

    for (let word of result) {

        console.log(word);
    }
}

solve(['test',
    'Deny',
    'omen',
    'Default']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);