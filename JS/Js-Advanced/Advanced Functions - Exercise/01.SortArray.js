function solve(arr, sortCriteria){
    if(sortCriteria == 'asc'){
        arr = arr.sort((a, b) => a - b);
    } else if(sortCriteria == 'desc'){
        arr = arr.sort((a, b) => b - a);
    }

    return arr;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));