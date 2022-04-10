function solve(num){

    let numToString = num.toString();
    let firstNum = parseInt(numToString[0]);
    let length = numToString.length;
    let sum = firstNum;
    let isDifferent = true;

    for(let i = 1; i < length; i++){
        
        let currentNum = parseInt(numToString[i]);

        if(currentNum !== firstNum){
            isDifferent = false;
        }

        sum += currentNum;
    }

    console.log(isDifferent);
    console.log(sum);
}

solve(2222222);

solve(1234);