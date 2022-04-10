function solve(rows, cols) {

    let totalElements = [];

    for (let i = 0; i < rows * cols; i++) {
        totalElements[i] = i + 1;
    }

    let matrix = [];
    matrix[0] = [];

    for (let r = 0; r < rows; r++) {
        
        matrix[r] = [];
    }

    for (let i = 0; i < cols; i++) {

        matrix[0][i] = totalElements.shift();
    }

    let startDown = 1;
    let startLeft = cols - 1 ;
    let startUp = rows - 1 ;
    let startRight = 0;

    while (totalElements.length > 0) {

        //going down
        for (let i = startDown; i < rows ; i++) {

            matrix[i][cols - 1] = totalElements.shift();
        }

        cols--;
        startLeft--;

        //going left
        for (let i = startLeft; i >= startRight ; i--) {

            matrix[rows - 1][i] = totalElements.shift();
        }

        rows--;
        startUp--;


        // going up
        for (let i = startUp; i >= startDown; i--) {

            matrix[i][startRight] = totalElements.shift();

        }

        startRight++;

        //going right
        for (let i = startRight; i <= startLeft; i++) {

            matrix[startDown][i] = totalElements.shift();

        }

        startDown++;
    }

    for (let line of matrix) {
        console.log(line.join(' '));
    }
}

solve(5, 5);

solve(3, 3);