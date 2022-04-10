function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const cells = document.querySelectorAll('tbody tr');
      const input = document.getElementById('searchField').value;

      for (let i = 0; i < cells.length; i++) {
         let element = cells[i];

         if(element.textContent.includes(input)){
            element.setAttribute('class', 'select');
         } else {
            element.removeAttribute('class');
         }
      }
   }
}
