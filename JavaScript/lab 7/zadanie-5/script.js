const btnOblicz = document.getElementById("btnOblicz");

const rownanieKwadratowe = function () {
  const a = Number(document.getElementById("x").value);
  const b = Number(document.getElementById("y").value);
  const c = Number(document.getElementById("z").value);

  const delta = Math.sqrt(b * b - 4 * a * c);

  let minus;
  let plus;
  if (delta > 0) {
    minus = (-b - delta) / (2 * a);
    plus = (-b + delta) / (2 * a);
  } else if (squareRoot == 0) {
    minus = -b - 0 / (2 * a);
    plus = -b + 0 / (2 * a);
  }

  document.getElementById(
    "wynik"
  ).textContent = `Wynik to: ${minus} oraz ${plus}. Delta to: ${delta}`;
};

btnOblicz.addEventListener("click", rownanieKwadratowe);
