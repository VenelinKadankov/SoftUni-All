function solve(arr) {

    const resultArr = [];

    for (let i = 0; i < arr.length; i++) {

        let [name, level, items] = arr[i].split(' / ');
        let player = {
            name,
            level: Number(level),
            items: items ? items.split(', ') : []
        };

        resultArr.push(player);
    }

    return JSON.stringify(resultArr);


    // function heroFactory(name, level, items){

    //     let itemsArr = items.split(', ');
    //     let hero = {
    //         name,
    //         level: Number(level),
    //         items: itemsArr ? itemsArr : []
    //     }

    //     return hero;
    // }
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));