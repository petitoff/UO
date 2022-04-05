const dlugoscPodstawy = prompt("Podaj długość podstawy trójkąta!");
const wysokoscTrojkata = prompt("Podaj wysokość trójkąta!");

const polePowierzni = (dlugoscPodstawy * wysokoscTrojkata) / 2;

document.getElementById(
  "wynik"
).textContent = `Pole trójkąta wynosi ${polePowierzni}`;
