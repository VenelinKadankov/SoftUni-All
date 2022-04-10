function solve(input) {

    let days = Number(input.shift());
    let moneyCollected = 0;
    let money = 0;
    let winCounter = 0;
    let loseCounter = 0;

    for (let i = 0; i < days; i++) {
        let dayWins = 0;
        let dayLoses = 0;
        let moneyForDay = 0;

        let sport = input.shift();
        let result = input.shift();

        while (sport !== 'Finish') {

            switch (result) {
                case 'win':
                    money = 20;
                    winCounter++;
                    dayWins++;
                    break;
                case 'lose':
                    money = 0;
                    loseCounter++;
                    dayLoses++;
                    break;
            }
            moneyForDay += money;


            sport = input.shift();
            if(sport === 'Finish'){
                break;
            }
            result = input.shift();
        }

        if (dayWins > dayLoses) {
            moneyForDay *= 1.10;
        }

        moneyCollected += moneyForDay;
    }

    if (winCounter > loseCounter) {
        moneyCollected *= 1.2;
        console.log(`You won the tournament! Total raised money: ${moneyCollected.toFixed(2)}`);
    } else {
        console.log(`You lost the tournament! Total raised money: ${moneyCollected.toFixed(2)}`);
    }

}

solve([3,
    'darts',
    'lose',
    'handball',
    'lose',
    'judo',
    'win',
    'Finish',
    'snooker',
    'lose',
    'swimming',
    'lose',
    'squash',
    'lose',
    'table tennis',
    'win',
    'Finish',
    'volleyball',
    'win',
    'basketball',
    'win',
    'Finish',
])