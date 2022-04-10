function solve(input){

    let charArr = input.toLowerCase().split(' ');

    let charMap = new Map();

    for (let char of charArr){

        if(!charMap.has(char)){
            charMap.set(char, []);
            charMap.get(char).push(1);
        } else {
            charMap.get(char).push(1);
        }
    }

    for(let line of charMap){
        charMap.set(line[0], line[1].length);

    }

    let arr = Array.from(charMap);
    let output = [];

    for(let i = 0; i < arr.length; i++){
        let line = arr[i];
        if(line[1] % 2 !== 0){
            output.push(line[0]);
        }
    }

    console.log(output.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')