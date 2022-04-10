function flightSchedule(input) {
     let flightInfo = input[0];
    // let flightChanges = input[1];
    // let searchedWord = input[2][0];

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
    // let changes = objectMaker(flightChanges);
    // let readyToFlyArr = [];
    // let cancelledArr = [];

    let arr = [
        [ { flight: 'DL2120', destination: 'Texas' } ],
        [ { flight: 'WN612', destination: 'Alabama' } ],
        [ { flight: 'WN1173', destination: 'California' } ]
      ]

 let newArr = arr.concat.apply([], arr);
 //console.log(newArr);
 let result = [];

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