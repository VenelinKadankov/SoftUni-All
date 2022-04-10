function animalClass(animal){

    let clas = '';

    if(animal === 'dog'){
        clas = 'mammal';
    } else if (animal === 'crocodile' || animal === 'tortoise' || animal === 'snake'){
        clas = 'reptile';
    } else {
        clas = 'unknown';
    }
    console.log(clas);
}

animalClass('dog')