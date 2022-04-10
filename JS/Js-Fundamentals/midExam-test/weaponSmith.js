function weaponSmith(input){

    let desiredWeapon = input.shift();
    let weaponArray = desiredWeapon.split('|');

    let action = input.shift();

    while(action !== 'Done'){
        let actionArray = action.split(' ');

        if(actionArray[1] === 'Left'){
            let index = Number(actionArray[2]);

            if (index < weaponArray.length && index > 0){
                let particle = weaponArray.slice(index,index + 1).toString();
                weaponArray.splice(index, 1);
                weaponArray.splice(index - 1, 0, particle);
            }

        } else if (actionArray[1] === 'Right'){
            let index = Number(actionArray[2]);

            if (index < weaponArray.length){
                let particle = weaponArray.slice(index,index + 1).toString();
                weaponArray.splice(index, 1);
                weaponArray.splice(index + 1, 0, particle);
            }

        } else if (actionArray[1] === 'Odd'){
            let oddArray = [];

            for (let i = 0; i < weaponArray.length; i++){
                if (i % 2 !== 0){
                    oddArray.push(weaponArray[i]);
                }
            }

            console.log(oddArray.join(' '));

        } else if (actionArray[1] === 'Even'){
            let evenArray = [];
            
            for (let i = 0; i < weaponArray.length; i++){
                if (i % 2 === 0){
                    evenArray.push(weaponArray[i]);
                }
            }

            console.log(evenArray.join(' '));
        } 


        action = input.shift();
    }

    console.log(`You crafted ${weaponArray.join('')}!`);
}

weaponSmith(['ha|Do|mm|om|er',
    'Move Right 0',
    'Move Left 3',
    'Check Odd',
    'Move Left 2',
    'Move Left 10',
    'Move Left 0',
    'Done'
    ])