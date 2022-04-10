function validate() {
    const regExpPattern = /^[a-z]+\@[a-z]+\.[a-z]+$/gm;
    
    const emailField = document.getElementById('email');

    emailField.addEventListener('change', () => {
        const emailText = emailField.value;

        if (regExpPattern.test(emailText)) {
            emailField.removeAttribute('class');
        } else {
            emailField.classList.add('error');
        }
    })
}