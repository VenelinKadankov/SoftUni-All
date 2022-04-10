function solve(input) {

    let studentsMap = new Map();

    for(let i = 0; i < input.length; i++){
        let line = input[i].split(' ');
        let name = line.shift();
        let grades = [...line];
        grades.forEach(a => a = Number(a));
        // console.log(grades);

        if(!studentsMap.has(name)){
            studentsMap.set(name, grades);
        } else {
            studentsMap.get(name).push(...grades);
        }
    }

    let gradesArr = Array.from(studentsMap.entries());

    let sortedArr = gradesArr.sort((a,b) => {

        let averageA = a[1].reduce((x , y) => x + y) / a[1].length;
        let averageB = b[1].reduce((k ,j ) => k + j) / b[1].length;
        return averageA - averageB;
    });

    let sortedObj = Object.fromEntries(sortedArr);
    let sortedMap = new Map(Object.entries(sortedObj));
    for(const[name, grades] of sortedMap){
        console.log(`${name}: ${grades.join(', ')}`);
    }
    // console.log(gradesArr);
     //console.log(sortedObj);
}

solve(['Lilly 4 6 6 5',
    'Tim 5 6',
    'Tammy 2 4 3',
    'Tim 6 6'])