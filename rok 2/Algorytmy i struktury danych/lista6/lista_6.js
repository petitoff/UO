var query = require("cli-interact").question;

const key = new Array(100);
const prev = new Array(100);
const next = new Array(100);
let head = undefined;
let tail = undefined;
let ilosc = 0;
let isShowOptions = true;

const input = (text) => {
  isShowOptions = true;
  return query(text);
};

const stringMax = (str1, str2) => {
  let lenght, shortNumber;
  str1 = str1.toLowerCase();
  str2 = str2.toLowerCase();

  if (str1 === str2) {
    return false;
  }

  if (str1.length >= str2.length) {
    lenght = str1.length;
    shortNumber = str2.length;
  } else {
    lenght = str2.length;
    shortNumber = str1.length;
  }

  for (let i = 0; i < lenght; i++) {
    if (i < shortNumber) {
      if (str1[i] < str2[i]) {
        return true;
      } else if (str1[i] > str2[i]) {
        return false;
      }
    } else {
      if (shortNumber == str1.length) {
        return true;
      } else {
        return false;
      }
    }
  }
};

const mainFunc = () => {
  while (true) {
    if (isShowOptions) {
      console.log("====================================");
      console.log("Wybierz Opcje i naciśnij enter");
      console.log("1.Czytanie Nazwiska");
      console.log("2.Drukowanie Nazwisk Alfabetycznie A-Z");
      console.log("3.Drukowanie Nazwisk Alfabetycznie Z-A");
      console.log("4.Drukowanie Nazwisk od litery");
      console.log("5.Wyjście");
      console.log();
      option = query("Wybierz opcje: ");
      isShowOptions = false;
    } else {
      if (option === "1") {
        if (ilosc === 0) {
          key[0] = input("Podaj Nazwisko: ");
          head = 0;
          tail = 0;
          ilosc += 1;
        } else {
          if (ilosc === 100) {
            console.log(
              "Nie można dodać więcej elementów do listy, lista jest pełna"
            );
          } else {
            key[ilosc] = input("Podaj Nazwisko: ");
            if (stringMax(key[ilosc], key[head])) {
              prev[head] = ilosc;
              next[ilosc] = head;
              head = ilosc;
            } else {
              let go = next[head];
              while (go !== undefined) {
                if (stringMax(key[ilosc], key[go])) {
                  next[prev[go]] = ilosc;
                  next[ilosc] = go;
                  prev[ilosc] = prev[go];
                  prev[go] = ilosc;
                  break;
                }
                if (next[go] === undefined) {
                  prev[ilosc] = go;
                  next[go] = ilosc;
                  break;
                }
                go = next[go];
              }
            }
            ilosc += 1;
            let go = head;
            while (next[go] !== undefined) {
              go = next[go];
              if (next[go] === undefined) {
                tail = go;
                break;
              }
            }
          }
        }
      } else {
        isShowOptions = true;
        if (option === "2") {
          if (ilosc > 0) {
            console.log(`${key[head]}`);
            let go = next[head];
            for (let i = 0; i < ilosc - 1; i++) {
              console.log(`${key[go]}`);
              go = next[go];
            }
          } else {
            console.log("====================================");
            console.log(`Brak elementów na liście`);
            console.log("====================================");
          }
          input("Naciśij dowoly klawisz aby wyjść");
        } else {
          if (option === "3") {
            if (ilosc > 0) {
              console.log(`${key[tail]}`);
              let go = prev[tail];
              for (var i = 0, _pj_a = ilosc - 1; i < _pj_a; i += 1) {
                console.log(`${key[go]}`);
                go = prev[go];
              }
            } else {
              console.log("Brak elementów na liście");
            }
            input("Naciśij dowoly klawisz aby wyjść");
          } else {
            if (option === "4") {
              if (ilosc > 0) {
                const nameOfChar = input("Od jakiej litery drukować: ");
                if (nameOfChar.length === 1) {
                  go = head;
                  if (go !== undefined) {
                    while (stringMax(key[go][0], nameOfChar)) {
                      go = next[go];
                      if (go === undefined) {
                        break;
                      }
                    }
                  }
                  if (go !== undefined) {
                    while (go !== undefined) {
                      console.log(`${key[go]}`);
                      go = next[go];
                    }
                  } else {
                    console.log(
                      `\nBrak nazwisk zaczynających się po literze ${nameOfChar}`
                    );
                  }
                } else {
                  console.log(`\nBłąd ${nameOfChar} to nie litera`);
                }
              } else {
                console.log("Brak elementów na liście");
              }
              input("Naciśij dowoly klawisz aby wyjść");
            } else {
              if (option === "5") {
                return;
              }
            }
          }
        }
      }
    }
  }
};
mainFunc();
