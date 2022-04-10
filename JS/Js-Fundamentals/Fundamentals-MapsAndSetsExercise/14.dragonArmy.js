function dragonArmy(input) {

    let countDragons = Number(input.shift());

    let dragonsArr = [];
    let dragonsMap = new Map();

    for (const line of input) {
        let [type, name, damage, health, defence] = line.split(' ');
        dragonsMap.set(type, []);

        if (damage === 'null') {
            dragonsMap.get(type).push(name, 45, health, defence);
        } else if (health === 'null') {
            dragonsMap.get(type).push(name, damage, 250, defence);
        } else if (defence === 'null') {
            dragonsMap.get(type).push(name, damage, health, 10);
        } else {
            dragonsMap.get(type).push(name, damage, health, defence);
        }
    }

    console.log(dragonsMap);
}

dragonArmy([4,
    'Gold Zzazx null 1000 10',
    'Gold Traxx 500 null 0',
    'Gold Xaarxx 250 1000 null',
    'Gold Ardrax 100 1055 50',
    'Blue Chapi 300 500 6'
])