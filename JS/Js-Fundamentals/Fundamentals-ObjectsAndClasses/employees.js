function employees(input) {

    let arr = [];

    class Employee {
        constructor(name, personalNumber) {
            this.name = name;
            this.personalNumber = personalNumber;
            this.print = () => console.log(`Name: ${name.join(' ')} -- Personal Number: ${personalNumber}`)
        }
    }

    for (let i = 0; i < input.length; i++) {
        let name = input[i].split(' ');
        let currentEmployee = input[i].split('');
        let counter = 0;

        for (let j = 0; j < currentEmployee.length; j++) {
            counter++;
        }

        let employee = new Employee(name, counter);
        employee.print();
    }

}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
])