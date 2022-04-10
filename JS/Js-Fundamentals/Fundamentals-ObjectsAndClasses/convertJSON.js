function convert(string){
    let info = JSON.parse(string);
    
    for (let key in info){
        console.log(`${key}: ${info[key]}`);
    }
}

convert('{"name":"George","age":40,"town":"Sofia"}');