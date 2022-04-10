function solve(input) {

    let garageMap = new Map();

    for (let line of input) {
        let [number, carInfo] = line.split(' - ');
        let carArr = carInfo.split(', ');
        for(let el of carArr){
            let tokens = carArr.shift().split(': ');
            carArr.push(tokens);
        }

        console.log(carArr);
    }

}

solve(['1 - color: blue, fuel type: diesel',
    '1 - color: red, manufacture: Audi',
    '2 - fuel type: petrol',
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'])