function solve(arr) {
    const result = {};

    for (const item of arr) {
        let[make, model, quantity] = item.split(' | ');
        quantity = Number(quantity);

        if(!result[make]){
            result[make] = {};
        }

        if(!result[make][model]){
            result[make][model] = 0;
        }

        result[make][model] += quantity;
    }

    for (const make in result) {
        console.log(`${make}`);

        for (const model in result[make]) {
            console.log(`###${model} -> ${result[make][model]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
)