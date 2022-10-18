var http = require("http");

http.get("http://strefakursow.pl/", (res) => {
  res.on("data", (data) => {
    console.log(data);
  });
});

http.get("http://strefakursow.pl/", (res) => {
  res.on("data", (data) => {
    console.log(data.toString());
  });
});
