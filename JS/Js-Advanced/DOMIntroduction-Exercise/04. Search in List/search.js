function search() {
   const words = document.getElementsByTagName('li');
   const searchedText = document.getElementById('searchText').value;

   let result = Array.from(words).filter(x => x.textContent.includes(searchedText));

   for (let i = 0; i < words.length; i++) {
      const element = words[i];

      if(element.textContent.includes(searchedText)){
         element.style.textDecoration = 'underline';
         element.style.fontWeight = 'bold';
      } else {
         element.style.textDecoration = '';
         element.style.fontWeight = '';
      }
   }

   document.getElementById('result').textContent = result.length + ' matches found';
}
