function toggle() {
    const element = document.getElementsByClassName('button')[0];

    if(element.textContent == 'More'){
        element.textContent = 'Less';
        document.getElementById('extra').style.display = 'block';
    } else {
        element.textContent = 'More';
        document.getElementById('extra').style.display = 'none';
    }

    //console.log('TODO:...');
}