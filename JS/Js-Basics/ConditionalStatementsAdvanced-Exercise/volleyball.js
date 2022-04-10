function volleyball(year, holidays, traveled){
    holidays = Number(holidays);
    traveled = Number(traveled);

    let weekends = 48;
    let weekendsInSofia = weekends - traveled;
    let nonWorkWeekends = 3/4 * weekendsInSofia;
    let playingHolidays = 2/3 * holidays;

    let result = nonWorkWeekends + traveled + playingHolidays;
    if (year === 'leap'){
        result = result * 1.15;
    }
    result = Math.floor(result);
    console.log(result);
}

volleyball('normal',
    11,
    6)