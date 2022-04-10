function solve(arr) {

    let length = arr.length;
    let flattened = arr.reduce((acc, el) => acc.concat(el));
    let resultSumsCols = [];
    let resultSumsRows = [];
    let isMagic = true;

    let firstSum = arr[0].reduce((acc, c) => acc + c);

    for(let i = 1; i < arr.length; i++){

        let currentSum = arr[1].reduce((acc, c) => acc + c);

        if (firstSum != currentSum) {
            
            isMagic = false;
        }
    }

    for (let i = 0; i < arr[0].length; i++) {
        
        let currentSum = 0;

        for (let r = 0; r < arr.length; r++) {
            
            currentSum += arr[r][i];
        }

        if (currentSum != firstSum) {
            
            isMagic = false;

        }
    }

    if (isMagic) {
        
        console.log(true);

    } else {

        console.log(false);
        
    }

    // for (let i = 0; i < length; i++) {

    //     resultSumsRows[i] = arr[i].reduce((acc, c) => acc + c);
    //     let currentSumCols = flattened.filter((a, index) => index % length == i).reduce((acc, c) => acc + c);
    //     resultSumsCols[i] = currentSumCols;
    // }

    // let rowsAreEqual = resultSumsRows.every(a => a == resultSumsRows[0]);
    // let colsAreEqual = resultSumsCols.every(a => a == resultSumsCols[0]);

    // if (rowsAreEqual && colsAreEqual && resultSumsCols[0] == resultSumsRows[0]) {

    //     console.log(true);

    // } else {

    //     console.log(false);

    // }
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
);

solve([[0, 0, 0],
    [0, 0, 0],
    [0, 0, 0]]);