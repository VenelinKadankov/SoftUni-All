function fruitShop(fruit, day, quantity) {
    quantity = Number(quantity);
    let price = 0;

    if (day === 'Saturday' || day === 'Sunday') {
        switch (fruit) {
            case 'banana':
                price = 2.70;
                break;
            case 'apple':
                price = 1.25;
                break;
            case 'orange':
                price = 0.90;
                break;
            case 'grapefruit':
                price = 1.60;
                break;
            case 'kiwi':
                price = 3.0;
                break;
            case 'pineapple':
                price = 5.60;
                break;
            case 'grapes':
                price = 4.20;
                break;
        }
    } else {
        switch (fruit) {
            case 'banana':
                price = 2.50;
                break;
            case 'apple':
                price = 1.20;
                break;
            case 'orange':
                price = 0.85;
                break;
            case 'grapefruit':
                price = 1.45;
                break;
            case 'kiwi':
                price = 2.70;
                break;
            case 'pineapple':
                price = 5.50;
                break;
            case 'grapes':
                price = 3.85;
                break;
        }
    }
    let totalPrice = price * quantity;
    let fruitArr = ['banana', 'apple', 'orange', 'grapefruit', 'kiwi', 'pineapple', 'grapes'];
    let dayArr = ['Monday', 'Tuesday','Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    if (fruitArr.includes(fruit) && dayArr.includes(day)){
        console.log(totalPrice.toFixed(2));
    } else {
        console.log('error');
    }
}

fruitShop('apple',
    'Tuesday',
    2)