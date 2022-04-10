function create(words) {
   const body = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {

      const element = document.createElement('div');
      const innerText = document.createElement('p');
      innerText.textContent = words[i];

      element.addEventListener('click', () => {
         innerText.style.display = 'block';
      });

      element.appendChild(innerText);
      innerText.style.display = 'none';

      body.appendChild(element);
   }

}