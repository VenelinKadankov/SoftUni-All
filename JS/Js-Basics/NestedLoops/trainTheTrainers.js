function solve(input){

    let n = Number(input.shift());
    let average = 0;
    let totalScore = 0;
    let assesment = 0;
    let subject = '';
    let counter = 0;

    let command = input.shift();

    while(command !== 'Finish'){
        subject = command;
        let score = 0;

        for (let i = 0; i < n; i++){
            let grade = Number(input.shift());
            score += grade;
        }
        average = (score / n);
        console.log(`${command} - ${average.toFixed(2)}.`);
        totalScore += average;
        counter++;
        command = input.shift();
    }
    assesment = (totalScore / counter).toFixed(2);
    console.log(`Student's final assessment is ${assesment}.`);
}

solve([2,
    'Objects and Classes',
    5.77,
    4.23,
    'Dictionaries',
    4.62,
    5.02,
    'RegEx',
    2.88,
    3.42,
    'Finish'])