function solve(input) {

    let minNumber = Number.MAX_SAFE_INTEGER;
    let length = Number(input.shift());

    let num = Number(input.shift());
    while (length > 0) {
        length--;
        if (num < minNumber) {
            minNumber = num;
        }

        num = Number(input.shift());
    }


    // for(let i = 0; i < input.length; i++){
    //     let num = input[i];
    //     if (num < minNumber){
    //         minNumber = num;
    //     }


    // }

    console.log(minNumber);
}

solve([4,
    45,
    -20,
    7,
    99])