function browserHistory(availableInfoBeginning, newInfo) {

    let workObj = availableInfoBeginning;
    let openTabs = workObj['Open Tabs'];
    let closedTabs = workObj['Recently Closed'];
    let logs = workObj['Browser Logs'];
    let finalObject = {
        "Browser Name": workObj['Browser Name'],
        "Open Tabs": [],
        "Recently Closed": [],
        "Browser Logs": []

    }
   // console.log(Array.isArray(logs))

    for (let el of newInfo){
        let commandArr = el.split(' ');
        let command = commandArr.shift();
        let website = commandArr.join(' ');
       // console.log(website);

        if (command === 'Close' && openTabs.includes(website)){
            openTabs.splice(openTabs.indexOf(website), 1);
            closedTabs.push(website);
            logs.push(el);
        } else if (command === 'Clear'){
            openTabs = [];
            closedTabs = [];
            logs = [];
        } else if (command === 'Open'){
            openTabs.push(website);
            logs.push(el);
        }

        finalObject = {
            "Browser Name": workObj['Browser Name'],
            "Open Tabs": openTabs,
            "Recently Closed": closedTabs,
            "Browser Logs": logs
    
        }

    }
    console.log(finalObject['Browser Name']);
    console.log(`Open Tabs: ${finalObject['Open Tabs'].join(', ')}`);
    console.log(`Recently Closed: ${finalObject['Recently Closed'].join(', ')}`);
    console.log(`Browser Logs: ${finalObject['Browser Logs'].join(', ')}`);
}

browserHistory(
    {'Browser Name':'Mozilla Firefox',
        'Open Tabs':['YouTube'],
        'Recently Closed':['Gmail', 'Dropbox'],
        'Browser Logs':['Open Gmail', 'Close Gmail', 'Open Dropbox', 'Open YouTube', 'Close Dropbox']},
        ['Open Wikipedia', 'Clear History and Cache', 'Open Twitter']
)