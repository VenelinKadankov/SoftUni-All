function solve(input) {
    let energy = Number(input.shift());
    let battles = input;
    let battleCounter = 0;
    let command = battles.shift();

    while (command !== "End of battle") {
        let battle = Number(command);
        battleCounter++;

        if (battleCounter % 3 === 0) {
            energy += battleCounter;
        }

        if (energy >= battle) {
            energy -= battle;

            if (energy === 0) {
                console.log(`Not enough energy! Game ends with ${battleCounter} won battles and ${energy} energy`);
                break;
            }
        } else {
            console.log(`Not enough energy! Game ends with ${battleCounter - 1} won battles and ${energy} energy`);
            break;
        }


        command = battles.shift();
        if (command === "End of battle") {
            console.log(`Won battles: ${battleCounter}. Energy left: ${energy}`);
            break;
        }

    }

}

solve([100,
    10,
    10,
    10,
    1,
    2,
    3,
    73,
    10,
    "End of battle"
])