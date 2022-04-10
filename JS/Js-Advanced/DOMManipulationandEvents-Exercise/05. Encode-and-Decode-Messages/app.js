function encodeAndDecodeMessages() {
    const input = document.querySelector('textarea');
    const encodeButton = document.querySelector('button');

    encodeButton.addEventListener('click', encode);

    const output = document.querySelectorAll('textarea')[1];
    const decodeButton = document.querySelectorAll('button')[1];

    decodeButton.addEventListener('click', encode);

    function encode(event){
        const result = [];

        if(event.target.textContent == 'Encode and send it'){
            [...input.value].forEach(element => {
                result.push(String.fromCharCode(element.charCodeAt(0) + 1));
            });

            input.value = '';
        } else if (event.target.textContent == 'Decode and read it') {
            [...output.value].forEach(element => {
                result.push(String.fromCharCode(element.charCodeAt(0) - 1));
            });
        }

        output.value = result.join('');
    }
}