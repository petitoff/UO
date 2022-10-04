const btn = document.getElementById("btn");

const wielokrotnoscCheck = function () {
  const liczba1 = Number(document.getElementById("input1").value);
  const liczba2 = Number(document.getElementById("input2").value);
  if (isNaN(liczba1) || isNaN(liczba2)) {
    alert("Tylko liczby!");
    return;
  }

  const wynik1 = liczba1 % liczba2;
  const wynik2 = liczba2 % liczba1;

  let wynikFinalny;
  if (wynik1 === 0) {
    wynikFinalny = `${liczba2} jest wielokrotnością liczby ${liczba1}. `;
  } else if (wynik2 === 0) {
    wynikFinalny = `${liczba1} jest wielokrotnością liczby ${liczba2}. `;
  } else {
    wynikFinalny = "Liczby nie są wielokrotnościami siebie!";
  }
  document.getElementById("wypisz").textContent = wynikFinalny;
};

btn.addEventListener("click", wielokrotnoscCheck);
