function examSubmitions(countStudents, countTasks) {

    let students = Number(countStudents);
    let tasks = Number(countTasks);

    let extraSubmitions = students * (Math.floor(tasks / 3));
    let counterTasks = students * (Math.ceil(tasks * 2.8)) + extraSubmitions;

    let neededMB = Math.ceil(counterTasks / 10) * 5;

    console.log(`${neededMB} KB needed`);
    console.log(`${counterTasks} submissions`);
}

examSubmitions(11,
    7)