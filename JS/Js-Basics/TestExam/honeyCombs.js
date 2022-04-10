function honeyCombs(beeCount, flowerCount){

    beeCount = Number(beeCount);
    flowerCount = Number(flowerCount);
    let honeyCombsFilled = 0; 
    
    let totalHoney = beeCount * flowerCount * 0.21;
    honeyCombsFilled = Math.floor(totalHoney / 100);
    let honeyLeft = totalHoney - honeyCombsFilled * 100;

    console.log(`${honeyCombsFilled} honeycombs filled.`);
    console.log(`${honeyLeft.toFixed(2)} grams of honey left.`);
}
honeyCombs(11,
    120
    )