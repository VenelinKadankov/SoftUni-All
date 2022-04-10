function solve() {
    const infoArea = document.getElementById('info');
    const infoSpan = document.getElementsByClassName('info')[0];
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');

    let url = 'http://localhost:3030/jsonstore/bus/schedule/';
    let stopId = '';
    let stopName = '';

    async function depart() {
        if (stopId === '') {
            stopId = 'depot';
        }

        try {

            let promise = await fetch(url + stopId);
            let data = await promise.json();

            stopName = data.name;
            stopId = data.next;

            infoSpan.textContent = `Next stop ${stopName}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        } catch {
            infoSpan.textContent = `Error`;

            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    async function arrive() {

        try {
            infoSpan.textContent = `Arriving at ${stopName}`;

            let promise = await fetch(url + stopId);
            let data = await promise.json();

            stopName = data.name;
            stopId = data.next;

            departBtn.disabled = false;
            arriveBtn.disabled = true;
        }
        catch {
            infoSpan.textContent = `Error`;

            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();