function attachEvents() {
    const submitBtn = document.getElementById('submit');
    const requestField = document.getElementById('location');
    const forecastSection = document.getElementById('forecast');
    const currentSection = document.getElementById('current');
    const upcomingSection = document.getElementById('upcoming');

    const divResults = document.getElementsByClassName('label');
    const divCurrent = divResults[0];
    const divTree = divResults[1];

    const symbols = {
        Sunny: '☀',
        'Partly sunny': '⛅',
        Overcast: '☁',
        Rain: '☂',
        Degrees: '°',
    }

    const urlAllData = 'http://localhost:3030/jsonstore/forecaster/locations';

    submitBtn.addEventListener('click', (e) => {
        makeSecondaryRequests();
    });

    async function makeSecondaryRequests() {
        let promise = await fetch(urlAllData);
        let data = await promise.json();

        let requestedName = requestField.value;
        let isIncluded = false;

        let locationName = '';
        let locationCode = '';

        for (let i = 0; i < data.length; i++) {
            const element = data[i];

            if (element.name.toLowerCase() == requestedName.toLowerCase()
                || element.code.toLowerCase() == requestedName.toLowerCase()) {
                isIncluded = true;
                locationCode = element.code;
            }
        }

        if (!isIncluded) {
            forecastSection.style.display = 'block';
            currentSection.textContent = 'Error';
            upcomingSection.textContent = 'Error';
            return;
        }

        let urlToday = `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`;

        let promiseToday = await fetch(urlToday);
        let dataToday = await promiseToday.json();

        locationName = dataToday.name;

        let divForecasts = makeOneDayForecast(dataToday.forecast, locationName, 'condition');

        forecastSection.style.display = 'block';

        let onlyChildCurrent = currentSection.children[0];
        currentSection.innerHTML = '';

        currentSection.appendChild(onlyChildCurrent);
        currentSection.appendChild(divForecasts);

        let urlUpcoming = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`;

        let promiseUpcoming = await fetch(urlUpcoming);
        let dataUpcoming = await promiseUpcoming.json();

        let divElement = e('div', {className: 'forecast-info'});

        for (let i = 0; i < dataUpcoming.forecast.length; i++) {
            const element = dataUpcoming.forecast[i];
            
            let spanElement =  makeOneDayForecast(element, locationName, 'upcoming');
            divElement.appendChild(spanElement);
        }

        let onlyChild = upcomingSection.children[0];
        upcomingSection.innerHTML = '';

        upcomingSection.appendChild(onlyChild);
        upcomingSection.appendChild(divElement);
    }

    function makeOneDayForecast(forecastToday, locationName, classAtr){
        let conditionsSymbol = symbols[forecastToday.condition];

        return e('div', { className: 'forecasts' },
            e('span', { className: 'condition symbol' }, conditionsSymbol),
            e('span', { className: classAtr },
                e('span', { className: 'forecast-data' }, `${locationName}`),
                e('span', { className: 'forecast-data' }, `${forecastToday.low}${symbols.Degrees}/${forecastToday.high}${symbols.Degrees}`),
                e('span', { className: 'forecast-data' }, forecastToday.condition)));
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

attachEvents();