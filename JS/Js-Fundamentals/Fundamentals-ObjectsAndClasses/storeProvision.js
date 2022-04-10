function store(availableProducts, orderedProducts) {
    let outputArr = [];
    let newOrdered = orderedProducts.slice();

    for (let i = 0; i < availableProducts.length; i += 2) {
        let product = availableProducts[i];
        let count = Number(availableProducts[i + 1]);

        for (let j = 0; j < orderedProducts.length; j += 2){
            let orderedProd = orderedProducts[j];
            let orderedCount = Number(orderedProducts[j + 1]);

            if (orderedProd === product){
                count += orderedCount;
                newOrdered.splice(newOrdered.indexOf(orderedProd),2);
            }
        }

        let productObj = {
            product : product,
            count : count,
        };
        outputArr.push(productObj);
    }

    for(let k = 0; k < newOrdered.length; k +=2){
        let diffProd = {
            product : newOrdered[k],
            count : Number(newOrdered[k + 1]),
        }
        outputArr.push(diffProd);
    }
    
    //console.log(outputArr);

    for(let el of outputArr){
        console.log(`${el.product} -> ${el.count}`);
    }
}

store([
    'Chips', '5', 'CocaCola', '9', 'Bananas',
    '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7',
        'Tomatoes', '70', 'Bananas', '30'
    ])