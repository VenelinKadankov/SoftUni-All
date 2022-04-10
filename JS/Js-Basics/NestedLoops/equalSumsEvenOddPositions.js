function solve(input){
    let a = Number(input.shift());
    let b = Number(input.shift());
    let outputArray = [];

    for(let i = a; i <= b; i++){
        let oddSum = 0;
        let evenSum = 0;
        let numberArray = i.toString().split('');

        for(let j = 0; j < 6; j++){
            let number = Number(numberArray[j]);
            if(j % 2 === 0 || j === 0){
                evenSum += number;
            } else {
                oddSum += number;
            }
        }

        if(evenSum === oddSum){
            outputArray.push(i);
        }
    }
    console.log(outputArray.join(' '));
}

solve([123456,
    124000])