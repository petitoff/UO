function wynik = rzedy3(m1)
  [a,b] = size(m1);

  if(a!=b)
    disp("Macierz nie jest kwadratowa!");
    return;
  endif

  if(a!=3)
    disp("Macierz nie jest 3x3");
    return;
  endif

  # sprawdzenie czy nie ma samych zer w macierzy
  spr1 = 0;
  for i=1:a
    for j=1:a
      if(m1(i,j) != 0)
        spr1 = 1;
      endif
    endfor
  endfor

  if(spr1 == 0)
    wynik = 0;
    return;
  endif

  # szukamy czy jest zero w macierzy
  # m1([2],:) = []; # usuwanie wierszy
  # m1(:,[1]) = []; # usuwanie kolumn

  m2 = m1; # kopiowanie macierzy
  petlalicz = 3; # ile razy ma się wykonac petla i

  for k=1:a
    if(k >= 3)
      break;
    endif

    for i=1:a
      m3 = m2; # kopiowanie macierzy m2

      if(i >= petlalicz)
        break;
      endif


      prawyIndexq = 1; # kolumna

      if (m3(i+k,1) == 0)
        prawyIndexq += 1; # jeżeli w pierwszej kolumnie wystąpiło zero to przejdź do kolejnej kolumny
      endif

      q = m3(i+k,prawyIndexq);
      r1 = m2(k,prawyIndexq);

      for j=1:a
        m2(i+k,j) -= q/r1 * m3(k,j)
      endfor
    endfor

    petlalicz -= 1;
  endfor




  # zliczanie niezerowych wierszy
  spr2 = 0;
  wynik = 3;
  for i=1:a
    for j=1:a
      if (m2(i,j) != 0)
        spr2 = 1;
      endif
    endfor
    if(spr2 == 0)
      wynik -= 1;
    endif
    spr2 = 0;
  endfor

endfunction
