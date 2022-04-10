function time(h, m) {
    let hour = Number(h);
    let min = Number(m) + 15;

    if (min >= 60) {
        hour++;
        min = min % 60;
    }

    if (hour > 23) {
        hour = 0;
    }

    if (min < 10){
        min = '0' + min;
    }

    console.log(`${hour}:${min}`);
}

time('1',
    '46')