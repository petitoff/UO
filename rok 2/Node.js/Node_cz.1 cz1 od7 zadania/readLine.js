var readline = require("readline");

var r1 = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

r1.question("Jak masz na imie?", (answer) => {
  r1.setPrompt(`Jaki jest twój ulubiony język programowania ${answer}?`);
  r1.prompt();
  r1.on("line", (language) => {
    console.log(language);
  });
});
