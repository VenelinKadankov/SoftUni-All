function solve(num){

    let number = Number(num);
    let oldNum = 0;
    let newNum = 2 * oldNum + 1;

    while (newNum <= number){
        oldNum = newNum;
        newNum = oldNum * 2  + 1;
        

        console.log(oldNum);
    }

}

solve(1)