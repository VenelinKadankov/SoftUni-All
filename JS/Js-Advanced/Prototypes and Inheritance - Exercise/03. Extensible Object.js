function solve() {
    let myObj = {/*
            __proto__: {},
            extend: function () { }
         */};

    myObj.extend = function (template) {
        let kvps = Object.entries(template);
        
        kvps.forEach(([key, value]) => {
            if (typeof value === 'function') {
                let prototype = Object.getPrototypeOf(myObj);
                prototype[key] = value;
            } else {
                myObj[key] = value;
            }
        });

    };
    return myObj;
}

solve();
