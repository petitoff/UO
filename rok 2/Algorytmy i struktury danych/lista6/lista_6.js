const readline = require("readline");
var query = require("cli-interact").question;

var go, head, ilosc, key, nameOfChar, nxt, option, prv, tail;

function is_int(text) {
  try {
    Number.parseInt(text);
    return true;
  } catch (e) {
    return false;
  }
}

const input = (text) => {
  const answer = query(text || "");

  isShowOptions = true;
  return answer.toString();
};

function string_max(str1, str2) {
  if (str1 === undefined || str2 === undefined) return false;

  var lenght, shortNumber;
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

  for (var i = 0, _pj_a = lenght; i < _pj_a; i += 1) {
    if (i < shortNumber) {
      if (str1[i] < str2[i]) {
        return true;
      } else {
        if (str1[i] > str2[i]) {
          return false;
        }
      }
    } else {
      if (shortNumber === str1.length) {
        return true;
      } else {
        return false;
      }
    }
  }
}

key = [null] * 100;
prv = [null] * 100;
nxt = [null] * 100;
head = null;
tail = null;
ilosc = 0;

let isShowOptions = true;

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

            if (string_max(key[ilosc], key[head])) {
              prv[head] = ilosc;
              nxt[ilosc] = head;
              head = ilosc;
            } else {
              go = nxt[head];

              while (go !== null) {
                if (string_max(key[ilosc], key[go])) {
                  nxt[prv[go]] = ilosc;
                  nxt[ilosc] = go;
                  prv[ilosc] = prv[go];
                  prv[go] = ilosc;
                  break;
                }

                if (nxt[go] === null) {
                  prv[ilosc] = go;
                  nxt[go] = ilosc;
                  break;
                }

                go = nxt[go];
              }
            }

            ilosc += 1;
            go = head;

            while (nxt[go] !== null) {
              go = nxt[go];

              if (nxt[go] === null) {
                tail = go;
                break;
              }
            }
          }
        }
      } else {
        if (option === "2") {
          if (ilosc > 0) {
            console.log(`${key[head]}`);
            go = nxt[head];

            for (var i = 0, _pj_a = ilosc - 1; i < _pj_a; i += 1) {
              console.log(`${key[go]}`);
              go = nxt[go];
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
              go = prv[tail];

              for (var i = 0, _pj_a = ilosc - 1; i < _pj_a; i += 1) {
                console.log(`${key[go]}`);
                go = prv[go];
              }
            } else {
              console.log("Brak elementów na liście");
            }

            input("Naciśij dowoly klawisz aby wyjść");
          } else {
            if (option === "4") {
              clear();

              if (ilosc > 0) {
                nameOfChar = input("Od jakiej litery drukować: ");

                if (nameOfChar.length === 1) {
                  go = head;

                  if (go !== null) {
                    while (string_max(key[go][0], nameOfChar)) {
                      go = nxt[go];

                      if (go === null) {
                        break;
                      }
                    }
                  }

                  if (go !== null) {
                    while (go !== null) {
                      console.log(`${key[go]}`);
                      go = nxt[go];
                    }
                  } else {
                    console.log(`
      Brak nazwisk zaczynających się po literze ${nameOfChar}`);
                  }
                } else {
                  console.log(`
      Błąd ${nameOfChar} to nie litera`);
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
