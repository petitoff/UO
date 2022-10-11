process.stdout.write("Jak masz na imię?\n");

process.stdin.on("data", (name) => {
  console.log(`Witaj ${name.toString()}`);
});
