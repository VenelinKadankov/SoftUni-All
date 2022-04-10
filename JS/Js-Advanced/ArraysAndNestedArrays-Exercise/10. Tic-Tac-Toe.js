function solve(arr) {

    let field = [];
    let winner = '';
    let isOver = false;

    for (let row = 0; row < 3; row++) {

        field[row] = ['false', 'false', 'false'];
    }

    let firstCounter = 0;
    let secondCounter = 0;
    let placeTakenCounter = 0;

   // for (let i = 0; i < arr.length; i++) {
    while(isOver == false && arr.length > 0){

        let [a, b] = arr.shift().split(' ').map(Number);

        let mark = '';

        
        if(field[a][b] != 'false'){

            console.log('This place is already taken. Please choose another!');
            placeTakenCounter++;
            continue;

        }

        if (firstCounter <= secondCounter) {

            mark = 'X';
            firstCounter++;

        } else {

            mark = 'O';
            secondCounter++;

        }

        field[a][b] = mark;

        isOver = CheckIfGameIsOver(field);

        if (isOver == true) {

            winner = mark;
            break;

        }
        ;
        if (firstCounter + secondCounter == 9 && placeTakenCounter == 0) {
            break;
        }
    }

    if (isOver == true) {

        console.log(`Player ${winner} wins!`);

    } else {

        console.log('The game ended! Nobody wins :(');

    }

    for (let i = 0; i < field.length; i++) {
        
        console.log(field[i].join('\t'));
        
    }

    function CheckIfGameIsOver(matrix) {

        let result = false;
        let firstDiagonalStart = matrix[0][0];
        let secondDiagonalStart = matrix[0][matrix.length - 1];

        let firstDiagonalLine = false;
        let secondDiagonalLine = false;

        for (let r = 0; r < matrix.length; r++) {

            let lineCheck = matrix[r].every(x => x == matrix[r][0]);

            if (lineCheck == true && matrix[r][0] != 'false') {
                return true;
            }

            if (matrix[r][r] == firstDiagonalStart && firstDiagonalStart != 'false') {

                firstDiagonalLine = true;

            } else {

                firstDiagonalLine = false;
                break;

            }

        }

        for (let r = 0; r < matrix.length; r++) {

            if (matrix[r][matrix.length - r - 1] == secondDiagonalStart && secondDiagonalStart != 'false') {

                secondDiagonalLine = true;

            } else {

                secondDiagonalLine = false;
                break;
            }
        }

        if (result == true || secondDiagonalLine == true || firstDiagonalLine == true) {
            return true;
        }

        for (let col = 0; col < matrix[0].length; col++) {

            let symbol = matrix[0][col];
            result = false;

            for (let row = 0; row < matrix.length; row++) {

                if (matrix[row][col] == symbol && symbol != 'false') {

                    result = true;

                } else {

                    result = false;
                    break;

                }

            }

            if (result == true) {

                return result;
            }

        }

        return result;

    }

}

// solve(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// );

solve(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);