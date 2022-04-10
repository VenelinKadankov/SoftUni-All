function titles(age, gender) {
    age = Number(age);
    let title = '';

    if (age < 16) {
        switch (gender) {
            case 'f':
                title = 'Miss';
                break;
            case 'm':
                title = 'Master';
                break;
        }
    } else {
        switch (gender) {
            case 'f':
                title = 'Ms.'
                break;
            case 'm':
                title = 'Mr.'
                break;
        }
    }
    console.log(title);
}

titles(12, 'f')