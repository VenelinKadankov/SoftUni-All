function solve(input) {

    let searchedWords = input.shift().split(' ');

    let wordsMap = new Map();

    for (let word of searchedWords) {
        wordsMap.set(word, []);
    }

    for (let word of input) {
        if (wordsMap.has(word)) {
            wordsMap.get(word).push(1);
        }
    }

    for (let word of wordsMap) {
        wordsMap.set(word[0], word[1].length);
    }

    let wordsArr = Array.from(wordsMap);
    wordsArr.sort((a, b) => b[1] - a[1]);

    for (let [word, count] of wordsArr) {
        console.log(`${word} - ${count}`);
    }
}

solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to'
    , 'count', 'the', 'occurances', 'of', 'the'
    , 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task','sentence'
])