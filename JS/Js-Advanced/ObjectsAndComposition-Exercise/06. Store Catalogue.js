function solve(arr) {

    let result = [];

    for (let i = 0; i < arr.length; i++) {
        let [name, price] = arr[i].split(' : ');

        let current = {
            name,
            price
        }

        if (!result.find(x => x.find(y => y.name[0] === name[0]))) {

            result[result.length] = [current];

        } else {
            
            result.find(x => x.find(y => y.name[0] === name[0])).push(current);
        }

    }

    ;
    result = result.sort((x, y) => x[0].name[0].localeCompare(y[0].name[0]))

    for(let array of result){

        console.log(`${array[0].name[0]}`);

        let ordered = array.sort((x, y) => x.name.localeCompare(y.name));
        
        for (const item of ordered) {

            console.log(`  ${item.name}: ${item.price}`);
        }
    }
    
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);

solve(['Banana : 2',
    'Rubic\'s Cube : 5',
'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);