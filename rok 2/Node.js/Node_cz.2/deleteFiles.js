var fs = require("fs");

// fs.unlink("./footer.html", (error) => {
//   if (error) {
//     console.log(error);
//   }
// });

fs.rename("./plik.txt", "readme.txt", (error) => {
  if (error) {
    console.log(error);
  }
});
