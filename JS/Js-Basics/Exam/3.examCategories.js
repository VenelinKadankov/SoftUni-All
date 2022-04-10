function examCategories(complexity, twist, countPages) {

    complexity = Number(complexity);
    twist = Number(twist);
    countPages = Number(countPages);

    let result = '';

    if (complexity >= 80 && twist >= 80 && countPages >= 8) {
        result = 'Legacy';
    } else if (complexity >= 80 && twist <= 10) {
        result = 'Master';
    } else if (twist >= 50 && countPages >= 2) {
        result = 'Hard';
    } else if (complexity <= 10) {
        result = 'Elementary';
    } else if (complexity <= 30 && countPages <= 1) {
        result = 'Easy';
    } else {
        result = 'Regular';
    }
    console.log(result);
}

examCategories(90,
    60,
    2
)

examCategories(11, 31, 2)