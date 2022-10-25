var express = require("express");

var app = express();
// Routing
app.get("/", (req, res) => {
  res.send("Strona Start");
});

app.get("/contact", (req, res) => {
  res.send("Strona Kontakt");
});

app.get("/product/*", (req, res) => {
  res.send("Strona Product");
});

app.listen(3000);
