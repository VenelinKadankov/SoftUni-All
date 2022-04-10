function solve() {
  const items = document.querySelectorAll('textarea')[0];
  const buttonAdd = document.querySelectorAll('button')[0];
  buttonAdd.addEventListener('click', onClickAddItem);

  const buttonBuy = document.querySelectorAll('button')[1];
  buttonBuy.addEventListener('click', onBuy);

  function onBuy(event){
    const prodNames = [];
    let counter = 0;
    let decFactor = 0;
    let sum = 0;
    const wantedItems = Array.from(document.querySelectorAll('input'));//.slice(1);

    for (const item of wantedItems) {
      if(item.checked == true){
        
        if(!prodNames.includes(item.parentNode.parentNode.children[1].innerHTML)){
          prodNames.push(item.parentNode.parentNode.children[1].innerHTML);
        }

        counter++;
        sum += Number(item.parentNode.parentNode.children[2].innerHTML);
        decFactor += Number(item.parentNode.parentNode.children[3].innerHTML);
      }
    }

    let result = `Bought furniture: ${prodNames.join(', ')}\n` + 
    `Total price: ${sum.toFixed(2)}\n` + 
    `Average decoration factor: ${decFactor / counter}`;

    document.querySelectorAll('textarea')[1].value = result;
  }


  function onClickAddItem(event){
    const itemObjects = JSON.parse(items.value);

    console.log(itemObjects);

    for (const info of itemObjects) {
      let img = info.img;
      let name = info.name;
      let price = info.price;
      let decFactor = info.decFactor;

      let tableRow = document.createElement('TR');

      let imgEl = document.createElement('TD');
      let innerImg = document.createElement('IMG');
      innerImg.setAttribute('SRC', img);
      imgEl.appendChild(innerImg);
      tableRow.appendChild(imgEl);

      let nameEl = document.createElement('TD');
      nameEl.textContent = name;
      tableRow.appendChild(nameEl);

      let priceEl = document.createElement('TD');
      priceEl.textContent = price;
      tableRow.appendChild(priceEl);

      let factorEl = document.createElement('TD');
      factorEl.textContent = decFactor;
      tableRow.appendChild(factorEl);

      let boxEl = document.createElement('TD');
      let box = document.createElement('INPUT');
      box.setAttribute('type', 'checkbox');
      boxEl.appendChild(box);
      tableRow.appendChild(boxEl);

      document.querySelector('tbody').appendChild(tableRow);
    }
  }

}