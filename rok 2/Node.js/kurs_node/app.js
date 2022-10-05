var x = 7;
console.log(x);

function multiply(a, b) {
  return a * b;
}
console.log(multiply(2, 15));

var path = require("path");
const { infoPolish } = require("./info");
var basename = path.basename("user/files/documents");
console.log(basename);

var info = require("./info");
infoPolish();
