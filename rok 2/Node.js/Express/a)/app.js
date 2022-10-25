import express from "express";

var app = express();

app.get("/", (req, res) => {
  res.send("Witaj w Expressjs");
});

app.listen(3000);
