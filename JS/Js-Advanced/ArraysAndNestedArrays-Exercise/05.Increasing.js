function solve(arr){

    let result = [];
    let number = Number.MIN_SAFE_INTEGER;

    for(let num of arr){

        if(num >= number){

            number = num;
            result.push(number);

        }
    }

    return result;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ));

console.log(solve([20, 
    3, 
    2, 
    15,
    6, 
    1]
    ));