function solve(input) {

    let destinationsMap = new Map();

    for (let line of input) {
        let [country, city, price] = line.split(' > ');
        price = Number(price);
        let firstOcuranceCity = '';
        let oldPrice = 0;
        let cityMap = new Map();

        if (!destinationsMap.has(country)) {
            destinationsMap.set(country, []);

            oldPrice = price;
            firstOcuranceCity = city;
        } else {

            if (city === firstOcuranceCity && price < oldPrice) {
                destinationsMap.get(coutry).delete(cityMap);
            }

        }

        cityMap.set(city, price);
        if(destinationsMap.get(country).includes(city)){
            console.log('-----------------');
        } else {
            destinationsMap.get(country).push(cityMap);
        }
        //destinationsMap.get(country).push(cityMap);

    }

    // for (let el of destinationsMap) {
    //     let countryArr = Array.from(el);
    //     let destinationsArr = countryArr[1];

    //     console.log(destinationsArr);

    // }


    console.log(destinationsMap);
}

solve([
    'Bulgaria > Sofia > 500',
    'Bulgaria > Sopot > 800',
    'France > Paris > 2000',
    'Albania > Tirana > 1000',
    'Bulgaria > Sofia > 200'
])