function cinema(input) {

    let output = [];
    let movie = {};
    let movieArr = [];

    for (let i = 0; i < input.length; i++) {
        let current = input[i];
        let movie = {};

        for (let k = 0; k < movieArr.length; k++) {
            let obj = movieArr[k];
            let values = Object.values(obj);
            console.log(obj);

            if (!values.includes(movie)) {
                movieArr.push(movie);
            }

        }


        if (current.includes('addMovie')) {
            current = current.split('addMovie ');
            let name = current[1];
            movie.name = name;
            //movieArr.push(movie);

        } else if (current.includes('directedBy')) {
            current = current.split(' directedBy ');
            let director = current[1];
            let movie = current[0];

            for (let j = 0; j < movieArr.length; j++) {
                let obj = movieArr[j];

                //let values = Object.values(obj);

                if (values.includes(movie)) {
                    obj.director = director;
                }
            }

        } else if (current.includes('onDate')) {
            current = current.split(' onDate ');
            let date = current[1];
            let movie = current[0];

            for (let j = 0; j < movieArr.length; j++) {
                let obj = movieArr[j];

                //let values = Object.values(obj);

                if (values.includes(movie)) {
                    obj.date = date;
                }
            }

        }

    }
    for (let el of movieArr) {
        console.log(JSON.stringify(el));
    }
}

cinema([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
])