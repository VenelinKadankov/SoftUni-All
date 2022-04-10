function solve(input) {

    let beginning = Number(input.shift());
    let end = Number(input.shift());
    let magical = Number(input.shift());
    let counter = 0;
    let combination = 0;
    let isMagical = false;
    let first = 0;
    let second = 0;

    for (let i = beginning; i <= end; i++){

        for(let j = beginning; j <= end; j++){
            counter++;
            if(i + j === magical){
                isMagical = true;
                combination = counter;
                first = i;
                second = j;
                break;
            }

        }

        if(isMagical){
            break;
        }

    }

    if(isMagical){
        console.log(`Combination N:${combination} (${first} + ${second} = ${magical})`);
    } else {
        console.log(`${counter} combinations - neither equals ${magical}`);
    }

}

solve([1, 10, 5])