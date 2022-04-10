function wizardPoker(input) {

    let allAvailableCards = input.shift();
    let allCardsArray = allAvailableCards.split(':');
    let cardArray = [];

    let command = input.shift();

    while (command !== 'Ready') {
        command = command.split(' ');
        let action = command[0];
        let card = command[1];
        let index = 0;

        if (action === 'Add') {

            if (allCardsArray.includes(card)) {
                cardArray.push(card);
            } else {
                console.log("Card not found.");
            }

        } else if (action === 'Insert') {
            index = Number(command[2]);

            if (allCardsArray.includes(card) && index >= 0 && index < cardArray.length) {
                cardArray.splice(index, 0, card);
            } else {
                console.log('Error!');
            }

        } else if (action === 'Remove') {

            if (cardArray.includes(card)) {
                cardArray.splice(cardArray.indexOf(card), 1);
            } else {
                console.log("Card not found.");
            }

        } else if (action === 'Swap') {
            let firstCard = command[1];
            let secondCard = command[2];
            cardArray.splice(cardArray.indexOf(firstCard), 1);
            cardArray.splice(cardArray.indexOf(secondCard) + 1, 0, firstCard);

        } else if (action === 'Shuffle') {
            cardArray.reverse();
        }

        command = input.shift();
    }

    console.log(cardArray.join(' '));
}

// wizardPoker(['Innervate:Moonfire:Pounce:Claw:Wrath:Bite',
//     'Add Moonfire',
//     'Add Pounce',
//     'Add Bite',
//     'Add Wrath',
//     'Insert Claw 0',
//     'Swap Claw Moonfire',
//     'Remove Bite',
//     'Shuffle deck',
//     'Ready'
// ])

wizardPoker(['Wrath:Pounce:Lifeweaver:Exodia:Aso:Pop',
    'Add Pop',
    'Add Exodia',
    'Add Aso',
    'Remove Wrath',
    'Add SineokBqlDrakon',
    'Shuffle deck',
    'Insert Pesho 0',
    'Ready'
    ])