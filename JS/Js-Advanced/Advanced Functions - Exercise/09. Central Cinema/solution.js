function solve() {
    const inputInfo = document.getElementById('container').children;
    const moviesSection = document.getElementById('movies').querySelector('ul');
    const sectionArchive = document.getElementById('archive').querySelector('ul');
    const clearArchive = document.querySelector('#archive ul');
    const archiveClearButton = document.querySelector('#archive>button');

    inputInfo[3].addEventListener('click', createOnScreen);
    moviesSection.addEventListener('click', archiveMovieFromScreen);
    sectionArchive.addEventListener('click', deleteFromArchive);
    archiveClearButton.addEventListener('click', archiveArchive);

    function createCustomElement(type, text) {
        const element = document.createElement(type);
        const innerValue = document.createTextNode(text);
        element.appendChild(innerValue);
        return element;
    }

    function createOnScreen(ev) {
        ev.preventDefault();

        const inputFields = Array.from(inputInfo).slice(0, -1).map(x => x.value);

        if (inputFields.every(x => x.length > 0) && !Number.isNaN(Number(inputFields[2]))) {

            const spanElement = createCustomElement('span', inputFields[0]);
            const strongElement = createCustomElement('strong', inputFields[1]);

            const divElement = document.createElement('div');
            const strongDivElement = createCustomElement('strong', Number(inputFields[2]).toFixed(2));
            const inputDivElement = document.createElement('input');
            inputDivElement.placeholder = 'Tickets Sold';
            const buttonDivElement = document.createElement('button');
            buttonDivElement.textContent = 'Archive';
            divElement.appendChild(strongDivElement);
            divElement.appendChild(inputDivElement);
            divElement.appendChild(buttonDivElement);

            const listElement = document.createElement('li');
            listElement.appendChild(spanElement);
            listElement.appendChild(strongElement);
            listElement.appendChild(divElement);
            moviesSection.appendChild(listElement);
        }

        inputInfo[0].value = '';
        inputInfo[1].value = '';
        inputInfo[2].value = '';
    }

    function archiveMovieFromScreen(ev) {
        if (ev.target.tagName === 'BUTTON') {
            const movies = ev.target.parentNode.parentNode;
            const movie = movies.children[0];
            const name = movies.children[0].textContent;
            const count = ev.target.parentNode.children[1].value;
            const ticketPrice = ev.target.parentNode.children[0].textContent;

            if (count.length > 0 && !Number.isNaN(Number(count))) {
                const singlePrice = Number(ticketPrice);
                const price = singlePrice * Number(count);

                const liElement = document.createElement('li');
                const nameElement = createCustomElement('span', name);
                const strongElement = createCustomElement('strong', `Total amount: ${price.toFixed(2)}`);
                const buttonElement = createCustomElement('button', 'Delete');
                liElement.appendChild(nameElement);
                liElement.appendChild(strongElement);
                liElement.appendChild(buttonElement);
                sectionArchive.appendChild(liElement);

                movie.parentNode.remove();
            }

        }
    }

    function deleteFromArchive(ev) {
        const currentTarget = ev.target;
        if (currentTarget.tagName == 'BUTTON') {
            currentTarget.parentNode.remove();
        }
    }

    function archiveArchive(ev){
        clearArchive.innerHTML = '';
    }
}