 function solve(input) {
//     let arr = input;

//     let outputArr = [];

//     let student = arr.shift();
//     while (arr.length > 0) {
//         //let student = arr.shift();
//         let name = student['Student name'];
//         let grade = student['Grade'];
//         let gradeArr = [];

//         gradeArr.push(student);

//         while (arr.length > 0 && student['Grade'] === grade) {
//             student = arr.shift();
//             if (student['Grade'] === grade) {
//                 gradeArr.push(student);
//             }
//         }

//         outputArr.push(gradeArr);
//     }
//     //console.log(outputArr)
//     return outputArr;
// }
    let allStudentsArr = input;
    let continuingStudents = allStudentsArr.filter(a => a['Graduated with an average score'] > 5);
    console.log(continuingStudents);

// for (let j = 0; j < allStudentsArr.length; j++) {
//     let currentStudent = allStudentsArr[j];

//     if (currentStudent['Graduated with an average score'] >= 3) {
//         continuingStudents.push(currentStudent);
//     }

 }

solve(
    [
        {
            'Student name': 'Mark',
            'Grade': '8',
            'Graduated with an average score': '4.75'
        },
        {
            'Student name': 'Daryl',
            'Grade': '8',
            'Graduated with an average score': '5.95'
        },
        {
            'Student name': 'Ethan',
            'Grade': '9',
            'Graduated with an average score': '5.66'
        },
        {
            'Student name': 'Joey',
            'Grade': '9',
            'Graduated with an average score': '4.90'
        },
        {
            'Student name': 'Bill',
            'Grade': '9',
            'Graduated with an average score': '6.00'
        },
        {
            'Student name': 'Steven',
            'Grade': '10',
            'Graduated with an average score': '4.20'
        },
        {
            'Student name': 'Philip',
            'Grade': '10',
            'Graduated with an average score': '5.05'
        },
        {
            'Student name': 'Gavin',
            'Grade': '10',
            'Graduated with an average score': '4.00'
        },
        {
            'Student name': 'Bob',
            'Grade': '11',
            'Graduated with an average score': '5.15'
        },
        {
            'Student name': 'Peter',
            'Grade': '11',
            'Graduated with an average score': '4.88'
        }
    ]
)