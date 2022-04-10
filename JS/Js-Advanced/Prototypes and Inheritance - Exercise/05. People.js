function solve() {
    class Employee {
        constructor(name, age) {
            if(new.target === Employee){
                throw new Error('Cannot instantiate directly.');
            }
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let workDone = this.tasks.shift();
            this.tasks.push(workDone);
            console.log(this.name + workDone);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age){
            super(name, age);
            this.tasks.push(` is working on a simple task.`);
        }

    }
    class Senior extends Employee{
        constructor(name, age){
            super(name, age);
            this.tasks.push(` is working on a complicated task.`);
            this.tasks.push(` is taking time off work.`);
            this.tasks.push(` is supervising junior workers.`);
        }
    }
    class Manager extends Employee {
        constructor(name, age){
            super(name, age);
            this.tasks.push(` scheduled a meeting.`);
            this.tasks.push(` is preparing a quarterly report.`);
            this.dividend = 0;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

//solve();


result = solve();
var guy1 = new result.Junior('Peter', 27);
guy1.salary = 1200;
guy1.collectSalary();