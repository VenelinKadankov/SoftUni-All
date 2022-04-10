function dayOfWeek(num){
    num = Number(num);

    let weekObj = {
        1 : 'Monday',
        2 : 'Tuesday',
        3 : 'Wednesday',
        4 : 'Thursday',
        5 : 'Friday',
        6 : 'Saturday',
        7 : 'Sunday'
    }

    if (weekObj.hasOwnProperty(num)){
        console.log(weekObj[num]);
    } else {
        console.log('Error');
    }
}

dayOfWeek(3)