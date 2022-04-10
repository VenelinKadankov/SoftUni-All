function solve(input){
    let count = Number(input.shift());
    let total = 0;

    while(input.length > 0){
        let money = Number(input.shift());

        if(money < 0){
            console.log('Invalid operation!');
            break;
        }
        console.log(`Increase: ${money.toFixed(2)}`);
        total += money;
    }
    console.log(`Total: ${total.toFixed(2)}`);

}

solve([5,
    120,
    45.55,
    -150])