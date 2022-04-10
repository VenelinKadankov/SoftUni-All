function solve() {
  const text = Array.from(document.getElementById('input').value.split('.')).filter(x => x.length > 0);

  console.log(text);

  const result = [];

  let counter = 0;
  let paragraf = '';

  for (let i = 0; i < text.length; i++) {
    counter++;

    paragraf += text[i] + '. ';

    console.log(paragraf);

    if(counter % 3 == 0){
      result.push(paragraf.trim());
      counter = 0;
      paragraf = '';
    }
    
  }

  if(paragraf != ''){
    result.push(paragraf.trim());
  }

  let element = document.getElementById('output');
  for (const par of result) {
    // let parag = document.createElement('p');
    // let node = document.createTextNode(par);
    // parag.appendChild(node);
    // document.getElementById('output').appendChild(parag);
    element.innerHTML += `<p>${par}</p>`;

  }
}
