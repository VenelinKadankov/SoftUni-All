function solve(money) {

    let change = Number(money);
    let coinCounter = 0;

    while (change > 0) {

        if (change >= 2) {
            change -= 2;
            coinCounter++;
        } else if (change >= 1) {
            change -= 1;
            coinCounter++;
        } else if (change >= 0.50) {
            change -= 0.50;
            coinCounter++;
        } else if (change >= 0.20) {
            change -= 0.20;
            coinCounter++;
        } else if (change >= 0.10) {
            change -= 0.10;
            coinCounter++;
        } else if (change >= 0.05) {
            change -= 0.05;
            coinCounter++;
        } else if (change >= 0.02) {
            change -= 0.02;
            coinCounter++;
        } else {
            change -= 0.01;
            coinCounter++;
        }
        change = change.toFixed(2);
    }
    console.log(coinCounter);
}
solve(0.56)