const btn = document.getElementById("btn");

const silnia = function () {
  const liczba = Number(document.getElementById("input1").value);

  let wynik = 1;
  for (let i = 1; i <= liczba; i++) {
    wynik *= i;
  }
  document.getElementById("wynik").textContent = `Wynik: ${wynik}`;
};

btn.addEventListener("click", silnia);
