function lockedProfile() {
    const users = document.querySelectorAll('input[value="lock"]');

    const buttons = document.querySelectorAll('button');

    for (const button of buttons) {
        button.addEventListener('click', showProf);
    }

    function showProf(event){
        let elements = event.target.parentNode.children;
        let hiddenInfo = elements[9];
        let but = elements[10];

        console.log(elements[2].checked);

        if(elements[2].checked == false
        && but.textContent == 'Show more'){
            hiddenInfo.style.display = 'block';
            but.textContent = 'Hide it';
        } else if (elements[2].checked == false
        && but.textContent == 'Hide it'){
            hiddenInfo.style.display = '';
            but.textContent = 'Show more';
        }
    }

}