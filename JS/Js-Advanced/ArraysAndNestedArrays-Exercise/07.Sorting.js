function solve(arr){

    let workArr = arr.slice(0).sort((a, b) => a - b);
    let result = [];

    for(let i = 0; i < arr.length; i++){

        let num = 0;

        if(i % 2 == 0){

            num = workArr.shift();

        } else {

            num = workArr.pop();

        }

        result.push(num);
    }

    return result;

}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));