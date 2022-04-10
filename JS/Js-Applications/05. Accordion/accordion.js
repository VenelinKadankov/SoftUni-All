function solution() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const mainSection = document.getElementById('main');

    populateApp(url);


    async function populateApp(url) {
        let promise = await fetch(url);
        let data = await promise.json();

        console.log(data);

        Object.values(data).forEach(el => {
            let resultElement = e('div', { className: 'accordion' },
                e('div', { className: 'head' },
                    e('span', {}, `${el.title}`),
                    e('button', { id: `${el._id}`, className: 'button' }, 'More')),
                e('div', { className: 'extra' },
                    e('p', { id: `paragraph${el._id}` })));

            mainSection.appendChild(resultElement);

            let paragraph = document.getElementById(`paragraph${el._id}`);

            let btn = document.getElementById(`${el._id}`);

            btn.addEventListener('click', async function (e) {
                if (paragraph.textContent === '') {
                    let currentUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${el._id}`;

                    let currentPromise = await fetch(currentUrl);
                    let currentData = await currentPromise.json();

                    paragraph.textContent = currentData.content;
                }

                if (btn.textContent === 'More') {
                    paragraph.parentNode.style.display = 'block';
                    btn.textContent = 'Less';
                } else {
                    paragraph.parentNode.style.display = 'none';
                    btn.textContent = 'More';
                }
            })
        });
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

solution()