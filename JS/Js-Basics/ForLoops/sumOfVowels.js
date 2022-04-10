function solve(word) {

    let count = word.length;
    let allPoints = 0;
    let points = 0;

    for (let i = 0; i < count; i++) {
        let current = word[i];
        switch (current) {
            case 'a':
                points = 1;
                break;
            case 'e':
                points = 2;
                break;
            case 'i':
                points = 3;
                break;
            case 'o':
                points = 4;
                break;
            case 'u':
                points = 5;
                break;
            default:
                points = 0;
                break;
        }
        allPoints += points;
    }
    console.log(allPoints);
}

solve('hello')