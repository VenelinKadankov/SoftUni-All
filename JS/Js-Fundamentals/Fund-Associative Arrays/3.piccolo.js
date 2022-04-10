function solve(input) {

    let parkedSet = new Set();

    for (let line of input) {
        let [action, number] = line.split(', ');

        
        if (action.toUpperCase() === 'IN') {
            if (!parkedSet.has(number)) {
                parkedSet.add(number);
            }

        } else {
            if (parkedSet.has(number)) {
                parkedSet.delete(number);
            }
        }

    }

    let parkedArr = Array.from(parkedSet);
    parkedArr.sort((a, b) => {
        // let aNumber = Number(a.split('').splice(2, 4).join(''));
        // let bNumber = Number(b.split('').splice(2, 4).join(''));

        let aNumber = [];
        let bNumber = [];

        a = a.split('');
        a.forEach(x => {
            if(x >= 0 && x <= 9){
                aNumber.push(x);
            }
        });

        b = b.split('');
        b.forEach(x => {
            if(x >= 0 && x <= 9){
                bNumber.push(x);
            }
        });

        aNumber = Number(aNumber.join(''));
        bNumber = Number(bNumber.join(''));
        return aNumber - bNumber;
    });

    if (parkedArr.length > 0) {
        parkedArr.forEach(a => console.log(a));
    } else {
        console.log(`Parking Lot is Empty`);
    }

}

solve(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, A9999TT',
    'in, A2866HI',
    'out, CA1234TA',
    'IN, CA2844AA',
    'OUT, A2866HI',
    'in, CA9876HH',
    'IN, CA2822UU'])