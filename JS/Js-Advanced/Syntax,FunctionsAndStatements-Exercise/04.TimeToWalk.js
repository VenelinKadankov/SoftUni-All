function solve(steps, footPrint, speedKmH){

    let distance = steps * footPrint;
    let breaks = Math.floor(distance / 500);
    let timeInSeconds = ((distance / 1000) / speedKmH) * 3600;
    let timeWithBreaks = timeInSeconds + breaks * 60;
    let seconds = Math.round(timeWithBreaks % 60);
    let minutes = Math.floor(timeWithBreaks / 60);
    let hours = Math.floor(minutes / 60);

    console.log(`${hours.toString().length < 2 ? '0' + hours : hours}:${minutes.toString().length < 2 ? '0' + minutes : minutes}:${seconds.toString().length < 2 ? '0' + seconds : seconds}`);
}

solve(4000, 0.60, 5)

solve(2564, 0.70, 5.5)