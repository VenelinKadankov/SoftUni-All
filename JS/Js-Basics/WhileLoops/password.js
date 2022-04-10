function solve(input){
    let name = input.shift();
    let pass = input.shift();
    let isRight = true;

    let command = input.shift();

    while (command !== pass){
        isRight = false;
        command = input.shift();
        if(command === pass){
            isRight = true;
            break;
        }
    }
    if(isRight){
        console.log(`Welcome ${name}!`)
    }
}

solve(['Nakov',
    1234,
    'pass',
    1324,
    1234])