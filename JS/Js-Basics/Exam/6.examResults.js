function examResults(input) {


    let command = input.shift();
    while (command !== 'Midnight') {
        let name = command;
        let acumuatedPoints = 0;
        let isCheating = false;

        for (let i = 1; i <= 6; i++) {
            let points = Number(input.shift());

            if (points < 0) {
                isCheating = true;
                // console.log(`${name} was cheating!`);
                break;
            }

            acumuatedPoints += points;
        }

        let result = (Math.floor(acumuatedPoints / 6)) * 0.06;
        
        if(isCheating){
            console.log(`${name} was cheating!`);
        }else if (result >= 5){
            console.log("===================");
            console.log("|   CERTIFICATE   |");
            console.log(`|    ${result.toFixed(2)}/6.00    |`);
            console.log("===================");
            console.log(`Issued to ${name}`);
        } else if (result < 3){
            result = 2;
            console.log(`${name} - ${result.toFixed(2)}`)
        } else {
            console.log(`${name} - ${result.toFixed(2)}`);
        }

        command = input.shift();
    }

}

examResults(['George',
    100,
    100,
    100,
    100,
    40,
    0,
    'John',
    10,
    -1,
    'Peter',
    100,
    100,
    100,
    100,
    100,
    70,
    'Midnight'
])