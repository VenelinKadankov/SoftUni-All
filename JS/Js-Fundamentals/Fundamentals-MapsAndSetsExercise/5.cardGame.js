function solve(input){

    let playersMap = new Map();

    function onlyUnique(value, index, self) { 
        return self.indexOf(value) === index;
    }

    for(let el of input){
        let [name, cards] = el.split(': ');
        cards = cards.split(', ');
        cards = cards.filter(onlyUnique);

        if(!playersMap.has(name)){
            playersMap.set(name, []);
            playersMap.get(name).push(...cards);
        } else {
            for(let card of cards){
                let collection = playersMap.get(name);
                if (!collection.includes(card)){
                    playersMap.get(name).push(card);
                }
            }
        }
    }

    let playersArr = Array.from(playersMap);
    //console.log(playersArr);
    let outputMap = new Map();

    for(let el of playersArr){
        let cards = el[1];
        let playersPoints = 0;
        //console.log(cards);
        for(let i = 0; i < cards.length; i++){
            let counterPointsCurrent = 0;
            let card = cards[i].split('');
            let type = card.pop();
            let power = card.join('');

            if (power === 'J'){
                power = 11;
            } else if (power === 'Q'){
                power = 12;
            } else if (power === 'K'){
                power = 13;
            } else if (power === 'A'){
                power = 14;
            } else {
                power = Number(power);
            }
            //console.log(type + '--' + power);

            if(type === 'C'){
                counterPointsCurrent = Number(power);
            } else if (type === 'H'){
                counterPointsCurrent = Number(power) * 3;
            } else if (type === 'S'){
                counterPointsCurrent = Number(power) * 4;
            } else if (type === 'D') {
                counterPointsCurrent = Number(power) * 2;
            }   

            playersPoints += counterPointsCurrent;
        }
        console.log(el[0] + ': ' + playersPoints);

    }
}

solve([
    'Peter: 2C, 4H, 9H, AS, QS',
    'Tomas: 3H, 10S, JC, KD, 5S, 10S',
    'Andrea: QH, QC, QS, QD',
    'Tomas: 6H, 7S, KC, KD, 5S, 10C',
    'Andrea: QH, QC, JS, JD, JC',
    'Peter: JD, JD, JD, JD, JD, JD'
    ])