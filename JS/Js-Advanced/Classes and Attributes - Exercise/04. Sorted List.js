class List {
    constructor() {
        this.numbers = [];
        this.size = 0;
    }

    add(elemenent) {
        this.numbers.push(elemenent);
        this.size++;
        return this.numbers.sort((x, y) => x - y);
    }

    remove(index) {
        if(index < 0 || index >= this.size){
            throw new RangeError();
        }

        this.numbers.splice(index, 1);
        this.size--;
        return this.numbers.sort((x, y) => x - y);
    }

    get(index) {
        if(index < 0 || index >= this.size){
            throw new RangeError();
        }
        
        return this.numbers[index];
    }

    // get size(){
    //     return this.numbers.length;
    // }

}


let list = new List();
list.add(5);
list.add(6);
list.add(7);
list.add(8);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);
