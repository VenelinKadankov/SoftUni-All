function toyStore(priceTrip,countPuzzles,countDolls,countBears,countMinions,countTrucks){
    let totalToys = Number(countBears) + Number(countDolls) + Number(countMinions) + Number(countPuzzles) + Number(countTrucks);
    let totalMoney = Number(countPuzzles) * 2.60 + Number(countDolls) * 3 +
     Number(countBears) * 4.10 + Number(countMinions) * 8.2 + Number(countTrucks) * 2;

    if (totalToys >= 50){
        totalMoney = totalMoney * 0.75;
    } 

    totalMoney = totalMoney * 0.9;
    let difference = Math.abs(totalMoney - priceTrip)

    if (totalMoney >= priceTrip){
        console.log(`Yes! ${difference.toFixed(2)} lv left.`);
    } else {
        console.log(`Not enough money! ${difference.toFixed(2)} lv needed.`);
    }
}

toyStore(320,
    8,
    2,
    5,
    5,
    1)