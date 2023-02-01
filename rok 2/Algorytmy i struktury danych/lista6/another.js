// Deklaracja tablic i zmiennych
var query = require("cli-interact").question;

const key = [];
const next = [];
const prev = [];
let head = null; // wartość początkowa "głowy" listy
let readName = ""; // zmienna do przechowywania czytanego nazwiska

// Funkcja do czytania nazwiska z wejścia
// Funkcja do czytania nazwiska z wejścia i dodawania go do listy dwukierunkowej
function readSurname() {
  // Pobranie nazwiska od użytkownika
  readName = query("Podaj nazwisko:");

  // Sprawdzenie, czy lista jest pusta
  if (head === null) {
    // Jeśli tak, to dodajemy nowe nazwisko jako pierwszy element w liście
    key.push(readName);
    next.push(null);
    prev.push(null);
    head = 0; // ustawienie głowy listy na nowo dodany element
  } else {
    // Jeśli lista nie jest pusta, to szukamy odpowiedniego miejsca do dodania nowego nazwiska
    let current = head;
    while (current !== null) {
      // Jeśli nowe nazwisko jest mniejsze alfabetycznie od bieżącego nazwiska
      // lub bieżące nazwisko jest ostatnim elementem w liście
      if (readName < key[current] || next[current] === null) {
        // Dodanie nowego nazwiska w odpowiednim miejscu w liście
        key.push(readName);
        next.push(current);
        prev.push(prev[current]);
        next[prev[current]] = key.length - 1;
        prev[current] = key.length - 1;
        break;
      }
      current = next[current];
    }
  }
}

// Funkcja do drukowania przeczytanych nazwisk alfabetycznie, A - Z
function printSurnamesAtoZ() {
  let current = head;
  while (current !== null) {
    console.log(key[current]);
    current = next[current];
  }
}

// Funkcja do drukowania przeczytanych nazwisk alfabetycznie, Z - A
function printSurnamesZtoA() {
  let current = head;
  while (current !== null) {
    // Znajdujemy ostatnie nazwisko w liście
    while (next[current] !== null) {
      current = next[current];
    }
    console.log(key[current]); // drukujemy ostatnie nazwisko

    // Szukamy poprzedniego nazwiska (czyli następnego w kolejności Z - A)
    // i drukujemy je
    while (prev[current] !== null) {
      current = prev[current];
      console.log(key[current]);
    }
  }
}

// Funkcja do drukowania przeczytanych nazwisk począwszy od nazwiska rozpoczynającego się podaną literą
function printSurnamesByLetter(letter) {
  let current = head;
  while (current !== null) {
    // Sprawdzenie, czy bieżące nazwisko zaczyna się od podanej litery
    if (key[current].charAt(0) === letter) {
      console.log(key[current]);
    }
    current = next[current];
  }
}

// Przykładowe wywołanie funkcji
readSurname();
readSurname();
printSurnamesAtoZ();
// printSurnamesZtoA();
// printSurnamesByLetter("A");
