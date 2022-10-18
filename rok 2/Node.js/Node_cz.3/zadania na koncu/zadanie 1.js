var http = require("http");

http.get("http://www.onet.pl/", (res) => {
  res.on("data", (data) => {
    console.log(data);
  });
});
