function solve(input) {

    let obj = {};

    let line = input.shift();
    while (line !== 'Ave Cesar') {

        let gladiator = '';
        let skill = '';
        let power = 0;
        let fighter1 = '';
        let fighter2 = '';

        if (line.includes('->')) {
            [gladiator, skill, power] = line.split(' -> ');
            power = Number(power);

            if (!obj.hasOwnProperty(gladiator)) {
                obj[gladiator] = ({ [skill]: power });
            } else {

                if (!Object.keys(obj[gladiator]).includes(skill)) {

                    obj[gladiator][skill] = power;

                } else {

                    if (power > obj[gladiator][skill]) {
                        obj[gladiator][skill] = power;
                    }

                }
            }


        } else if (line.includes('vs')) {
            [fighter1, fighter2] = line.split(' vs ');

            if (Object.keys(obj).includes(fighter1) && Object.keys(obj).includes(fighter2)) {

                //console.log('yes');

                let skillsArr1 = Object.keys(obj[fighter1]);
                let skillsArr2 = Object.keys(obj[fighter2]);
                let commonSkill = '';

                for (let i = 0; i < skillsArr1.length; i++) {
                    let skill1 = skillsArr1[i];
                    for (let j = 0; j < skillsArr2.length; j++) {
                        let skill2 = skillsArr2[j];

                        if (skill1 === skill2) {
                            commonSkill = skill1;
                            //console.log(skill1);
                            break;
                        }

                    }

                }

                if (obj[fighter1][commonSkill] > obj[fighter2][commonSkill]) {
                    delete obj[fighter2];
                } else if (obj[fighter1][commonSkill] < obj[fighter2][commonSkill]) {
                    delete obj[fighter1];
                }

                //console.log(skillsArr1 + '-----' + skillsArr2);
            }
        }



        if (input.length <= 0) {
            break;
        }
        line = input.shift();
    }

    // let arr = Object.entries(obj).map(a => a[1] = Object.entries(a[1]));   //.sort((a, b) => b.length - a.length);
    // console.log(arr);

    let totalSkillsObj = {};

    for (let gladiator in obj) {
        //console.log(obj[gladiator]);

        let total = Object.values(obj[gladiator]).reduce((a, b) => a + b);

        totalSkillsObj[gladiator] = total;


        //console.log(totalSkillsObj);
    }

    //console.log(Object.values(totalSkillsObj).sort((a, b) => b - a));
    // Object.entries(totalSkillsObj)
    //     .sort((a, b) => b[1] - a[1])
    //     .forEach(a => {
    //         console.log(`${a[0]}: ${a[1]} skill`);
    //         //Object.entries(obj).forEach(a => console.log(a));
    //     })

    console.log(Object.values(obj).sort((a, b) => {
        Object.values(b).reduce((j, k) => j + k) - Object.values(a).reduce((x, y) => x + y);
    }));

    //console.log(obj);

}

// solve([
//     'Peter -> BattleCry -> 400',
//     'Alex -> PowerPunch -> 300',
//     'Stefan -> Duck -> 200',
//     'Stefan -> Tiger -> 250',
//     'Ave Cesar'
// ])

solve([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 350',
    'Gladius -> Shield -> 450',
    'Peter vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Maximilian',
    'Ave Cesar'
])