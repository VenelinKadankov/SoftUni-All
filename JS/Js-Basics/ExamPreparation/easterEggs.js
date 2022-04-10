function solve(input) {

    let eggs = Number(input.shift());
    let redCounter = 0;
    let orangeCounter = 0;
    let blueCounter = 0;
    let greenCounter = 0;
    let colorMax = '';

    for (let i = 0; i < eggs; i++) {
        let color = input.shift();

        switch (color) {
            case 'red':
                redCounter++;
                break;
            case 'orange':
                orangeCounter++;
                break;
            case 'blue':
                blueCounter++;
                break;
            case 'green':
                greenCounter++;
                break;
        }
    }

    if (redCounter > orangeCounter && redCounter > blueCounter && redCounter > greenCounter) {
        colorMax = 'red';
    }
    
    if (greenCounter > redCounter && greenCounter > blueCounter && greenCounter > orangeCounter) {
        colorMax = 'green';
    }

    if (orangeCounter > redCounter && orangeCounter > blueCounter && greenCounter < orangeCounter) {
        colorMax = 'orange';
    }

    if (blueCounter > redCounter && greenCounter < blueCounter && blueCounter > orangeCounter) {
        colorMax = 'blue';
    }

    let colorsArray = [];
    colorsArray.push(redCounter, orangeCounter, blueCounter, greenCounter);
    colorsArray.sort((a, b) => b - a);
    let maxColor = colorsArray.shift();



    console.log(`Red eggs: ${redCounter}`);
    console.log(`Orange eggs: ${orangeCounter}`);
    console.log(`Blue eggs: ${blueCounter}`);
    console.log(`Green eggs: ${greenCounter}`);
    console.log(`Max eggs: ${maxColor} -> ${colorMax}`);
}

solve([7,
    'orange',
    'blue',
    'green',
    'green',
    'blue',
    'red',
    'green'
])