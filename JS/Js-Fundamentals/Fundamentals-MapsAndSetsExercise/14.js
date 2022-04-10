function dragonArmy(input) {

    let countDragons = Number(input.shift());

    let dragonsMap = new Map();

    for (let line of input) {
        line = line.split(' ');
        let type = line.shift();
        let dragon = line;
        let name = dragon[0];

        if (dragon[1] === 'null') {
            dragon[1] = 45;
        }

        if (dragon[2] === 'null') {
            dragon[2] = 250;
        }

        if (dragon[3] === 'null') {
            dragon[3] = 10;
        }

        if (!dragonsMap.has(type)) {

            dragonsMap.set(type, []);
            dragonsMap.get(type).push(dragon);
        } else {
            if(dragon.includes(name)){
                dragonsMap.get(type).splice()
                dragonsMap.get(type).push(dragon);

            } else {
                dragonsMap.get(type).push(dragon);
            }

        }
    }


    let dragonsArr = Array.from(dragonsMap);

    for (let i = 0; i < dragonsArr.length; i++) {
        let dragType = dragonsArr[i];

        let averageDamage = 0;
        let averageHealth = 0;
        let averageDef = 0;

        for (let j = 0; j < dragType[1].length; j++) {
            let currentDrag = dragType[1][j];
            averageDamage += Number(currentDrag[1]);
            averageHealth += Number(currentDrag[2]);
            averageDef += Number(currentDrag[3]);
        }
        averageDamage = (averageDamage / dragType[1].length).toFixed(2);
        averageHealth = (averageHealth / dragType[1].length).toFixed(2);
        averageDef = (averageDef / dragType[1].length).toFixed(2);

        dragType[1].sort();
        console.log(`${dragType[0]}::(${averageDamage}/${averageHealth}/${averageDef})`);
        dragType[1].forEach(a => console.log(`-${a[0]} -> damage: ${a[1]}, health: ${a[2]}, armor: ${a[3]}`));
    }

}

// dragonArmy([4,
//     'Gold Zzazx null 1000 10',
//     'Gold Traxx 500 null 0',
//     'Gold Xaarxx 250 1000 null',
//     'Gold Ardrax 100 1055 50',
//     'Blue Chapi 300 500 6'
// ])

dragonArmy([5,
    'Red Bazgargal 100 2500 25',
    'Black Dargonax 200 3500 18',
    'Red Obsidion 220 2200 35',
    'Black Dargonax 300 350 7000',
    'Blue Kerizsa 60 2100 20',
    'Blue Algordox 65 1800 50'
    ])