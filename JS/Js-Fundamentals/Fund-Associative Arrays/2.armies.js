function solve(input) {

    let leadersArr = [];
    let leadersMap = new Map();

    for(let i = 0; i < input.length; i++){
        let tokens = input[i].split(' ');
        if(tokens.includes('arrives')){
            tokens.splice(tokens.length - 1);
            let leaderName = tokens.join(' ');
            
            leadersMap.set(leadersName, []);
            leadersArr.push(leaderName);
        }


        console.log(leadersArr);
    }

    for(let line of input){

    }

}

solve(['Rick Burr arrives',
    'Fergus: Wexamp, 30245',
    'Rick Burr: Juard, 50000',
    'Findlay arrives',
    'Findlay: Britox, 34540',
    'Wexamp + 6000',
    'Juard + 1350',
    'Britox + 4500',
    'Porter arrives',
    'Porter: Legion, 55000',
    'Legion + 302',
    'Rick Burr defeated',
    'Porter: Retix, 3205'])