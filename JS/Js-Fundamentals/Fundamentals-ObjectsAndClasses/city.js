function city(name, area, population, country, postCode){
    let cityInfo = {
        name : name,
        area : Number(area),
        population : Number(population),
        country : country,
        postCode : Number(postCode),
    }

    for(let key in cityInfo){
        console.log(`${key} -> ${cityInfo[key]}`);
    }
}

city("Sofia"," 492", "1238438", "Bulgaria", "1000")