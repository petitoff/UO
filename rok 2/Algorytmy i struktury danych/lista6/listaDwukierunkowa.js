// Tworzymy puste tablice na nazwiska i indeksy nast¦pników/poprzedników
const key = [];
const next = [];
const prev = [];

function add(name, prevArg, nextArg) {
  // Tworzymy nowy element na koñcu listy
  key.push(name);
  next.push(nextArg);

  // Ustawiamy nowy element jako nast¦pnik elementu o indeksie `prev`
  next[prevArg] = key.length;

  // Ustawiamy nowy element jako poprzednik elementu o indeksie `next`
  prev[prevArg] = key.length - 1;

  console.log(next);
  console.log(prev);
}

function print(start) {
  // Zaczynamy od pierwszego elementu
  let index = start;

  // Dopóki istnieje nast¦pnik dla bie¿¡cego elementu...
  while (next[index] !== undefined) {
    // Drukujemy nazwisko dla bie¿¡cego element
    console.log(key[index]);

    // Przechodzimy do nast¦pnego elementu
    index = next[index];
  }

  // Drukujemy ostatnie nazwisko (na które nie wskazywaª ju» ¦aden indeks)
  //   console.log(key[index]);
}

function printReverse(start) {
  // Zaczynamy od ostatniego elementu
  let index = start;

  // Dopóki istnieje poprzednik dla bie¿¡cego elementu...
  while (prev[index] !== undefined) {
    // Drukujemy nazwisko dla bie¿¡cego elementu
    console.log(key[index]);

    // Przechodzimy do poprzedniego elementu
    index = prev[index];
  }

  // Drukujemy pierwsze nazwisko (na które nie wskazywaª ju» ¦aden indeks)
  //   console.log(key[index]);
}

function printStartingWith(letter) {
  // Zaczynamy od pierwszego elementu
  let index = 0;

  // Dopóki istnieje nast¦pnik dla bie¿¡cego elementu...
  while (next[index] !== undefined) {
    // Je¦li nazwisko dla bie¿¡cego elementu rozpoczyna si¦ od podanej litery...
    if (key[index].startsWith(letter)) {
      // Drukujemy nazwisko dla bie¿¡cego elementu
      console.log(key[index]);
    }
    // Przechodzimy do nast¦pnego elementu
    index = next[index];
  }

  // Je¦li ostatnie nazwisko (na które nie wskazywaª ju» ¦aden indeks) rozpoczyna si¦ od podanej litery...
  if (key[index].startsWith(letter)) {
    // Drukujemy ostatnie nazwisko
    console.log(key[index]);
  }
}

// Ustawiamy pierwszy element (puste nazwisko) jako poprzednik i nast¦pnik dla drugiego elementu (pierwsze nazwisko)
// prev[1] = 0;
// next[0] = 1;

// Dodajemy nowe nazwiska do listy w odpowiednim miejscu, zgodnie z kolejno±ci¡ alfabetyczn¡
add("Nowak", 0, 1);
add("Kowalski", 1, 2);
add("Wiśniewski", 2, 3);
add("Wójcik", 3, 4);
add("Kowalczyk", 4, 5);
add("Kamiñski", 5, 6);
add("Lewandowski", 6, 7);
add("Duda", 7, 8);

// // Drukujemy nazwiska z listy, pocz¡wszy od pierwszego elementu
console.log("Nazwiska alfabetycznie, A  Z:");
print(0);

// // Drukujemy nazwiska z listy w odwrotnej kolejno±ci, pocz¡wszy od ostatniego elementu
console.log("\nNazwiska alfabetycznie, Z  A:");
printReverse(key.length - 1);

// // Drukujemy nazwiska z listy, pocz¡wszy od nazwiska rozpoczynaj¡cego si¦ od podanej litery
// console.log("\nNazwiska rozpoczynaj¡ce si¦ od litery K:");
// printStartingWith("K");
