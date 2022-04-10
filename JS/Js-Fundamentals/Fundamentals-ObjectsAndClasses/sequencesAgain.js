function solve(input) {
    if (Array.isArray(input)) {

        let arr = [];

        for (let el of input) {
            let parsedArr = JSON.parse(el);
            arr.push(parsedArr);
        }

        arr.forEach(a => a.sort((a, b) => b - a));

        let arrOfStrings = [];
        for (let el of arr) {
            let arrString = el.toString();
            if (!arrOfStrings.includes(arrString)) {
                arrOfStrings.push(arrString);
            }
        }

        let arrayOfUniques = [];
        for (let el of arrOfStrings) {
            let array = el.split(',');
            arrayOfUniques.push(array);
        }

        let finalResultArray = [];

        for (let el of arrayOfUniques) {
            let elArray = []
            for (let x of el) {
                x = Number(x);
                elArray.push(x);
            }
            finalResultArray.push(elArray);
        }

        finalResultArray.sort((a, b) => a.length - b.length);
        finalResultArray.forEach(a => console.log(`[${a.join(', ')}]`));
    }
}

solve(["[0,1,2,3,4,5,6,7]",
    "[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13,5,5,5,5]",
    "[4, -3, 3, -2, 2, -1, 1, 0]",
    "[7.14, 7.180, 7.339, 80.099]",
    "[0,1,2,3,4,5,6,7]"])

// solve(["[7.14, 7.180, 7.339, 80.099]",
//     "[7.339, 80.0990, 7.140000, 7.18]",
//     "[7.339, 7.180, 7.14, 80.099]"])