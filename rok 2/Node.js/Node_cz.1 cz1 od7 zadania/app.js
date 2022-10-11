function showInfo(callback) {
  console.log("Kurs Node.js");

  setTimeout(() => {
    callback();
  }, 3000);
}

showInfo(() => {
  console.log("Callback został wywołany");
});