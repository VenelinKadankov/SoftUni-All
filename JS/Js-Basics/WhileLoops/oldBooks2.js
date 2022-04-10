function oldBooks(input) {

    let searched = input.shift();
    let number = Number(input.shift());
    let counter = 0;
    let isFound = false;

    while (counter < number) {
        let current = input.shift();
        counter++;

        if (current === searched) {
            isFound = true;
            break;
        }
    }

    if (isFound) {
        console.log(`You checked ${counter-1} books and found it.`);
    } else {
        console.log('The book you search is not here!');
        console.log(`You checked ${number} books.`);
    }

}

oldBooks(['The Spot',
    '4',
    'Hunger Games',
    'Harry Potter',
    'Torronto',
    'Spotify'])