function solve(input) {
    let countLowGrades = Number(input.shift());
    let counterBad = 0;
    let isBroken = false;
    let totalScore = 0;
    let counter = 0;
    let lastProblem = '';
    let isEnough = false;

    let command = input.shift();
    let grade = Number(input.shift());

    while (command !== 'Enough') {
        totalScore += grade;
        counter++;
        lastProblem = command;

        if (grade <= 4) {
            counterBad++;

            if (counterBad >= countLowGrades) {
                isBroken = true;
                break;
            }

        }

        command = input.shift();
        grade = Number(input.shift());
        if(command === 'Enough'){
            isEnough = true;
        }
    }

    let average = (totalScore / counter).toFixed(2);
    if (isEnough){
        console.log(`Average score: ${average}`);
        console.log(`Number of problems: ${counter}`);
        console.log(`Last problem: ${lastProblem}`);
    } else {
        console.log(`You need a break, ${counterBad} poor grades.`);
    }

}

solve(['3',
    'Money',
    '6',
    'Story',
    '4',
    'Spring Time',
    '5',
    'Bus',
    '6',
    'Enough'])