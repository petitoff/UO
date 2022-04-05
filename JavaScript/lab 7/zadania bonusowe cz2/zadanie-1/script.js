const btn = document.getElementById("btn");
btn.addEventListener("click", function () {
  let number = document.getElementById("number").value;
  if (isNaN(number)) {
    alert("To nie liczba!");
    return;
  } else {
    console.log(Number(number));
    number = Number(number);
  }

  let msgUser;
  number % 2 === 0
    ? (msgUser = `Liczba ${number} jest parzysta`)
    : (msgUser = `Liczba ${number} nie jest parzysta`);

  document.getElementById("wynik").textContent = msgUser;
});
