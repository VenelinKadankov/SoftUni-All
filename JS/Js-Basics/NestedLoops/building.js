function solve(input) {

    let floorsAll = Number(input.shift());
    let roomsAll = Number(input.shift());
    let counter = 0;
    let isLast = false;
    let singleFloor = '';
    let letter = '';
    let name = '';
    let floorsArray = [];

    for (let i = 1; i <= floorsAll; i++) {
        let floor = i;

        for (let j = 0; j < roomsAll; j++) {
            let room = j;
            name = '';

            if (floorsAll === 1 || i === floorsAll) {
                letter = 'L';
                isLast = true;
            } else if (floor % 2 === 0){
                letter = 'O';
            } else if (floor % 2 !== 0){
                letter = 'A';
            }
            name += letter + floor + room + ' ';
            singleFloor += name;
        }

        floorsArray.unshift(singleFloor);
        singleFloor = '';

        if (isLast) {
            break;
        }

    }
    floorsArray.forEach(a => console.log(a));
}

solve([6, 4])