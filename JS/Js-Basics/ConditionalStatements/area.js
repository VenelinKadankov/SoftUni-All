function areaOfFigure(type, arg1, arg2) {
    let side1 = arg1;
    let side2 = arg2;

    switch (type) {
        case 'square':
            area = side1 * side1;
            break;
        case 'rectangle':
            area = side1 * side2;
            break;
        case 'circle':
            area = Math.PI * Math.pow(side1, 2);
            break;
        case 'triangle':
            area = side1 * side2 / 2;
            break;
        default:
            break;
    }

    console.log(area.toFixed(3));
}

areaOfFigure('circle', '4')