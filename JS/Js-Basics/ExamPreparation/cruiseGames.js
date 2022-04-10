function solve(input) {

    let name = input.shift();
    let countGames = Number(input.shift());
    let counterVolley = 0;
    let pointsVolley = 0;
    let counterTenis = 0;
    let pointsTenis = 0;
    let counterBadmin = 0;
    let pointsBadmin = 0;
    let totalPoints = 0;

    for (let i = 0; i < countGames; i++) {
        let sport = input.shift();
        let points = Number(input.shift());

        switch (sport) {
            case 'volleyball':
                counterVolley++;
                points *= 1.07;
                pointsVolley += points;
                break;
            case 'tennis':
                counterTenis++;
                points *= 1.05;
                pointsTenis += points;
                break;
            case 'badminton':
                counterBadmin++;
                points *= 1.02;
                pointsBadmin += points;
                break;
        }

        totalPoints += points;
    }

    let averageVolley = Math.floor(pointsVolley / counterVolley);
    let averageTenis = Math.floor(pointsTenis / counterTenis);
    let averageBadmin = Math.floor(pointsBadmin/ counterBadmin);

    if(averageVolley >= 75 && averageTenis >= 75 & averageBadmin >= 75){
        console.log(`Congratulations, ${name}! You won the cruise games with ${Math.floor(totalPoints)} points.`);
    } else {
        console.log(`Sorry, ${name}, you lost. Your points are only ${Math.floor(totalPoints)}.`);
    }

}

solve(['Pepi',
    3,
    'volleyball',
    78,
    'tennis',
    98,
    'badminton',
    105])