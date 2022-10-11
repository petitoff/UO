var fs = require("fs");
var fileList = fs.readdirSync("./");
console.log(fileList);

fs.readdir("./", (error, fileList) => {
  console.log(error);
  console.log(fileList);
});

fs.readdir("./asd", (error, fileList) => {
    console.log(error);
    console.log(fileList);
  });
  