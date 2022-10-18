var http = require("http");

http
  .createServer((req, res) => {
    if (req.url === "/") {
      res.writeHead(200);
      res.end("Strona startowa");
    } else if (req.url === "/accessories") {
      res.writeHead(200);
      res.end("Strona akcesorii");
    } else if (req.url === "/model") {
      res.writeHead(200);
      res.end("Strona Modele");
    } else {
      res.writeHead(404);
      res.end("Strony nie znaleziono");
    }
  })
  .listen(3000);

console.log("Serwer uruchomiony...");
