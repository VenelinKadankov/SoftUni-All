function getInfo() {
    let busId = document.getElementById('stopId').value;
    const resultElement = document.getElementById('stopName');
    const ulElement = document.getElementById('buses');

    const validData = ['1287', '1308','1327', '2334'];

    if(validData.includes(busId)){

        getBusData();

    } else {
        resultElement.textContent = '';
        ulElement.textContent = '';
        resultElement.textContent = 'Error';
    }


    async function getBusData(){
        busId = Number(busId);
        resultElement.textContent = '';
        ulElement.textContent = '';


        const url = 'http://localhost:3030/jsonstore/bus/businfo/' + busId;
    
        try{
            let promise = await fetch(url);
            let data = await promise.json();

            let stopName = data.name;
            resultElement.textContent = stopName;

            Object.keys(data.buses).forEach(b => {
                let liElement = e('li', {}, `Bus ${b} arrives in ${data.buses[b]} minutes`);
                ulElement.appendChild(liElement);
            });
        } 
        catch(error){
            alert(error.message);
        }
    }


    function e(type, attributes, ...content) {
        const result = document.createElement(type);
    
        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }
    
        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);
    
        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });
    
        return result;
    }
}