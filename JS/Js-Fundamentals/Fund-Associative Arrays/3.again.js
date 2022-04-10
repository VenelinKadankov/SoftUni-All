function solve(input) {

    let namesObj = {};
    let studentsMap = new Map();

    for (let el of input) {
        let tokens = el.split(' ');
        let name = tokens.shift();
        let grades = tokens.map(a => a = Number(a));

        if (!studentsMap.has(name)) {
            studentsMap.set(name, []);
            studentsMap.set(name, studentsMap.get(name).concat(grades));
        } else {
            studentsMap.set(name, studentsMap.get(name).concat(grades));
        }

    }

    let sortedArr = Array.from(studentsMap).sort((a, b) => {
        let combinedA = a[1].reduce((x, y) => x + y);
        let combinedB = b[1].reduce((x, y) => x + y);
        let averageA = combinedA / a[1].length;
        let averageB = combinedB / b[1].length;
        return averageA - averageB;
    });

    sortedArr.forEach(a => console.log(`${a[0]}: ${a[1].join(', ')}`));
    // console.log(sortedArr);
    // console.log(studentsMap);
}
solve(['Lilly 4 6 6 5',
    'Tim 5 6',
    'Tammy 2 4 3',
    'Tim 6 6'])