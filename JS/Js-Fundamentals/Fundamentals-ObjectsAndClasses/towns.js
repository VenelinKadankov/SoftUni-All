function towns(input) {

    for (let el of input) {
        let town = el.split('|');
        let city = town[0].split(' ');
        let townObj ={
            town : city[0],
            latitude : Number(town[1]).toFixed(2),
            longitude : Number(town[2]).toFixed(2),
        }
        console.log(townObj);
    }

}

towns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']);