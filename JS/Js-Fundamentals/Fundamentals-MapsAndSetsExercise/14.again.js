function dragonArmy(input) {

    let countDragons = Number(input.shift());

    let dragonsMap = new Map();

    for (let line of input) {
        line = line.split(' ');
        let type = line.shift();
        let dragon = new Map();
        let name = line.shift();

        if(dragonsMap.has(type) && dragon.has(name)){
            dragon.set(name, line);
        }

        if(!dragonsMap.has(type)){
            dragonsMap.set(type, []);
            dragonsMap.get(type).push(dragon);
        } else {
            dragonsMap.get(type).push(dragon);
        }

        console.log(dragonsMap);

        if (line[0] === 'null') {
            line[0] = 45;
        }

        if (line[1] === 'null') {
            line[1] = 250;
        }

        if (line[2] === 'null') {
            line[2] = 10;
        }

        let lastDragon = dragon;
    }

}

dragonArmy([4,
    'Gold Zzazx null 1000 10',
    'Gold Traxx 500 null 0',
    'Gold Xaarxx 250 1000 null',
    'Gold Traxx 50000 20000 567890',
    'Gold Ardrax 100 1055 50',
    'Blue Chapi 300 500 6'
])

// dragonArmy([5,
//     'Red Bazgargal 100 2500 25',
//     'Black Dargonax 200 3500 18',
//     'Red Obsidion 220 2200 35',
//     'Black Dargonax 300 350 7000',
//     'Blue Kerizsa 60 2100 20',
//     'Blue Algordox 65 1800 50'
//     ])