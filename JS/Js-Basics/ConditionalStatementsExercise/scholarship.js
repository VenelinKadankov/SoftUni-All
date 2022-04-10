function calculate(income, averageGrade, minimalSalary) {
    let salary = Number(income);
    let grade = Number(averageGrade);
    let socialScholarship = 0.35 * Number(minimalSalary);
    let excellenceScholarship = 25 * Number(averageGrade);
    let deservedScholarship = 0;
    let isExcellent = true;

    if (grade >= 5.5) {

        if (salary < Number(minimalSalary)) {

            if (socialScholarship > excellenceScholarship) {
                deservedScholarship = socialScholarship;
                isExcellent = false;
            } else {
                deservedScholarship = excellenceScholarship;
                isExcellent = true;
            }

        }

    } else if (grade >= 4.5) {

        if (salary < Number(minimalSalary)) {
            deservedScholarship = socialScholarship;
            isExcellent = false;
        }

    }

    if (isExcellent === true && grade >= 5.5) {
        console.log(`You get a scholarship for excellent results ${Math.floor(excellenceScholarship)} BGN`)
    } else if (isExcellent === false && grade >= 5.5) {
        console.log(`You get a Social scholarship ${Math.floor(socialScholarship)} BGN`);
    } else if (grade >= 4.5 && salary < Number(minimalSalary)) {
        console.log(`You get a Social scholarship ${Math.floor(socialScholarship)} BGN`);
    } else {
        console.log('You cannot get a scholarship!');
        
    }
}

calculate(300.00,
    5.65,
    420.00)