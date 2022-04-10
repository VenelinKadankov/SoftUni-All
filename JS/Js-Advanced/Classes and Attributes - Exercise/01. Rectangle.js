class Rectangle {
    constructor(width, height, color){
        this.width = width;
        this.height = height;
        this.color = color;
    }

    // get width(){
    //     return this._width;
    // }

    // set width(value){
    //     if(typeof value != 'number'){
    //         throw new TypeError('width must be number');
    //     }
    //     this._width = value;
    // }

    calcArea() {
        return this.height * this.width;
    }
}