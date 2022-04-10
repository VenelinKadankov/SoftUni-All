function interval(num){
    num = Number(num);

    if (-100 <= num && num <= 100 && num !== 0){
        console.log('Yes');
    } else {
        console.log('No');
    }

}

interval(-25)