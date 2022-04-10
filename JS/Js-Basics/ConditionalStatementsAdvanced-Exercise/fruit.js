function fruitOr(input) {
    let fruitArr = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes'];
    let vegetableObj = ['tomato', 'cucumber', 'pepper' ,'carrot'];

    if(fruitArr.includes(input)){
        console.log('fruit');
    } else if(vegetableObj.includes(input)){
        console.log('vegetable');
    } else {
        console.log('unknown');
    }
}

fruitOr('banana')