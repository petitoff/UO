const btn = document.getElementById("btn");

const integerPower = function (podstawa, wykladnik) {
  let wynik = 1;
  for (let i = 0; i < wykladnik; i++) {
    console.log(podstawa);
    wynik *= podstawa;
  }
  return wynik;
};

btn.addEventListener("click", function () {
  const podstawa = Number(document.getElementById("podstawa").value);
  const wykladnik = Number(document.getElementById("wykladnik").value);

  const wynik = integerPower(podstawa, wykladnik);

  document.getElementById("wynik").textContent = wynik;
});
