function solve(myObj) {

    const small = { power: 90, volume: 1800 };
    const normal = { power: 120, volume: 2400 };
    const monster = { power: 200, volume: 3500 };

    const hatchback = { type: 'hatchback', color: 'any' };
    const coupe = { type: 'coupe', color: 'any' };

    let engine = {};

    if (myObj.power == 90) {
        engine = small;
    } else if (myObj.power == 120) {
        engine = normal;
    } else if (myObj.power == 200) {
        engine = monster;
    } else {
        if (myObj.power < 90) {
            engine = small;
        } else if (myObj.power > 90 && myObj.power < 120) {
            engine = normal;
        } else if (myObj.power > 120){ // && myObj.power < 200) 
            engine = monster;
        } else if (myObj.power > 90) {
            engine = monster;
        }
    }

    let size = myObj.wheelsize % 2 === 0 ? --myObj.wheelsize : myObj.wheelsize;

    function factory(myObj, engine, size) {
        let car = {
            model: myObj.model,
            engine: engine,
            carriage: {
                type: myObj.carriage,
                color: myObj.color,
            },
            wheels: [size, size, size, size]
        }

        return car;
    }

    let result = factory(myObj, engine, size);
    return result;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));