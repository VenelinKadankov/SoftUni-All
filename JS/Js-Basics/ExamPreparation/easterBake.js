function solve(input){

    let cakes = Number(input.shift());
    let sugarCounter = 0;
    let flourCounter = 0;
    let maxFlour = Number.MIN_SAFE_INTEGER;
    let maxSugar = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < cakes; i++){
        let sugar = Number(input.shift());
        let flour = Number(input.shift());

        if(sugar > maxSugar){
            maxSugar = sugar;
        }

        if(flour > maxFlour){
            maxFlour = flour;
        }

        sugarCounter += sugar;
        flourCounter += flour;

    }

    let sugarPacks = Math.ceil(sugarCounter / 950);
    let flourPacks = Math.ceil(flourCounter / 750);
    console.log(`Sugar: ${sugarPacks}`);
    console.log(`Flour: ${flourPacks}`);
    console.log(`Max used flour is ${maxFlour} grams, max used sugar is ${maxSugar} grams.`);
}

solve([3,
    400,
    350,
    250,
    300,
    450,
    380
    ])