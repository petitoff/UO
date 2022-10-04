function wynik = macierzOdwrotnaDwaNaDwa(m1)
  # lista - Macierze odwrotne
  # zadanie - Dwa wiersze i dwie kolumny

  [a,b] = size(m1);

  if(a != 2 && b != 2)
    wynik = "Macierz nie jest 2x2 więc macierz odwrotna nieistnieje";
    return;
  endif

  # obliczanie wyznacznika
  wyznacznik = m1(1,1) * m1(2,2) - m1(1,2) * m1(2,1);

  if(wyznacznik == 0)
    wynik = "Macierz odwrotna nie istnieje";
    return;
  endif

  # obliczanie macierzy odwrotnej
  wynik = [m1(2,2) -m1(1,2); -m1(2,1) m1(1,1)];

  for i=1:a
    for j=1:b
      wynik(i,j) *= 1/wyznacznik;
    endfor
  endfor


endfunction
