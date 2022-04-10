function solve(input) {

    let studentName = input.shift();
    let badGradesCounter = 0;
    let classCounter = 1;
    let gradesCombined = 0;
    let isExpelled = false;

    while (classCounter <= 12) {
        let grade = Number(input.shift());

        if (grade >= 4) {
            classCounter++;
            badGradesCounter = 0;
            gradesCombined += grade;
        } else {
            badGradesCounter++;

            if (badGradesCounter > 1) {
                isExpelled = true;
                break;
            }
        }
    }

    let averageGrade = (gradesCombined / 12).toFixed(2);
    if (isExpelled) {
        console.log(`${studentName} has been excluded at ${classCounter} grade`);
    } else {
        console.log(`${studentName} graduated. Average grade: ${averageGrade}`);
    }
}

solve(['Mimi',
    5,
    6,
    5,
    6,
    5,
    6,
    6,
    2,
    3])

solve(['Gosho',
    5,
    5.5,
    6,
    5.43,
    5.5,
    6,
    5.55,
    5,
    6,
    6,
    5.43,
    5])