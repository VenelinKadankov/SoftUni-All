function beehiveRole(intelect, power, gender) {

    intelect = Number(intelect);
    power = Number(power);
    let position = '';

    if (intelect >= 80 && power >= 80 && gender === 'female') {
        position = 'Queen Bee';
    } else if (intelect >= 80) {
        position = 'Repairing Bee';
    } else if (intelect >= 60) {
        position = 'Cleaning Bee';
    } else if (power >= 80 && gender === 'male') {
        position = 'Drone Bee';
    } else if (power >= 60) {
        position = 'Guard Bee';
    } else {
        position = 'Worker Bee';
    }
    console.log(position);
}

beehiveRole(90,
    65,
    'male'
)