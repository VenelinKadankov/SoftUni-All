function solve(speed, area){

    let isInLimit = false;
    let typeOfSpeeding = '';
    let speedOverLimit = 0;
    let speedLimit = GetSpeedLimit(area);

    function GetSpeedLimit(area){
        if(area == 'motorway'){return 130;}
        if(area == 'interstate'){return 90;}
        if(area == 'city'){return 50;}
        if(area == 'residential'){return 20;}
    }

    if(speed > speedLimit && speed <= speedLimit + 20){

        typeOfSpeeding = 'speeding';
        speedOverLimit = speed - speedLimit;

    } else if(speed > speedLimit + 20 && speed <= speedLimit + 40){

        typeOfSpeeding = 'excessive speeding';
        speedOverLimit = speed - speedLimit;

    } else if(speed > speedLimit + 40){

        typeOfSpeeding = 'reckless driving';
        speedOverLimit = speed - speedLimit;

    } else {

        isInLimit = true;

    }

    if(isInLimit){

        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);

    } else {

        console.log(`The speed is ${speedOverLimit} km/h faster than the allowed speed of ${speedLimit} - ${typeOfSpeeding}`)
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');