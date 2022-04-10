function solve(input) {

    let compMap = new Map();

    for (let line of input) {
        let [company, number] = line.split(' -> ');

        if (!compMap.has(company)) {
            compMap.set(company, []);
            compMap.get(company).push(number);
        } else {
            if (!compMap.get(company).includes(number)) {
                compMap.get(company).push(number);
            }

        }
    }

    let arr = Array.from(compMap);
    arr.sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(a => {
            console.log(a[0]);
            a[1].forEach(b => console.log(`-- ${b}`));
        });

}

solve([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'SoftUni -> AA12345',
    'HP -> BB12345'
])