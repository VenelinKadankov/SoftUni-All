function flightSchedule(input) {
    let flightInfo = input[0];
    let flightChanges = input[1];
    let searchedWord = input[2][0];

    function objectMaker(arr) {
        let flightObjArr = [];

        for (let el of arr) {
            let flight = el.split(' ');
            let number = flight.shift();
            destination = flight.join(' ');
            let obj = {
                flight: number,
                destination: destination
            };
            flightObjArr.push(obj);
        }

        return flightObjArr;
    }

    let flights = objectMaker(flightInfo);
    let originalList = flights.slice();
    let changes = objectMaker(flightChanges);
    let readyToFlyArr = [];
    let cancelledArr = [];

    for (let i = 0; i < changes.length; i++) {
        let anouncement = changes[i];

        for (let j = 0; j < flights.length; j++) {
            let checkedFlight = flights[j];
            if (anouncement.flight === checkedFlight.flight && anouncement.destination === 'Cancelled') {
                let cancelledFlight = flights.splice(flights.indexOf(checkedFlight), 1);
                cancelledArr.push(cancelledFlight);
            }
        }

    }
    if (searchedWord === 'Cancelled') {
        let newArr = cancelledArr.concat.apply([], cancelledArr);
        newArr.sort(function(a,b) {
            return originalList.indexOf(a) - originalList.indexOf(b);
        });
        newArr.forEach(el => console.log(`{ Destination: ${el.destination}, Status: Cancelled }`));
    } else {
        flights.forEach(el => console.log(`{ Destination: ${el.destination}, Status: Ready to fly }`));
    }
}

flightSchedule([['WN269 Delaware',
    'FL2269 Oregon',
    'WN498 Las Vegas',
    'WN3145 Ohio',
    'WN612 Alabama',
    'WN4010 New York',
    'WN1173 California',
    'DL2120 Texas',
    'KL5744 Illinois',
    'WN678 Pennsylvania'],
['DL2120 Cancelled',
    'WN612 Cancelled',
    'WN1173 Cancelled',
    'SK430 Cancelled'],
['Cancelled']
])