function comission(city, sales) {
    sales = Number(sales);
    let isValid = true;
    let comision = 0;

    if (0 <= sales && sales <= 500) {
        switch (city) {
            case 'Sofia':
                comision = 0.05;
                break;
            case 'Varna':
                comision = 0.045;
                break;
            case 'Plovdiv':
                comision = 0.055;
                break;
            default:
                isValid = false;
                break;
        }
    } else if (sales <= 1000) {
        switch (city) {
            case 'Sofia':
                comision = 0.07;
                break;
            case 'Varna':
                comision = 0.075;
                break;
            case 'Plovdiv':
                comision = 0.08;
                break;
            default:
                isValid = false;
                break;
        }
    } else if (sales <= 10000) {
        switch (city) {
            case 'Sofia':
                comision = 0.08;
                break;
            case 'Varna':
                comision = 0.1;
                break;
            case 'Plovdiv':
                comision = 0.12;
                break;
            default:
                isValid = false;
                break;
        }
    } else if (sales > 10000) {
        switch (city) {
            case 'Sofia':
                comision = 0.12;
                break;
            case 'Varna':
                comision = 0.13;
                break;
            case 'Plovdiv':
                comision = 0.145;
                break;
            default:
                isValid = false;
                break;
        }
    } else {
        isValid = false;
    }

    let bonus = comision * sales;
    if (isValid && bonus >= 0){
        console.log(bonus.toFixed(2));
    } else {
        console.log('error')
    }
}

comission('Sofia', 1500)