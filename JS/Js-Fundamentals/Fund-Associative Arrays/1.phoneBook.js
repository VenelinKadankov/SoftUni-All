function solve(input){

    let phonebook = new Map();

    for(let line of input){
        let [name, number] = line.split(' ');

        if(!phonebook.has(name)){
            phonebook.set(name, number);
        } else {
            phonebook.set(name, number);
        }
    }

    for(const [name, number] of phonebook){
        console.log(`${name} -> ${number}`);
    }

}

solve(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344'])