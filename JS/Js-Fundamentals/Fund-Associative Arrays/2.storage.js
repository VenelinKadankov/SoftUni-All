function solve(input){

    let productsMap = new Map();

    for(const line of input){
        let [product, quantity] = line.split(' ');
        quantity = Number(quantity);


        if(!productsMap.has(product)){
            productsMap.set(product, quantity);
        } else {
            let newQ = productsMap.get(product) + quantity;
            productsMap.set(product, newQ);
        }

    }

    for(const el of productsMap){
        let [prod, count] = el;
        console.log(`${prod} -> ${count}`);
    }

}

solve(['tomatoes 10',
    'coffee 5',
    'olives 100',
    'coffee 40'])