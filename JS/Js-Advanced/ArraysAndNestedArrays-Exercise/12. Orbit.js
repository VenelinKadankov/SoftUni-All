function solve(arr){

    let matrix = [];

    let[width, height, x, y] = arr;

    for (let r = 0; r < height; r++) {

        matrix[r] = [];
        
        for (let c = 0; c < width; c++) {
            
            if (x == r && y == c) {

                matrix[r][c] = 1;

            } else {

                matrix[r][c] = 0;

            }
            
        }
        
    }

    for (let r = 0; r < matrix.length; r++) {
        
        for (let c = 0; c < matrix[r].length; c++) {

            if (r != x || c != y) {
                
                let distance = Math.max(Math.abs(r - x), Math.abs(y - c));

                matrix[r][c] = distance + 1;
            }
            
        }
        
    }

    for (let line of matrix) {
        
        console.log(line.join(' '));        
    }

}

solve([5, 5, 2, 2]);

solve([4, 4, 0, 0]);

solve([3, 3, 2, 2]);