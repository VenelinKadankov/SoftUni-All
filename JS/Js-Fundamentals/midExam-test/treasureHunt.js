function treasureHunt(commands) {

    let lootArray = commands.shift().split('|');
    let command = commands.shift();

    while (command !== 'Yohoho!') {
        let tokens = command.split(' ');
        let action = tokens.shift();

        if (action === 'Loot') {

            for (let el of tokens) {

                if (!lootArray.includes(el)) {
                    lootArray.unshift(el);
                }

            }

        } else if (action === 'Drop') {
            let index = Number(tokens[0]);

            if (lootArray.length > index) {
                let item = lootArray.splice(index, 1).toString();
                lootArray.push(item);
            }

        } else if (action === 'Steal') {
            let count = Number(tokens[0]);
            

            if (count >= lootArray.length) {
                console.log(lootArray.join(', '));
                lootArray.length = 0;
            } else {
                let stolen = lootArray.splice((lootArray.length - count), count);
                console.log(stolen.join(', '));
            }

        }

        command = commands.shift();
    }

    let totalLength = 0;

    for (let el of lootArray) {
        totalLength += el.length;
    }

    let averageGain = totalLength / lootArray.length;

    if (lootArray.length > 0) {
        console.log(`Average treasure gain: ${averageGain.toFixed(2)} pirate credits.`);
    } else {
        console.log("Failed treasure hunt.");
    }

}

// treasureHunt(['Gold|Silver|Bronze|Medallion|Cup',
//     'Loot Wood Gold Coins',
//     'Loot Silver Pistol',
//     'Drop 3',
//     'Steal 3',
//     'Yohoho!'
// ])

treasureHunt(['Diamonds|Silver|Shotgun|Gold',
    'Loot Silver Medals Coal',
    'Drop -1',
    'Drop 1',
    'Steal 6',
    'Yohoho!'
])