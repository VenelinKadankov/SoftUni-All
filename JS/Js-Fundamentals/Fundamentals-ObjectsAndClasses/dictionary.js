function dictionary(input) {
    let outputObj = {};
    let outputArr = [];

    for (let i = 0; i < input.length; i++) {
        let workedWord = input[i];
        let obj = JSON.parse(workedWord);
        let key = Object.keys(obj);
        let value = Object.values(obj);

        outputObj[`${key}`] = value.toString();

    }
    outputArr = Object.entries(outputObj);
    outputArr.sort((a,b) => a > b ? 1 : (a <= b ? -1 :0));
    let result = Object.fromEntries(outputArr);
   
    for (let el in result){
        console.log(`Term: ${el} => Definition: ${result[el]}`);
    }
}

dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
    '{"Bus":"bus"}'
])