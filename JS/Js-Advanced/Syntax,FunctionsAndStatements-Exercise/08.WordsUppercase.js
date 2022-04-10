function solve(text){

    let words = text
    .toUpperCase()
    .match(/[a-zA-Z0-9]*/g)
    .filter(x => x != '');

    console.log(words.join(', '));
    

}

//solve('Hi, how are you?');
solve(';,.?!]=-')
solve('Functions in JS can be nested, i.e. hold other functions');
solve('   Functions in JS cant be nested, i.e. hold other functions   ');