function solve(input){

    let cakes = Number(input.shift());
    let maxPointsTillNow = Number.MIN_SAFE_INTEGER;
    let maxPoints = Number.MIN_SAFE_INTEGER;
    let winner = '';

    for(let i = 0; i < cakes; i++){

        let name = input.shift();
        let totalPoints = 0;
        let command = input.shift();

        while (command !== 'Stop'){
            points = Number(command);
            totalPoints += points;

            command = input.shift();
        }
        console.log(`${name} has ${totalPoints} points.`);
        if(totalPoints > maxPoints){
            maxPoints = totalPoints;
            winner = name;
        }

        if(maxPoints > maxPointsTillNow){
            maxPointsTillNow = maxPoints;
            console.log(`${name} is the new number 1!`);
        }
        
    }
    console.log(`${winner} won competition with ${maxPoints} points!`);
}

solve([3,
    'Chef Manchev',
    10,
    10,
    10,
    10,
    'Stop',
    'Natalie',
    8,
    2,
    9,
    'Stop',
    'George',
    9,
    2,
    4,
    2,
    'Stop'
    ])