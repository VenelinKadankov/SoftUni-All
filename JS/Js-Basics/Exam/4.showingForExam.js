function solve(studentCount, countSeasons) {

    let students = Number(studentCount);
    let seasons = Number(countSeasons);

    for (let i = 1; i <= seasons * 2; i++) {
        students = Math.ceil(students * 0.9);
        if (i % 2 === 0) {
            students = Math.ceil(students * 0.8);
            if (i % 6 === 0) {
                students = Math.ceil(students * 1.15);
            } else {
                students = Math.ceil(students * 1.05);
            }


        }
    }

    console.log(`Students: ${students}`);
}

solve(100,
    6
)