var http = require("http");
var fs = require("fs");

// http
//   .createServer((req, res) => {
//     res.writeHead(200);
//     res.end("Witaj");
//   })
//   .listen(3000);

// http
//   .createServer((req, res) => {
//     res.writeHead(200, { "content-type": "text/plain" });
//     var html = fs.readFileSync("./index.html");
//     res.end(html);
//   })
//   .listen(3000);

http
  .createServer((req, res) => {
    res.writeHead(200, { "content-type": "text/html" });
    var html = fs.readFileSync("./index.html");
    res.end(html);
  })
  .listen(3000);

console.log("Serwer uruchomiony...");
