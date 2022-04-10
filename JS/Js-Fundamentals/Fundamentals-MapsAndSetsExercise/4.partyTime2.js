function solve(input) {

    let partyList = {
        vip: [],
        regular: []
    };

    let invitedList = input.splice(0, input.indexOf('PARTY'));
    let comingList = input.splice(1);

    //invitedList.forEach(guest => {
    for (let guest of invitedList) {
        //if (guest.length === 8) {
            if (Number.isInteger(+guest[0])) {
                partyList.vip.push(guest);
            } else {
                partyList.regular.push(guest);
            }
        //}
    };


    // });


    //comingList.forEach(guest => {
    for (let guest of comingList) {
        //if (guest.length === 8) {
            if (partyList.vip.includes(guest)) {
                partyList.vip.splice(partyList.vip.indexOf(guest), 1);
            } else if (partyList.regular.includes(guest)) {
                partyList.regular.splice(partyList.regular.indexOf(guest), 1);
            }

        //}
    }

    //});

    let listLength = partyList.vip.length + partyList.regular.length;
    console.log(listLength);
    partyList.vip.forEach(a => console.log(a));
    partyList.regular.forEach(b => console.log(b));

}

solve(['7IK9Yo0h',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc',
    'tSzE5t0p',
    'PARTY',
    '9NoBUajQ',
    'Ce8vwPmE',
    'SVQXQCbc'
])