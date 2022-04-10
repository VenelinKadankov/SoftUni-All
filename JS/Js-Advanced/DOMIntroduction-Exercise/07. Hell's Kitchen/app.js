function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const input = document.querySelector('#inputs>textarea');

   function onClick() {
      let text = JSON.parse(input.value);

      let restaurants = {};

      let bestRestaurant = '';
      let bestSalary = 0;
      let bestAverage = 0;
      let bestWorkers = [];

      for (const element of text) {
         let [name, employees] = element.split(' - ');
         employees = employees.split(', ');
         let averageSalary = 0;
         let maxSalary = 0;

         //console.log(name);

         let workers = [];

         for (const emp of employees) {
            let [name, salary] = emp.split(' ');
            salary = Number(salary);

            workers.push({ name, salary });
         }

         if (restaurants[name] == null) {
            restaurants[name] = name;
            restaurants.name = [];
         }

         workers = workers.concat(restaurants.name).sort((x, y) => y.salary - x.salary);

         restaurants.name = workers;

         averageSalary = workers.reduce((acc, el) => {
            return acc += el.salary / workers.length;
         }, 0);

         //console.log(averageSalary);

         maxSalary = workers[0].salary;
         //console.log(maxSalary);

         if (averageSalary > bestAverage) {
            bestAverage = averageSalary;
            bestSalary = maxSalary;
            bestRestaurant = name;
            bestWorkers = workers;
            //console.log(bestRestaurant);
         }
      }

      let outputString = '';

      for (const iterator of bestWorkers) {
         outputString += `Name: ${iterator.name} With Salary: ${iterator.salary} `;
      }

      document.querySelector('#bestRestaurant>p').innerHTML = `Name: ${bestRestaurant} Average Salary: ${bestAverage.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
      document.querySelector('#workers>p').innerHTML = outputString.trim();
   }
}