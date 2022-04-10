function generateReport() {

    let outputElement = document.querySelector('#output');
    let tableHead = document.querySelectorAll('tr th');
    let tableBody = document.querySelectorAll('tbody tr');

    let output = [];

    for (const row of tableBody) {

        let rowObj = {};

        for (let i = 0; i < row.children.length; i++) {

            let key = tableHead[i].lastChild.name;
            let val = row.children[i].textContent;

            if (tableHead[i].lastChild.checked) {
                rowObj[key] = val;
            }

        }
        
        output.push(rowObj);
    }

    outputElement.textContent = JSON.stringify(output, null, '\t');
}