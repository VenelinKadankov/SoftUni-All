function solve(input){

    let command = input.shift();
    let sum = 0;

    while(command !== 'Stop'){
        let num = Number(command);
        sum += num;
        command = input.shift();
    }
    console.log(sum);
}

solve([10,
    20,
    30,
    45,
    'Stop'])