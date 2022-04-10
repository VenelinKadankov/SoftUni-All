function solve(input){

    let words = new Map();

    while(input.length > 0){
        let currentWord = input.shift();

        if(!words.has(currentWord)){
            words.set(currentWord, [1]);
        } else {
            words.get(currentWord).push(1);
        }
    }


    let arr = Array.from(words.entries());
    let resultArr = [];
    for(const word of arr){
    
        let count = word[1].reduce((a,b) => a + b);
        resultArr.push([word[0], count]);

    }
    resultArr.sort((a,b) => b[1] - a[1]);
    let resultObj = Object.fromEntries(resultArr);
    let resultMap = new Map(Object.entries(resultObj));

    for(const line of resultMap){
        let [word, count] = line;
        console.log(`${word} -> ${count} times`);
    }
}

solve(['Here', 'is', 'the', 'first', 'sentence',
    'Here', 'is', 'another', 'sentence', 'And',
    'finally', 'the', 'third', 'sentence'])