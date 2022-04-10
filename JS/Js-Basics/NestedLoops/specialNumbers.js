function solve(num){

    let n = Number(num);
    let outputArr = [];

    for (let i = 1; i < 10; i++){
        for(let j = 1; j < 10; j++){
            for(let k = 1; k < 10; k++){
                for(let m = 1; m < 10; m++){
                    if(n % i === 0 && n % j === 0 && n % k === 0 && n % m === 0){
                        outputArr.push(`${i}${j}${k}${m}`);
                    }
                }
            }
        }
    }
    console.log(outputArr.join(' '));
}

solve(16)