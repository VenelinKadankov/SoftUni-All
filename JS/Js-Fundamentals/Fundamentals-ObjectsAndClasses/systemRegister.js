function systemRegister(input) {
    let arr = [];

    // for(let el of input){
    //     let element = el.split(' | ');
    //     arr.push(element);
    // }
    // let output = arr.sort(function (a,b){
    //     if (a[1] > b[1]){
    //         return 1;
    //     } else if (a[1] < b[1]){
    //         return -1;
    //     }
    //    return 0;
    // });
    //console.log(output);



    input.forEach(a => {
        a = a.split(' | ');
        arr.push(a);
    });
    // arr = arr.sort((a,b) => a[1].localeCompare(b[1]));


    // arr.sort(function(a,b) {
    //     let count = 0;
    //     let obj1 = {
    //         value : a[1],
    //     }
    //     let obj2 = {
    //         value : b[1],
    //     }
    //     if(obj1.value === obj2.value){
    //         count++
    //     }
    //     return count;
    // });

    let newArr = [];

    for (let i = 0; i < arr.length; i++) {
        let newEl = arr[i][1];
        newArr.push(newEl);
    };
    console.log(newArr);

    let filtered = [];
    let objArr = newArr.reduce(function (obj,value){
        obj[value] = (obj[value] || 0) + 1;
        return obj;
    },{})
    filtered = Object.keys(objArr).sort(function(a,b) {
        return  objArr[b] - objArr[a];
    });

    //filtered = newArr.sort((a,b) => a.length - b.length).sort((a,b) => a.localeCompare(b));

    // for (let i = 0; i < newArr.length; i++){
    //     let checked = newArr[i];

    //     for (let j = i + 1 ; j < newArr.length; j++){
    //         if (checked === newArr[j]){
    //             filtered.push(newArr[j]);
    //         }
    //     }

    // }
    
    console.log(filtered);
}

systemRegister(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
])