function solve(myObj) {

    if (myObj.dizziness === true) {
        myObj.levelOfHydrated += myObj.experience * myObj.weight * 0.1;
        myObj.dizziness = false;
    }

    return myObj;
}

console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));

console.log(solve({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));

solve({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
}
);