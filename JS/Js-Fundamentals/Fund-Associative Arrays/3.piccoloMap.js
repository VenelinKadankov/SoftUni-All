function solve(input){

    let parkedMap = new Map();

    for (let line of input){
        let [direction, number] = line.split(', ');

        number = number.split('');
        let startNumber = 0;
        for(let char of number){
            if (char >= 0 && char <= 9){
                startNumber = char;
                break;
            }
        }
         let city = number.splice(0, number.indexOf(startNumber) - 1);
         let plate = number.splice(0, 4);

        if (direction.toUpperCase() === 'IN'){
            parkedMap.set(city, plate);
        } else {
            parkedMap.delete(number);
        }
         
    }
 
    console.log(parkedMap);
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