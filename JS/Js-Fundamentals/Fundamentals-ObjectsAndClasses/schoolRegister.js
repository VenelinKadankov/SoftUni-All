function schoolRegister(input) {

    let arr = arrOfArrays(input);
    let continuingStudents = [];
    continuingStudents = arr.filter(a => a['Graduated with an average score'] >= 3);
    continuingStudents.sort((a, b) => a['Grade'] - b['Grade']);

    let allGradesArr = orderingSameGrades(continuingStudents);
    listingAndPrinting(allGradesArr);

    function arrOfArrays(arr) {
        let allStudentsArr = [];
        for (let i = 0; i < input.length; i++) {
            let student = input[i].split(', ');
            let newData = [];

            for (let el of student) {
                el = el.split(': ');
                newData.push(el);
            }

            let studentData = Object.fromEntries(newData);
            allStudentsArr.push(studentData);

        }
        return allStudentsArr;
    }

    function orderingSameGrades(input) {
        let arr = input;

        let outputArr = [];

        let student = arr.shift();
        while (arr.length > 0) {

            let grade = student['Grade'];
            let gradeArr = [];

            gradeArr.push(student);

            while (arr.length > 0 && student['Grade'] === grade) {
                student = arr.shift();
                if (student['Grade'] === grade) {
                    gradeArr.push(student);
                }
            }

            outputArr.push(gradeArr);
        }
        //console.log(outputArr)
        return outputArr;
    }

    function listingAndPrinting(arr) {
        let array = arr;

        for (let i = 0; i < array.length; i++) {
            let gradeKids = array[i];


            let name = '';
            let grade = 0;
            let score = 0;
            let counter = 0;
            for (let j = 0; j < gradeKids.length; j++) {
                counter++;
                score += Number(gradeKids[j]['Graduated with an average score']);
                grade = Number(gradeKids[j]['Grade']) + 1;
                if (name === '') {
                    name = gradeKids[j]['Student name'];
                } else {
                    name = name + " " + (gradeKids[j]['Student name']);
                }

                outputObj = {
                    Score: score,
                    Grade: grade,
                    Name: name
                }

            }
            outputObj.Score = (outputObj.Score / counter).toFixed(2);
            if (outputObj.Grade <= 12) {
                console.log(`${outputObj.Grade} Grade `);
                console.log(`List of students: ${(outputObj.Name).split(' ').join(', ')}`);
                console.log(`Average annual grade from last year: ${outputObj.Score}`);
                console.log('');
            }
        }

    }

}
// schoolRegister(['Student name: Mark, Grade: 8, Graduated with an average score: 4.75',
//     'Student name: Ethan, Grade: 9, Graduated with an average score: 5.66',
//     'Student name: George, Grade: 8, Graduated with an average score: 2.83',
//     'Student name: Steven, Grade: 10, Graduated with an average score: 4.20',
//     'Student name: Joey, Grade: 9, Graduated with an average score: 4.90',
//     'Student name: Angus, Grade: 11, Graduated with an average score: 2.90',
//     'Student name: Bob, Grade: 11, Graduated with an average score: 5.15',
//     'Student name: Daryl, Grade: 8, Graduated with an average score: 5.95',
//     'Student name: Bill, Grade: 9, Graduated with an average score: 6.00',
//     'Student name: Philip, Grade: 10, Graduated with an average score: 5.05',
//     'Student name: Peter, Grade: 11, Graduated with an average score: 4.88',
//     'Student name: Gavin, Grade: 10, Graduated with an average score: 4.00'
// ])

schoolRegister(['Student name: Mark, Grade: 8, Graduated with an average score: 4.75',
    'Student name: Ethan, Grade: 9, Graduated with an average score: 5.66',
    'Student name: George, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Steven, Grade: 10, Graduated with an average score: 4.20',
    'Student name: Joey, Grade: 9, Graduated with an average score: 4.90',
    'Student name: Angus, Grade: 11, Graduated with an average score: 2.90',
    'Student name: Bob, Grade: 11, Graduated with an average score: 5.15',
    'Student name: Daryl, Grade: 8, Graduated with an average score: 5.95',
    'Student name: Bill, Grade: 9, Graduated with an average score: 6.00',
    'Student name: Philip, Grade: 10, Graduated with an average score: 5.05',
    'Student name: Peter, Grade: 11, Graduated with an average score: 4.88',
    'Student name: Gavin, Grade: 10, Graduated with an average score: 4.00'])