function solve(x1, y1, x2, y2){

    let firstDistance = Math.sqrt(x1 ** 2 + y1 ** 2);
    let secondDistance = Math.sqrt(x2 ** 2 + y2 ** 2);

    let between = Math.sqrt(Math.abs(x1 - x2) ** 2 + Math.abs(y1 - y2) ** 2);

    if(firstDistance % 1 == 0){

        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);

    } else {

        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);

    }

    if(secondDistance % 1 == 0){

        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);

    } else {

        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);

    }

    if(between % 1 == 0){

        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);

    } else {

        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);

    }
}

//solve(3, 0, 0, 4);
//solve(2, 1, 1, 1);
solve(2, 1, 0, 0);