var fs = require("fs");

fs.mkdir("scripts", (error) => {
  if (error) {
    console.log(error);
  } else {
    console.log("Katalog został utworzony");
  }
});

fs.rename("scripts", "styles", (error) => {
  if (error) {
    console.log(error);
  } else {
    console.log("Nazwa katalogu zmieniona");
  }
});

fs.rmdir("styles", (error) => {
  if (error) {
    console.log(error);
  } else {
    console.log("Katalog usunięty");
  }
});
