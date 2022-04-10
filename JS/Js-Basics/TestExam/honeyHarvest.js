function honeyHarvest(flowerType, flowerCount, season) {

    flowerCount = Number(flowerCount);

    let totalHoney = 0;
    let honeyPerFlower = 0;

    if (season === 'Spring') {
        switch (flowerType) {
            case 'Sunflower':
                honeyPerFlower = 10;
                break;
            case 'Daisy':
                honeyPerFlower = 12 * 1.1;
                break;
            case 'Lavender':
                honeyPerFlower = 12;
                break;
            case 'Mint':
                honeyPerFlower = 10 * 1.1;
                break;
        }
        totalHoney = honeyPerFlower * flowerCount;
    } else if (season === 'Summer') {
        switch (flowerType) {
            case 'Sunflower':
                honeyPerFlower = 8;
                break;
            case 'Daisy':
                honeyPerFlower = 8;
                break;
            case 'Lavender':
                honeyPerFlower = 8;
                break;
            case 'Mint':
                honeyPerFlower = 12;
                break;
        }
        totalHoney = honeyPerFlower * flowerCount * 1.1;
    } else if (season === 'Autumn') {
        switch (flowerType) {
            case 'Sunflower':
                honeyPerFlower = 12;
                break;
            case 'Daisy':
                honeyPerFlower = 6;
                break;
            case 'Lavender':
                honeyPerFlower = 6;
                break;
            case 'Mint':
                honeyPerFlower = 6;
                break;
        }
        totalHoney = honeyPerFlower * flowerCount * 0.95;
    }
    console.log(`Total honey harvested: ${totalHoney.toFixed(2)}`);
}

honeyHarvest('Sunflower',
    11,
    'Autumn'
)