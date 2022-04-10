function calculator() {
    let a = document.getElementById('num1');
    let b = document.getElementById('num2');
    let resultArea = document.getElementById('result');

    function init(selector1, selector2, resultSelector){
        a = document.querySelector(selector1);
        b = document.querySelector(selector2);
        resultArea = document.querySelector(resultSelector);
    }

    function add(){
        let result = Number(a.value) + Number(b.value);
        resultArea.value = result;
    }

    function subtract(){
        let result = Number(a.value) - Number(b.value);
        resultArea.value = result;
    }
    
    return {
        init,
        add,
        subtract
    }
}

const calculate = calculator(); 
calculate.init('#num1', '#num2', '#result');

const add = calculate.add;
const subtract = calculate.subtract;



