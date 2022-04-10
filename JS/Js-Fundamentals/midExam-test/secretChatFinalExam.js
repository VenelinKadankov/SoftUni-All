function secretChat(input) {

    let message = input.shift();
    let startMessage = message;

    let command = input.shift();

    while (command !== 'Reveal') {
        let tokens = command.split(':|:');
        let action = tokens[0];
        message = message.split('');

        if (action === 'InsertSpace') {
            let index = Number(tokens[1]);
           // message = message.split('');
            message.splice(index, 0, ' ');
            message = message.toString();

        } else if (action === 'Reverse') {
            let string = tokens[1];
            if (startMessage.includes(string)){
                console.log('yes');
            }

        } else if (action === 'ChangeAll') {
            let firstChar = tokens[1];
            let secondChar = tokens[2];
            // message = message.split('');
            // message.forEach(a => a === firstChar ? a = secondChar: 0);
            for(let i= 0; i < message.length; i++){
                if (message[i] === firstChar){
                    message[i] = secondChar;
                }
            }
            message = message.join('');
        }


        command = input.shift();
    }
    console.log(message);
}

secretChat(['heVVodar!gniV',
    'ChangeAll:|:V:|:l',
    'Reverse:|:!gnil',
    'InsertSpace:|:5',
    'Reveal'
])

// secretChat(['Hiware?uiy',
//     'ChangeAll:|:i:|:o',
//     'Reverse:|:?uoy',
//     'Reverse:|:jd',
//     'InsertSpace:|:3',
//     'InsertSpace:|:7',
//     'Reveal'
// ])