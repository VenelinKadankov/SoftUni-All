function swimming(oldRecord, distance, timeFor1Meter) {
    let delay = Math.floor(Number(distance) / 15) * 12.5;
    let timeIvan = Number(distance) * Number(timeFor1Meter) + delay;
    let difference = Math.abs(timeIvan - Number(oldRecord));

    if (timeIvan >= oldRecord) {
        console.log(`No, he failed! He was ${difference.toFixed(2)} seconds slower.`);
        
    } else {
        console.log(`Yes, he succeeded! The new world record is ${timeIvan.toFixed(2)} seconds.`);
    }
}

swimming(55555.67,
    3017,
    5.03)