function flightSchedule(input) {

    let flightsArray = input.shift();
    let changesArray = input.shift();
    let searchedType = input.shift();
    let type = searchedType.shift();
    let objArray = [];
    let arrayObjChanges = [];
    let cancelledArray = [];
    let readyArray = [];
    let outputArr = flightsArray.slice();

    flightsArray.forEach(a => {
        a = a.split(' ');
        let flightNumber = a.shift();
        let destination = a.join(' ');
        a = {
            flightNumber: flightNumber,
            destination: destination
        };
        objArray.push(a);
        return a;
    });

    changesArray.forEach(a => {
        a = a.split(' ');
        let flightNumber = a[0];
        let status = a[1];
        a = {
            flightNumber : flightNumber,
            status : status
        }
        arrayObjChanges.push(a);
    })


    // for(let i = 0; i < objArray.length; i++){
    //     let flight = objArray[i];

    //     for(let j = 0; j < arrayObjChanges.length; j++){
    //         let checked = arrayObjChanges[j];
    //         if (type === 'Cancelled'){
    //             if(flight.flightNumber === checked.flightNumber){
    //                 cancelledArray.push(flight);
    //                 outputArr.splice(outputArr.indexOf(flight), 1);
    //             }
    //         } 
    //     }
    // }

    for (let i = 0; i< arrayObjChanges.length; i++){
        if(outputArr.hasOwnProperty(arrayObjChanges[i].flightNumber)){
            console.log('yes');
            // outputArr.splice(outputArr.indexOf(),1);
        }

        
    }
    console.log(outputArr);
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