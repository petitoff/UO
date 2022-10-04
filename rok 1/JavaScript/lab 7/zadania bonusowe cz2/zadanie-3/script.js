const btn = document.getElementById("btn");
let komunikat = [];

const sprawdzMozliwoscIstnieniaTrojkata = function () {
  const a = Number(document.getElementById("input1").value);
  const b = Number(document.getElementById("input2").value);
  const c = Number(document.getElementById("input3").value);

  const wynik1 = a * a + b * b;
  if (wynik1 === c * c) {
    document.getElementById("wynik").textContent =
      "Wymiary spełniają warónki trójkąta prostokątnego";
    return;
  }

  const trojkatRownoramienny = [...new Set([a, b, c])];
  if (trojkatRownoramienny.length === 2) {
    document.getElementById("wynik").textContent =
      "Wymiary spełniają warónki trójkąta rownoramiennego";
    return;
  }

  const trojkatRownoboczny = [...new Set([a, b, c])];
  if (trojkatRownoboczny.length === 1) {
    document.getElementById("wynik").textContent =
      "Wymiary spełniają warónki trójkąta równobocznego";
    return;
  }

  document.getElementById("wynik").textContent =
    "Wymiary nie spełniają żadnych warónków";
};

btn.addEventListener("click", sprawdzMozliwoscIstnieniaTrojkata);
