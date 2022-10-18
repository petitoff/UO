var http = require("http");
var fs = require("fs");

http
  .createServer((req, res) => {
    res.writeHead(200, { "content-type": "text/html" });
    var html = fs.readFileSync("./index.html", "utf-8");
    var header = "Witaj na stronie internetowej";
    html = html.replace("{ Header }", header);
    res.end(html);
  })
  .listen(3000);

console.log("Serwer uruchomiony...");
