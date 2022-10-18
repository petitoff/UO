var http = require("http");
var fs = require("fs");

http
  .createServer((req, res) => {
    res.writeHead(200, { "content-type": "text/html" });
    fs.createReadStream("./index.html").pipe(res);
  })
  .listen(3000);

console.log("Serwer uruchomiony...");
