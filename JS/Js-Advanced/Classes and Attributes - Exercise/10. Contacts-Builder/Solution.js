function solve() {
   // document.querySelector('article').style.display = 'none'; /////// 'none'

    class Contact {
        constructor(firstName, lastName, phone, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.online = false;
        }

        get online() {
            return this._online;
        }

        set online(value) {
            this._online = value;

            const elements = document.getElementsByClassName('title');

            for (let i = 0; i < elements.length; i++) {
                if (elements[i].textContent == this.firstName + ' ' + this.lastName + String.fromCharCode(8505)) {
                    if (this.online) {
                        elements[i].classList.add('online');
                    } else {
                        elements[i].classList.remove('online');
                    }
                }

            }
        }

        render(id) {
            const container = document.createElement('article');
            const nameDiv = document.createElement('div');

            const nameButton = document.createElement('button');
            nameButton.textContent = String.fromCharCode(8505);
            nameDiv.setAttribute('class', 'title');
            nameDiv.textContent = `${this.firstName} ${this.lastName}`;
            nameDiv.appendChild(nameButton);

            const dataDiv = document.createElement('div');
            dataDiv.setAttribute('class', 'info');
            dataDiv.setAttribute('style', 'display: none');

            const span1Div = document.createElement('span');
            const span2Div = document.createElement('span');
            span1Div.textContent = '☎' + ` ${this.phone}`;
            span2Div.textContent = String.fromCharCode(9993) + ` ${this.email}`;

            dataDiv.appendChild(span1Div);
            dataDiv.appendChild(span2Div);

            container.appendChild(nameDiv);
            container.appendChild(dataDiv);
            if (this.online == false) {
                dataDiv.style.display = 'none';
            } else {
                dataDiv.style.display = 'block';
            }
            document.getElementById(id).appendChild(container);

            nameButton.addEventListener('click', (ev) => {
                dataDiv.style.display = 'block';
            });
        }

    }


    
    let contacts = [
        new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
        new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
        new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
    ];
    contacts.forEach(c => c.render('main'));
    
    // After 1 second, change the online status to true
    setTimeout(() => contacts[1].online = true, 2000);
    contacts[2].online = true;
}

