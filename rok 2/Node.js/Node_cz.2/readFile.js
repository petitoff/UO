var fs = require("fs");

fs.readFile("./modules.txt", (error, content) => {
  console.log(content);
});

fs.readFile("./modules.txt", "utf-8", (error, content) => {
  console.log(content);
});
