function invalid(input){
    let num = Number(input);
    if ((num >= 100 && 200 >= num ) || num === 0){
       // console.log('valid');
    } else {
        console.log('invalid');
    }
}

invalid(75)