function solve(input) {

    let neighbourhoods = new Map();

    input.shift()
        .split(', ')
        .forEach(name => neighbourhoods.set(name, []));

    for (const line of input) {
        let [neighbourhoodName, person] = line.split(' - ');

        if (neighbourhoods.has(neighbourhoodName)) {
            neighbourhoods.get(neighbourhoodName)
                .push(person);
        }
    }

    let result = Array.from(neighbourhoods)
        .sort((a, b) => {
            return b[1].length - a[1].length;
        });
    for (const [neighbourHoodName, residents] of result) {
        console.log(`${neighbourHoodName}: ${residents.length}`);

        residents.forEach(a => console.log(`--${a}`));
    }

}

solve(['Abbey Street, Herald Street, Bright Mews',
    'Bright Mews - Garry',
    'Bright Mews - Andrea',
    'Invalid Street - Tommy',
    'Abbey Street - Billy'])