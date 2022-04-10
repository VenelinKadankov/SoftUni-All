function solve(obj) {
    const regexURI = /^[\w.]+$/gm;
    const regexMessage = /^[^<>\\&'"]*$/gm;

    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const keys = Object.keys(obj);


    if (keys[0] != 'method' || !validMethods.includes(obj['method'])) {
        throw new Error(`Invalid request header: Invalid Method`);
    }

    if (keys[1] != 'uri' || !regexURI.test(obj['uri'])) {
        throw new Error(`Invalid request header: Invalid URI`);
    }

    if (keys[2] != 'version' || !validVersions.includes(obj['version'])) {
        throw new Error(`Invalid request header: Invalid Version`);
    }

    if (keys[3] != 'message'|| !regexMessage.test(obj['message'])) {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    return obj;

}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
));

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'asl<pls'
}));

// console.log(solve({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
//   }
//   ));

//   console.log(solve({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
//   }
//   ))