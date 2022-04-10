function calculations(a, b, operator) {
    a = Number(a);
    b = Number(b);
    let result = 0;

    if ((operator === '/' || operator === '%') && b === 0){
        console.log(`Cannot divide ${a} by zero`);
    } else {
    switch (operator){
        case '+':
        result = a + b;
        break;
        case '-':
        result = a - b;
        break;
        case '*':
        result = a * b;
        break;
        case '/':
        result = a / b;
        break;
        case '%':
        result = a % b;
        break;
        default:
            break;
    }
    let oddEven ='';
    if (result % 2 === 0){
        oddEven = 'even';
    } else {
        oddEven = 'odd';
    }
    if (operator !== '/' && operator !== '%'){
        console.log(`${a} ${operator} ${b} = ${result} - ${oddEven}`);
    } else if (operator === '/'){
        console.log(`${a} / ${b} = ${result.toFixed(2)}`);
    } else if (operator === '%'){
        console.log(`${a} % ${b} = ${result}`);
    }
    
}

}

calculations(10,
    12,
    '+')