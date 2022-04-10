function add(a){
    let sum = 0;
    sum += a;

    function internalSum(b){
        sum += b;
        return internalSum;
    }

    internalSum.toString = () => sum;
    return internalSum;
}

console.log(add(1).toString());
console.log(add(1)(6)(-3).toString())