function solve(arr, criteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const result = [];

    arr.forEach(element => {
        const tokens = element.split('|');
        const ticket = new Ticket(tokens[0], tokens[1], tokens[2]);
        result.push(ticket);
    });

    return result.sort((x, y) => typeof x[criteria] == 'number' ?
        x[criteria] - y[criteria] :
        x[criteria].localeCompare(y[criteria]));
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
))

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
))