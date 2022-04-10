function attachEventsListeners() {

    const buttons = document.querySelectorAll('input[type="button"]');

    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', onClick);
    }


    function onClick(ev){

        const type = ev.target.parentElement.children[1].id;
        const value = Number(ev.target.parentElement.children[1].value);

        let seconds = 0;

        if(type == 'days'){
            seconds = value * 86400;
        } else if (type == 'hours'){
            seconds = value * 3600;
        } else if (type == 'minutes'){
            seconds = value * 60;
        } else {
            seconds = value;
        }

        const days = seconds / 86400;
        const hours = seconds / 3600;
        const minutes = seconds / 60;

        document.getElementById('days').value = days;
        document.getElementById('hours').value = hours;
        document.getElementById('minutes').value = minutes;
        document.getElementById('seconds').value = seconds;
    }

}