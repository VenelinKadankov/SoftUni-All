async function lockedProfile() {
    const mainSection = document.getElementById('main');

    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    let promise = await fetch(url);
    let dataUsers = await promise.json();

    document.getElementById('main').innerHTML = '';

    populateApp(dataUsers);

    function populateApp(dataUsers) {
        Object.values(dataUsers).forEach((u, i = 0) => {
            i++;

            console.log(u);

            let user = e('div', { className: 'profile' },
                e('img', { src: './iconProfile2.png', className: 'userIcon' }),
                e('label', {}, 'Lock'),
                e('input', { type: 'radio', name: `user${i}Locked`, value: 'lock', checked: true }),
                e('label', {}, 'Unlock'),
                e('input', {id: `user${i}Checkbox`,  type: 'radio', name: `user${i}Locked`, value: 'unlock' }),
                e('br'),
                e('hr'),
                e('label', {}, 'Username'),
                e('input', { type: 'text', name: `user${i}Username`, value: `${u.username}`, disabled: true, readonly: true }),
                e('div', { id: `user${i}HiddenFields` },
                    e('hr'),
                    e('label', {}, 'Email:'),
                    e('input', { type: 'email', name: `user${i}Email`, value: `${u.email}`, display: 'none', disabled: false, readonly: true }),
                    e('label', {}, 'Age:'),
                    e('input', { type: 'email', name: `user${i}Age`, value: `${u.age}`, display: 'none', disabled: false, readonly: true })),
                e('button', { id: `${u._id}` }, 'Show more'));

            mainSection.appendChild(user);

            let btn = document.getElementById(`${u._id}`);

            btn.addEventListener('click', (e) => {
                let checkBox = document.getElementById(`user${i}Checkbox`);

                if (checkBox.checked && checkBox.value === 'unlock' && btn.textContent !== 'Hide it') {
                    btn.textContent = 'Hide it';

                    document.getElementById(`user${i}HiddenFields`).style.display = 'block';

                    return;
                }

                if (checkBox.checked && checkBox.value === 'unlock' && btn.textContent === 'Hide it') {
                    btn.textContent = 'Show more';

                    document.getElementById(`user${i}HiddenFields`).style.display = 'none';

                    return;
                }
            });

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