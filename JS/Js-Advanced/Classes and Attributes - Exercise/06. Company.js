class Company {

    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || username.length === 0 ||
            !salary || salary < 0 ||
            !position || position.length === 0 ||
            !department || department.length === 0) {
            throw new TypeError('Invalid input!')
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        const employee = {
            username,
            salary,
            position
        }

        this.departments[department].push(employee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDept = '';
        let bestAvgSal = 0;

        for (const dept in this.departments) {
            let currentAvgSal = 0;
            let empsInDept = 0;

            for (const employee of this.departments[dept]) {
                currentAvgSal += Number(employee['salary']);
                empsInDept++;
            }

            currentAvgSal /= empsInDept;

            if (currentAvgSal > bestAvgSal) {
                bestAvgSal = currentAvgSal;
                bestDept = dept;
            }
        }

        let result = `Best Department is: ${bestDept}\n` +
            `Average salary: ${bestAvgSal.toFixed(2)}\n`;
        this.departments[bestDept] = this.departments[bestDept]
            .sort((a, b) => a['username'].localeCompare(b['username']))
            .sort((a, b) => b['salary'] - a['salary']);
            for (let i = 0; i < this.departments[bestDept].length; i++) {
                const employee = this.departments[bestDept][i];

                result += `${employee['username']} ${employee['salary']} ${employee['position']}`;

                if( i < this.departments[bestDept].length - 1){
                    result += `\n`;
                }
            }

        return result;
    }
}

// let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(c.bestDepartment());

//let Company = result;
let c = new Company();

let actual1 = c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
let expected1 = "New employee is hired. Name: Stanimir. Position: engineer";
//console.log(c.bestDepartment());

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");

let act = c.bestDepartment();
let exp = "Best Department is: Human resources\nAverage salary: 1675.00\nStanimir 2000 engineer\nGosho 1350 HR";
console.log(c.bestDepartment());