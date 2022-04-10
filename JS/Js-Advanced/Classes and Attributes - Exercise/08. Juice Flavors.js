function solve(arr) {
    const currentJuices = {};
    const result = {};

    for (const item of arr) {
        let[juice, quantity] = item.split(' => ');
        quantity = Number(quantity);

        if(!currentJuices[juice]){
            currentJuices[juice] = 0;
        }

        currentJuices[juice] += quantity;

        while(currentJuices[juice] >= 1000){
            if(!result[juice]){
                result[juice] = 0;
            }

            result[juice]++;
            currentJuices[juice] -= 1000;
        }
    }

    for (const key in result) {
        console.log(`${key} => ${result[key]}`);
    }
}

solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
)

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
)