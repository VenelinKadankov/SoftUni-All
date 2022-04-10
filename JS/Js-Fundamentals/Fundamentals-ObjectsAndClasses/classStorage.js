function solve() {

    class Storage {

        constructor(capacity) {
            this.capacity = capacity;
            this.storage = addProduct();
            this.totalCost = calculatePrice();
        }

        addProduct(product){
            storage.product = product;
        }

        getProduct(){
            return storage.product;
        }

        calculatePrice(storage){
            lettotalCost = 0;
            let products = Object.entries(storage);
            for (let i = 0; i < products.length; i += 3){
                let currentPrice = products[i + 1] * products[i + 2];
                totalCost += currentPrice;
            }
                return totalCost;
        }

    }



    let productOne = {
        name: 'Cucamber',
        price: 1.50,
        quantity: 15
    };
    let productTwo = {
        name: 'Tomato',
        price: 0.90,
        quantity: 25
    };
    let productThree = {
        name: 'Bread',
        price: 1.10,
        quantity: 8
    };
    let storage = new Storage(50);
    storage.addProduct(productOne);
    storage.addProduct(productTwo);
    storage.addProduct(productThree);
    storage.getProducts();
    console.log(storage.capacity);
    console.log(storage.totalCost);
}

solve()