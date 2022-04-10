function solve(input) {

    let command = input.shift();
    let kidCounter = 0;
    let studentCounter = 0;
    let standardCounter = 0;
    let isFull =false;

    while (command !== 'Finish') {
        let movieName = command;
        let availableSeats = Number(input.shift());
        let secondCommand = input.shift();
        let counter = 0;

        while (secondCommand !== 'End') {
            let ticketType = secondCommand;
            counter++;

            switch (ticketType) {
                case 'student':
                    studentCounter++;
                    break;
                case 'standard':
                    standardCounter++;
                    break;
                case 'kid':
                    kidCounter++;
                    break;
            }

            if(counter >= availableSeats){
                isFull = true;
                break;
            }

            secondCommand = input.shift();
        }
        let percentFull = (counter / availableSeats * 100).toFixed(2);
        console.log(`${movieName} - ${percentFull}% full.`);

        command = input.shift();
    }
    let total = kidCounter + standardCounter + studentCounter;
    let percentStudent = (studentCounter / total * 100).toFixed(2);
    let percentStandard = (standardCounter / total * 100).toFixed(2);
    let percentKid = (kidCounter / total * 100).toFixed(2);
    console.log(`Total tickets: ${total}`);
    console.log(`${percentStudent}% student tickets.`);
    console.log(`${percentStandard}% standard tickets.`);
    console.log(`${percentKid}% kids tickets.`);

}

solve(['The Matrix',
    20,
    'student',
    'standard',
    'kid',
    'kid',
    'student',
    'student',
    'standard',
    'student',
    'End',
    'The Green Mile',
    17,
    'student',
    'standard',
    'standard',
    'student',
    'standard',
    'student',
    'End',
    'Amadeus',
    3,
    'standard',
    'standard',
    'standard',
    'Finish'])