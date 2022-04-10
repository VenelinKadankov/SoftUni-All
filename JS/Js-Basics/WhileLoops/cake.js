function birthday(input){

    let cakeWidth = Number(input.shift());
    let cakeLength = Number(input.shift());
    let pieces = cakeWidth * cakeLength;
    let isEnough = true;
    let notEnough = 0;

    let command = input.shift();

    while(command !== 'STOP'){
        let eaten = Number(command);
        pieces -= eaten;

        if(pieces < 0){
            notEnough = Math.abs(pieces);
            isEnough = false;
            break;
        }

        command = input.shift();
    }

    if(isEnough){
        console.log(`${pieces} pieces are left.`);
    } else {
        console.log(`No more cake left! You need ${notEnough} pieces more.`);
    }

}

// birthday(['10',
//     '10',
//     '20',
//     20,
//     20,
//     20,
//     21])

birthday([10,
    2,
    2,
    4,
    6,
    'STOP'])