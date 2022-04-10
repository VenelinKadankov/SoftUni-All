function solve() {
  const first = Array.from(document.getElementById('text').value.toLowerCase().split(' ')).filter(x => x.length > 0);
  const type = document.getElementById('naming-convention').value;

  const result = [];
  let start = 0;

  if (type == 'Pascal Case') {

  } else if (type == 'Camel Case') {
    result.push(first[0]);
    start = 1;
  } else {
    document.getElementById('result').textContent = 'Error!';
    return;
  }

  for (let i = start; i < first.length; i++) {
    const newWord = first[i][0].toUpperCase() +first[i].slice(1);
    result.push(newWord)    
  }

  document.getElementById('result').textContent = result.join('');
}