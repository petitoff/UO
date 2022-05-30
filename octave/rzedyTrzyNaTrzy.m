function wynik = rzedyTrzyNaTrzy(m1)

  # a - wiersze
  # b - kolumny

  [a,b] = size(m1);

  # obliczanie wyznacznika metodą trójkąta
  wyzniacznik = 0;
  wyzniacznik += m1(1,1) * m1(2,2) * m1(3,3);
  wyzniacznik += m1(1,2) * m1(2,3) * m1(3,1);
  wyzniacznik += m1(1,3) * m1(2,1) * m1(3,2);

  wyzniacznik -= m1(1,3) * m1(2,2) * m1(3,1);
  wyzniacznik -= m1(1,1) * m1(2,3) * m1(3,2);
  wyzniacznik -= m1(1,2) * m1(2,1) * m1(3,3);

  if(wyzniacznik != 0)
    # jeżeli wyzniacznik jest różny od 0 to wynikiem jest 3
    wynik = 3;
    return;
  endif

  # w przeciwnym razie przechodzimy do kolejnego kroku
  boolSpr = 0;

  for i=1:a - 1
    for j = 1:b - 1
      spr = m1(i,j) * m1(i+1,j+1) - m1(i,j+1) * m1(i+1,j);
      if(spr != 0)
        boolSpr += 1;
      endif
    endfor
  endfor

  if(boolSpr == 0)
    wynik = 1
  else
    wynik = 2;
  endif
endfunction
