function solve(input){

    let count = Number(input.shift());
    let maxNum = Number.MIN_SAFE_INTEGER;

    while (input.length > 0){
        let num = Number(input.shift());

        if(num > maxNum){
            maxNum = num;
        }

    }
    console.log(maxNum);
}

solve([4,
    45,
    -20,
    7,
    99])