function checkPassword(arg){
    let passwordInput = arg;
    let originalPassword = 's3cr3t!P@ssw0rd';

    if (passwordInput === originalPassword){
        console.log('Welcome');
    } else {
        console.log('Wrong password!');
    }
}

checkPassword('venjo')