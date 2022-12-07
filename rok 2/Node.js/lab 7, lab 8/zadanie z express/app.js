var express = require("express");
var app = express();
app.set("view engine", "jade");

// Routing
app.get("/", function (req, res) {
  res.send("index", { header: "Witaj na stronie Index" });
});

app.get("/contact", function (req, res) {
  res.send("Strona kontakt");
});

app.get("/product/:id", function (req, res) {
  res.send("Strona produktu o id: " + req.params.id);
});

app.listen(3000);
