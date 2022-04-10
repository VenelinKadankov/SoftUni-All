function convertor(arg, inputValue, outputValue){
    let num = arg;

    if (inputValue === 'mm'){
        num = arg / 1000;
    } else if (inputValue === 'cm'){
        num = arg / 100;
    }

    if (outputValue === 'mm'){
        num = num * 1000;
    } else if (outputValue === 'cm'){
        num = num * 100;
    }

    console.log(num.toFixed(3));
}

convertor('150',
    'm',
    'cm')