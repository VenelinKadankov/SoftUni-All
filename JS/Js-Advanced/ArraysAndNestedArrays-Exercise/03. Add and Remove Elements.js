function solve(arr) {

    let num = 0;
    let result = [];

    for (let command of arr) {

        num += 1;

        if (command == 'add') {

            result.push(num);

        } else if (command == 'remove') {

            result.pop();

        }
    }

    if(result.length == 0){

        console.log('Empty');
        
    } else {
        
        for(let number of result){

            console.log(number);

        }
    }
}

solve(['add',
    'add',
    'add',
    'add']
);

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);