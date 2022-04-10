function solve(input) {

    let countGroups = Number(input.shift());
    let counterMusala = 0;
    let counterMonblanc = 0;
    let counterKilimandjaro = 0;
    let counterK2 = 0;
    let counterEverest = 0;

    let counterPeople = 0;

    for (let i = 0; i < countGroups; i++) {
        let group = Number(input.shift());
        counterPeople += group;

        if (group <= 5) {
            counterMusala += group;
        } else if (group <= 12) {
            counterMonblanc += group;
        } else if (group <= 25) {
            counterKilimandjaro += group;
        } else if (group <= 40) {
            counterK2 += group;
        } else if (group > 40) {
            counterEverest += group;
        }

    }

    let musala = (counterMusala / counterPeople * 100).toFixed(2);
    let montblanc = (counterMonblanc / counterPeople * 100).toFixed(2);
    let kilimandjaro = (counterKilimandjaro / counterPeople * 100).toFixed(2);
    let k2 = (counterK2 / counterPeople * 100).toFixed(2);
    let everest = (counterEverest / counterPeople * 100).toFixed(2);

    console.log(`${musala}%`);
    console.log(`${montblanc}%`);
    console.log(`${kilimandjaro}%`);
    console.log(`${k2}%`);
    console.log(`${everest}%`);

}

solve([10,
    10,
    5,
    1,
    100,
    12,
    26,
    17,
    37,
    40,
    78
])