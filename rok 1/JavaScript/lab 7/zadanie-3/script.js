// const dlugoscA = prompt("Podaj długość pierwszej przyprostokątnej!");
// const dlugoscB = prompt("Podaj długość drugiej przyprostokątnej!");

const btnOblicz = document.getElementById("oblicz");

function pitagoras() {
  x = Number(document.getElementById("x").value);
  y = Number(document.getElementById("y").value);
  if (typeof x !== "number" || typeof y !== "number") return false;

  document.getElementById("wynik").textContent = Math.floor(
    Math.sqrt(x * x + y * y)
  );
}

btnOblicz.addEventListener("click", pitagoras);
