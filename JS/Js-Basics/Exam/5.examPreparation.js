function examPreparation(countStudents, countTasks, power) {

    let students = Number(countStudents);
    let tasks = Number(countTasks);
    let powerTr = Number(power);
    let isFew = false;
    let counter = 0;
    let questions = 0;

    while (powerTr > 0) {

        // if (students < 10) {
        //     isFew = true;
        //     break;
        // }
        powerTr += tasks * 2;
        counter += tasks;
        students -= tasks;

        powerTr -= students * 2 * 3;
        questions += students * 2;

        if (students < 10) {
            isFew = true;
            break;
        }

        let decimalStudent = Math.floor(students / 10);
        students += 1 * decimalStudent;

    }

    if (isFew) {
        console.log("The students are too few!");
        console.log(`Problems solved: ${counter}`);
    } else {
        console.log("The trainer is too tired!");
        console.log(`Questions asked: ${questions}`);
    }

}

examPreparation(20,
    5,
    500
)