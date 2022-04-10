function inventory(input) {
    let outputArr = [];

    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(' / ');
        let [name, level, items] = tokens;
        level = Number(level);
        items = items.split(', ').sort().join(', ');
        //console.log(items);

        let obj = {
            name: name,
            level: level,
            items: items,
        }

        outputArr.push(obj);
    }

    outputArr.sort((a, b) => a.level > b.level ? 1 : (a.level <= b.level ? -1 : 0));

    for (let k = 0; k < outputArr.length; k++) {
        let currentHerro = outputArr[k];
        console.log(`Hero: ${currentHerro.name}`);
        console.log(`level => ${currentHerro.level}`);
        console.log(`items => ${currentHerro.items}`);
    }

}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
])