function solve(input) {

    let setCars = new Set();

    for (let el of input) {
        let [direction, number] = el.split(', ');

        if (direction === 'IN') {
            if (!setCars.has(number)) {
                setCars.add(number);
            }

        } else {
            if (setCars.has(number)) {
                setCars.delete(number);
            }
        }
    }

    let arrCars = Array.from(setCars);
    //console.log(setCars);
    arrCars.sort()
        .forEach(a => console.log(a));
}

solve(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'])