function solve(...arguments) {
    let result = {};

    for (const arg of arguments) {
        console.log(`${typeof (arg)}: ${arg}`);

        if (!result[typeof (arg)]) {
            result[typeof (arg)] = 0;
        }

        result[typeof (arg)]++;

    }

    Object.keys(result)
        .sort((a, b) => result[b] - result[a])
        .forEach(x => console.log(`${x} = ${result[x]}`))
}

//solve('cat', 42, function () { console.log('Hello world!'); });
//console.log('---------------------------------------');
//solve({ name: 'bob'}, 3.333, 9.999);
console.log('---------------------------------------');
solve(42, 'cat', [], undefined);