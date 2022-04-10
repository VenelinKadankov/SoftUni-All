function solve(input) {

    let guestList = input.splice(0, input.indexOf('PARTY'));
    let commingGuests = input.splice(1);

    let guestSet = new Set();
    for (let guest of guestList) {
        guestSet.add(guest);
    }

    for (let guest of commingGuests) {
        guestSet.delete(guest);
    }

    let nonArr = Array.from(guestSet);
    for (let i = 0; i < nonArr.length; i++) {
        let chars = nonArr[i].split('');
        let firstChar = chars[0];
        if(firstChar < 10){
            let vip = nonArr.splice(i, 1).toString();
            nonArr.unshift(vip);
        }
    }
    // nonArr.sort((a,b) => {
    //     a = a.split('');
    //     b = b.split('');
    //     let x = a[0].charCodeAt();
    //     let y = b[0].charCodeAt();
    //     return x - y;
    // });
    // console.log(guestSet);
    console.log(nonArr.length);
    nonArr.forEach(a => console.log(a));

}

solve([
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc',
    'tSzE5t0p',
    '7IK9Yo0h',
    'PARTY',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc'
])