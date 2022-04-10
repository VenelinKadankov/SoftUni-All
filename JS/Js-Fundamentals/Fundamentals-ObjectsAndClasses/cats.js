function cats(allCats) {

    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.meow = () => console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    allCats.forEach(function (element) {
        let [name, age] = element.split(' ');
        let cat = new Cat(name, age);
        cat.meow();
    });
}


// function cats(arr){
//     class Cat{
//         constructor(name, age){
//             this.name = name;
//             this.age = age;
//             this.meow = ()
//         }
//     }

// }
cats(['Mellow 2', 'Tom 5'])