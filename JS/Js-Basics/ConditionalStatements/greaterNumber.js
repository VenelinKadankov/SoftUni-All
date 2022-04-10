function greaterNumber(num1, num2) {

    let arg1 = num1;
    let arg2 = num2;
    let bigger = 0;

    if (arg1 > arg2) {
        bigger = arg1;
    } else {
        bigger = arg2;
    }

    console.log(bigger);
}

greaterNumber(5,
    3)