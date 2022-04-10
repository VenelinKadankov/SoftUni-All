function solve(arr) {

    let result = [];

    for (let prod of arr) {
        let [town, product, currentPrice] = prod.split(' | ').filter(x => x.length > 0);
        currentPrice = Number(currentPrice);

        let current = {
            product,
            town,
            price : currentPrice

        }

        if (!result.find(x => x.product === product)) {
            result.push(current);

        }

        let prodToCompare = result.find(x => x.product === product);

        if (prodToCompare.price > currentPrice) {
            prodToCompare.price = currentPrice;
            prodToCompare.town = town;
        }
    }

    for (let prod of result) {
        console.log(`${prod.product} -> ${prod.price} (${prod.town})`);
    }
}

// solve(['Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10']
// );

solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000']
);