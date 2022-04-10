var arr = ['pear', 'apple', 'orange', 'apple', 'orange', 'apple'];
//find the counts using reduce
var cnts = arr.reduce( function (obj, val) {
    obj[val] = (obj[val] || 0) + 1;
    return obj;
}, {} );
//Use the keys of the object to get all the values of the array
//and sort those keys by their counts
var sorted = Object.keys(cnts).sort( function(a,b) {
    return cnts[b] - cnts[a];
});
console.log(cnts);