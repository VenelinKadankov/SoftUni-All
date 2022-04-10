function solve(input){

    let counter = 0;
    let maxPoints = Number.MIN_SAFE_INTEGER;
    let bestMovie = '';

    let command = input.shift();

    while(command !== 'STOP'){
        let points = 0;
        counter++;
        if(counter > 7){
            console.log('The limit is reached.');
            break;
        }

        let movie = command;

        for(let i = 0; i < movie.length; i++){
            let char = movie[i];
            let charPoints = char.charCodeAt();
            if (65 <= charPoints && charPoints <= 90){
                charPoints -= movie.length;
            } 

            if(97 <= charPoints && charPoints <= 122){
                charPoints -= (movie.length * 2);
            }
            points += charPoints;
        }

        if(points > maxPoints){
            maxPoints = points;
            bestMovie = movie;
        }

        command = input.shift();
    }
    console.log(`The best movie for you is ${bestMovie} with ${maxPoints} ASCII sum.`);
}

solve(['Wrong turn',
    'The maze',
    'Area 51',
    'Night Club',
    'Ice age',
    'Harry Potter',
    'Wizards'
    ])