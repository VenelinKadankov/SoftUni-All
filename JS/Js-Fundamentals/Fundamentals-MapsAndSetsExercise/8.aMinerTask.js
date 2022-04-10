function solve(input) {

    let obj = {};

    while(input.length > 0){
        material = input.shift();
        quantity = Number(input.shift());

        if(!obj.hasOwnProperty(material)){ 
            obj[material] = (material, []);
            obj[material].push(quantity);
        } else {
           obj[material].push(quantity);
        }

    }

    for(let key in obj){
        obj[key] = obj[key].reduce((a, b) => a + b);
    }

    Object.entries(obj).forEach(a => console.log(`${a[0]} -> ${a[1]}`));
}

solve([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
])

// solve([
//     'gold',
//     '155',
//     'silver',
//     '10',
//     'copper',
//     '17',
//     'gold',
//     '15'
// ])