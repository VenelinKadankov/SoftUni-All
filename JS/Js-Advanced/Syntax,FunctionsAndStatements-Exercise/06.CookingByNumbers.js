function solve(num, ...commands){

    let manipulatedNumber = parseInt(num);

    for(let i = 0; i < commands.length; i++){
        let currentCommand = commands[i];

        if(currentCommand == 'chop'){

            manipulatedNumber /= 2;

        } else if(currentCommand == 'dice'){

            manipulatedNumber = Math.sqrt(manipulatedNumber);

        } else if(currentCommand == 'spice'){

            manipulatedNumber++;

        } else if(currentCommand == 'bake'){

            manipulatedNumber *= 3;

        } else if(currentCommand == 'fillet'){

            manipulatedNumber *= 0.8;

        } 

        console.log(manipulatedNumber);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');