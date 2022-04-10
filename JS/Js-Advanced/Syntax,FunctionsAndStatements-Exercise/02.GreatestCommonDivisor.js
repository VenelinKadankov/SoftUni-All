function solve(a, b){
    let commonDivisor = 1;
    let range = Math.floor(Math.max(a, b));

    for(let i = 2; i < range; i++){
        
        if(a % i == 0 && b % i == 0){
            if(commonDivisor < i){
                commonDivisor = i;
            }
        }
    }

    console.log(commonDivisor);
}


solve(2154, 458)

solve(15, 5)