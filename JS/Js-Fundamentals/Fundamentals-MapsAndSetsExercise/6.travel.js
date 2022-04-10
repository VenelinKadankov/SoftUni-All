function solve(input) {

    let destinations = {};


    for (let line of input) {
        let [country, town, price] = line.split(' > ');
        price = (+price);

        if (!destinations.hasOwnProperty(country)) {
            destinations[country] = []
        }

        let currentTown = destinations[country].find(o => o.town === town);

        if (!currentTown) {
            destinations[country].push({ town, price: price });
        } else if ((price) < currentTown.price) {
            currentTown.price = price;
        }
    }

    let output = '';
    Object.keys(destinations)
        .sort((a, b) => a.localeCompare(b))
        .forEach(country => {
            output += `${country} -> `;
            destinations[country].sort((a, b) => a.price - b.price).forEach(o => {
                output += `${o.town} -> ${o.price} `;
            });
            output += '\n';
        });


   // console.log(destinations);
   console.log(output.trim());
}

solve([
    'Bulgaria > Sofia > 500',
    'Bulgaria > Sopot > 800',
    'France > Paris > 2000',
    'Albania > Tirana > 1000',
    'Bulgaria > Sofia > 200'
])