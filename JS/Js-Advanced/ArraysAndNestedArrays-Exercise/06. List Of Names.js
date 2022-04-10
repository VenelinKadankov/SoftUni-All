function solve(arr){

    let result = arr.sort((a, b) => a.localeCompare(b));

    for(let i = 0; i < result.length; i++){
        console.log(`${i + 1}.${result[i]}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"]);