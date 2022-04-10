function solve(arr) {

    const [town, lat, long] = arr.shift().split('|').map(x => x.trim()).filter(x => x.length > 0);
    const headingObj = {
        town,
        lat,
        long
    }

    const result = [];

    for (const item of arr) {

        let info = item.split('|').map(x => x.trim()).filter(x => x.length > 0);

        let current = {};
        current[town] = info[0];
        current[lat] = Number(Number(info[1]).toFixed(2));
        current[long] = Number(Number(info[2]).toFixed(2));

        result.push(current);
    }

    return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));

console.log(solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
));