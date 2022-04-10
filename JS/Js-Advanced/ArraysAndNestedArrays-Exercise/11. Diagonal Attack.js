function solve(arr) {

    let matrix = [];

    for (let i = 0; i < arr.length; i++) {

        let line = arr[i].split(' ').map(Number);
        matrix[i] = line;

    }

    let firstSum = 0;
    let secondSum = 0;
    let firstCoordinates = {};
    let secondCoordinates = {};

    for (let i = 0; i < matrix.length; i++) {

        firstSum += matrix[i][i];
        firstCoordinates[i] = i;

        secondSum += matrix[i][matrix.length - i - 1];
        secondCoordinates[i] = matrix.length - i - 1;
    }

    if (firstSum == secondSum) {
        
        for (let r = 0; r < matrix.length; r++) {

            for (let c = 0; c < matrix.length; c++) {
                
                if (firstCoordinates[r] != c && secondCoordinates[r] != c) {
                    matrix[r][c] = firstSum;
                }
                
            }
    
        }

    }

    for(let line of matrix){
        console.log(line.join(' '));
    }
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);