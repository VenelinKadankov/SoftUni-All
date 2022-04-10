function validate() {
    const userNameInput = document.getElementById('username');
    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirm-password');
    const isCompanyInput = document.getElementById('company');
    const companyInfoContainer = document.getElementById('companyInfo');
    const companyNumberInput = document.getElementById('companyNumber');
    const buttonSubmit = document.getElementById('submit');
    const validDiv = document.getElementById('valid')

    isCompanyInput.addEventListener('change', () => {
        if (isCompanyInput.checked == true) {
            companyInfoContainer.style.display = 'block';
        } else {
            companyInfoContainer.style.display = 'none';
        }
    });


    buttonSubmit.addEventListener('click', (ev) => {
        ev.preventDefault();
        let allIsValid = true;

        const usernamePattern = /^[A-Za-z\d]{3,20}$/;
        if (!userNameInput.value.match(usernamePattern)) {
            allIsValid = false;
            userNameInput.style.borderColor = 'red';
        } else {
            userNameInput.style.border = 'none';
        }

        const emailPattern = /^.*\@.*\..*$/;
        if (!emailInput.value.match(emailPattern)) {
            allIsValid = false;
            emailInput.style.borderColor = 'red';
        } else {
            emailInput.style.border = 'none';
        }

        const passwordPattern = /^[\w]{5,15}$/;
        if (!passwordInput.value.match(passwordPattern) || 
        !confirmPasswordInput.value.match(passwordPattern) || 
        passwordInput.value != confirmPasswordInput.value) {//if(!passwordPattern.test(confirmPasswordInput.value) || passwordInput.value != confirmPasswordInput.value){
            allIsValid = false;
            passwordInput.style.borderColor = 'red';
            confirmPasswordInput.style.borderColor = 'red';
        } else {
            passwordInput.style.border = 'none';
            confirmPasswordInput.style.border = 'none';
        }

        const companyNumberPattern = /^[1-9][0-9]{3}$/;
        if(isCompanyInput.checked == true ){
            if (!companyNumberInput.value.match(companyNumberPattern)) {
                allIsValid = false;
                companyNumberInput.style.borderColor = 'red';
            } else {
                companyNumberInput.style.border = 'none';
            }
            
        }

        if (allIsValid) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }
    });

}