function solve(input) {

    let compObj = {};

    for (let line of input) {
        let [company, number] = line.split(' -> ');

        if (!compObj.hasOwnProperty(company)) {
            compObj[company] = (company, []);
        }

        if (!compObj[company].includes(number)) {
            compObj[company].push(number);
        }

    }

    let arr = Object.entries(compObj)
        .sort((a, b) => a[0]
            .localeCompare(b[0]))
        .forEach(y => {
            console.log(`${y[0]}`);
            y[1].forEach(x => console.log(`-- ${x}`));

        });

}


solve([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'HP -> BB12345'
])