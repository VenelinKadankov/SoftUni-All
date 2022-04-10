function solve(input) {

    let studentName = input.shift();
    let gradeCounter = 1;
    let gradesCombined = 0;

    while (gradeCounter <= 12) {
        let grade = Number(input.shift());

        if (grade >= 4) {
            gradeCounter++;
            gradesCombined += grade;
        }

    }

    let averageGrade = (gradesCombined / 12).toFixed(2);

    console.log(`${studentName} graduated. Average grade: ${averageGrade}`);

}

solve(['Pesho',
    4,
    5.5,
    6,
    5.43,
    4.5,
    6,
    5.55,
    5,
    6,
    6,
    5.43,
    5])

solve(['Ani',
    5,
    5.32,
    6,
    5.43,
    5,
    6,
    5.5,
    4.55,
    5,
    6,
    5.56,
    6])