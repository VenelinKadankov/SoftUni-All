function solve(input){    //width, length, height, luggage){

    let width = Number(input.shift());
    let length = Number(input.shift());
    let height = Number(input.shift());
    let space = Number(width) * Number (length) * Number(height);
    let isFull = false;

    let command = input.shift();

    while (command !== "Done"){
        let boxes = Number(command);
        space -= boxes;
        if (space < 0){
            isFull = true;
            break;
        }

        command = input.shift();
    }

    if(isFull){
        console.log(`No more free space! You need ${Math.abs(space)} Cubic meters more.`);
    } else {
        console.log(`${space} Cubic meters left.`);
    }
}

// solve(10,
//     10,
//     2,
//     [20,
//     20,
//     20,
//     20,
//     122])

solve([10,
    10,
    2,
    20,
    20,
    20,
    20,
    122])