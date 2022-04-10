function solve(input) {

    let sumPrime = 0;
    let sumNon = 0;
    // let isPrime = true;

    let command = input.shift();
    while (command !== 'stop') {
        let num = Number(command);
        if(num < 0){
            console.log('Number is negative.');
        }
        let isPrime = true;

        let square = Math.sqrt(num);
        for (let i = 2; i < square; i++) {
            if (num % i === 0) {
                isPrime = false;
            }

        }

        if (isPrime && num >= 0) {
            sumPrime += num;
        } else if(!isPrime && num >= 0) {
            sumNon += num;
        }

        command = input.shift();
    }

    console.log(`Sum of all prime numbers is: ${sumPrime}`);
    console.log(`Sum of all non prime numbers is: ${sumNon}`);
}

solve([30,
    83,
    33,
    -1,
    20,
    'stop'])