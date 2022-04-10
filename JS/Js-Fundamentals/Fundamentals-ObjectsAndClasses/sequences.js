function sequences(arrJSON) {

    let resultArr = [];

    for (let el of arrJSON) {
        let numArr = JSON.parse(el);
        numArr.sort((a, b) => b - a);
        resultArr.push(numArr);
    }

    console.log(resultArr);

    for (let i = 0; i < resultArr.length; i++) {
        let el = resultArr.shift();
        for (let num of el) {
            num = parseFloat(num);
        }
        el = el.toString();
        resultArr.push(el);
    }

    let uniqueArrays = resultArr.filter(getUnique);

    function getUnique(el, index, arr) {
        return arr.indexOf(el) === index;
    };


    uniqueArrays.sort((a, b) => a.length === b.length ? 0 : a.length - b.length);

    for (let j = 0; j < uniqueArrays.length; j++) {
        let el = uniqueArrays.shift();
        el = el.split(',');
        uniqueArrays.push(el);
    }

    uniqueArrays.forEach(el => console.log(`[${el.join(', ')}]`));
}

sequences(["[10, 1, -17, 6, 1, 0, 2, 13]", "[4, -3, 3, -2, 2, -1, 1, 0]", "[-3, -2, -1, 0, 1, 2, 3, 4]"])