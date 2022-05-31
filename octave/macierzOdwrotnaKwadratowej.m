function wynik = macierzOdwrotnaKwadratowej(m1)
  [a,b] = size(m1);

  if(a != b)
    wynik = "Macierz nie jest kwadratowa";
    return;
  endif

  if(a > 3)
    wynik = "Program potrafi liczyć macierze odwrotne do stopnia macierza 3";
    return;
  endif

  wyznacznik = obliczanieWyznacznika(m1, a);
  if(wyznacznik == 0)
    wynik = "Macierz nie jest odwracalna";
    return;
  endif

  q = m1(2,2) * m1(3,3) - m1(2,3) * m1(3,2);
  w = m1(1,3) * m1(3,2) - m1(1,2) * m1(3,3);
  e = m1(1,2) * m1(2,3) - m1(1,3) * m1(2,2);
  r = m1(2,3) * m1(3,1) - m1(2,1) * m1(3,3);
  t = m1(1,1) * m1(3,3) - m1(1,3) * m1(3,1);
  y = m1(1,3) * m1(2,1) - m1(1,1) * m1(2,3);
  u = m1(2,1) * m1(3,2) - m1(2,2) * m1(3,1);
  o = m1(1,2) * m1(3,1) - m1(1,1) * m1(3,2);
  p = m1(1,1) * m1(2,2) - m1(1,2) * m1(2,1);

  wynik = [q w e; r t y; u o p];

  for i=1:a
    for j=1:b
      wynik(i,j) *= 1/wyznacznik;
    endfor
  endfor
endfunction

function ww = obliczanieWyznacznika(m1, a)
  if(a == 1)
    ww = m1(1,1)
    return;
  elseif (a == 2)
    ww = m1(1,1) * m1(2,2) - m1(1,2) * m1(2,1);
    return;
  elseif (a == 3)
    ww = m1(1,1) * m1(2,2) * m1(3,3);
    ww += m1(1,2) * m1(2,3) * m1(3,1);
    ww += m1(1,3) * m1(2,1) * m1(3,2);

    ww -= m1(1,3) * m1(2,2) * m1(3,1);
    ww -= m1(1,1) * m1(2,3) * m1(3,2);
    ww -= m1(1,2) * m1(2,1) * m1(3,3);
  endif
endfunction
