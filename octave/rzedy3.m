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

  m2 = m1;
  if(m1(1,1) == 0)
    m2([1],:) = m1([2],:)
    m2([2],:) = m1([1],:)
  endif
  r1 = m1(1,1);

  for j=1:a
    m2(2,j) -= m1(2,1)/r1 * m1(1,j);
  endfor

  for j=1:a
    m2(3,j) -= m1(3,1)/r1 * m1(1,j);
  endfor

  m3 = m2;
  r2 = m2(2,2);
  if(r2!=0)
    for j=1:a
      m2(3,j) -= (m3(3,2)* m3(2,j))/r2;
    endfor
  endif

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
