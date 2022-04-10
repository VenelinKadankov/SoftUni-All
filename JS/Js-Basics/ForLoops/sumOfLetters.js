function solve(product, controlNumber, budget) {

    let count = product.length;
    let allPoints = 0;
    let points = 0;
    let price = 0;

    for (let i = 0; i < count; i++) {
        let char = product[i];

        if (char === 'a' || char === 'e' || char === 'i' || char === 'o' || char === 'u' || char === 'y') {
            points = 3;
        } else {
            points = 1;
        }

        allPoints += points;
    }

    price = allPoints * controlNumber;
    let diff = Math.abs(price - budget);

    if (price <= budget){
        console.log(`${product} bought. Money left: ${diff.toFixed(2)}`);
    } else {
        console.log(`Cannot buy ${product}. Product value: ${price.toFixed(2)}`);
    }
}

solve('apple',
    2,
    20)