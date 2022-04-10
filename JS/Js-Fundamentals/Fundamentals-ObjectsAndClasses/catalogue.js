function catalogue(input) {

    let exitList = [];
    let lastFirstLetter = '';

    let sorted = input.sort(function (a,b){
        return a.toLowerCase().localeCompare(b.toLowerCase());
    })

    for(let el of sorted){
        let tokens = el.split(' : ');
        let product = tokens[0];
        let price = Number(tokens[1]);

        let splited = product.split('');
        let firstLetter = splited[0];

        if (firstLetter !== lastFirstLetter){
            console.log(firstLetter);
            lastFirstLetter = firstLetter;
        }
            console.log(`  ${product}: ${price}`);

    }

}

catalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti - Bug Spray : 15',
    'T - Shirt : 10',
    'Tv : 100'
])