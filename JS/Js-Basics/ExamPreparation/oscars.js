function solve(input){

    let nameActor = input.shift();
    let initialPoints = Number(input.shift());
    let acumulatedPoints = initialPoints;
    let jury = Number(input.shift());
    let isNominated = false;

    for (let i = 0; i < jury; i++){
        let nameJury = input.shift();
        let pointsGiven = Number(input.shift());

        let points = (nameJury.length * pointsGiven / 2);
        acumulatedPoints += points;

        if(acumulatedPoints > 1250.5){
            isNominated = true;
            break;
        }

    }

    let pointsNeeded = Math.abs(1250.5 - acumulatedPoints);

    if(isNominated){
        console.log(`Congratulations, ${nameActor} got a nominee for leading role with ${acumulatedPoints.toFixed(1)}!`);
    } else {
        console.log(`Sorry, ${nameActor} you need ${pointsNeeded.toFixed(1)} more!`);
    }
}

solve(['Zahari Baharov',
    205,
    4,
    'Johnny Depp',
    45,
    'Will Smith',
    29,
    'Jet Lee',
    10,
    'Matthew Mcconaughey',
    39
    ])