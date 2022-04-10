function convertToJson(firstName, secondName, hairColor){
    let info = {
        name : firstName, 
        lastName : secondName, 
        hairColor : hairColor,
    }

    console.log(JSON.stringify(info));
}

convertToJson('George',
    'Jones',
    'Brown')