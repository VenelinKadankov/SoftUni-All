function solve(input) {

    let setGuests = new Set();

    let list = input.splice(0, input.indexOf('PARTY')).filter(a => a.length === 8);
    input.shift();
    input.filter(a => a.length === 8);

    for (let guest of input) {
        if (input.includes(guest)) {
            list.splice(list.indexOf(guest), 1);
        }

    }

    console.log(list.length);
    if(list.length > 0){
        list.sort().forEach(a => console.log(a));
    }


}

solve([
    '7IK9Yo0h',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc',
    '9NoBUajQ',
    'tSzE5t0p',
    '7IK9Yo0h',
    '4kdhtonddhu',
    'PARTY',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc'])