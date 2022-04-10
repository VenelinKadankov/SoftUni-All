function solve(a) {

    let n = Number(a);
    let current = 1;
    let line = '';
    let isBigger = false;

    for(let rows = 1; rows <= n; rows++){
        for(let cols = 1; cols <= rows; cols++){
            if (current > n){
                isBigger = true;
                break;
            }
            line += current + ' ';
            current++;
        }
        console.log(line);
        line = '';
        if(isBigger){
            break;
        }
    }

}

solve(7)