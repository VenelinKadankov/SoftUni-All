function solve(fruitName, weightGrams, priceKg){
        let weight = weightGrams / 1000;
        let price = weight * priceKg;

        console.log(`I need $${price.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruitName}.`)
}

solve('orange', 2500, 1.80)