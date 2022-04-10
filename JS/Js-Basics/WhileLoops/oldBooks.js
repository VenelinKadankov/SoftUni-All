function oldBooks(input) {
    let searchedBook = input.shift();
    let allBooks = Number(input.shift());
    let counter = 0;
    let isFound = false;

    let current = input.shift();

    if (current === searchedBook) {
        isFound = true;
        counter++;
    } else {
        while (current !== searchedBook) {


            if (counter >= allBooks) {
                break;
            }

            current = input.shift();
            if (current === searchedBook) {
                isFound = true;
            }
            counter++;
        }
    }

    if (isFound) {
        console.log(`You checked ${counter} books and found it.`);
    } else {
        console.log('The book you search is not here!');
        console.log(`You checked ${allBooks} books.`);
    }
}

// oldBooks(['Troy',
//     '8',
//     'Stronger',
//     'Life Style',
//     'Troy'])

oldBooks(['The Spot',
    '4',
    'Hunger Games',
    'Harry Potter',
    'Torronto',
    'Spotify'])

// oldBooks(['Bourne',
//     '32',
//     'True Story',
//     'Forever',
//     'More Space',
//     'The Girl',
//     'Spaceship',
//     'Strongest',
//     'Profit',
//     'Tripple',
//     'Stella',
//     'The Matrix',
//     'Bourne'])

// oldBooks(['Alo',
//     '20',
//     'Alo'])