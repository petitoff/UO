function wynik = rzedyDwieKolumny(m1)
  # lista - Rzedy
  # zadanie - Dwie kolumny

  # a - wiersze
  # b - kolumny

  [a,b] = size(m1);
  spr1 = 0;
  spr2 = 0;

  # sprawdzanie czy podana macierz posiada dwie kolumny
  if(b != 2)
    wynik = "Podałeś nieprawidołową macierz!";
    return;
  endif

  wierszeG = 1;
  wierszeD = 2;

  while(wierszeD < a)

    wyznacznikMacierza2x2 = m1(wierszeG,1) * m1(wierszeD,2) - m1(wierszeG,2) * m1(wierszeD,1);
    if(wyznacznikMacierza2x2 != 0)
      spr2 = 1;
    endif

    if(spr2 == 0)
      for i=1:a
        if(m1(i,1)!=0)
          spr1=1;
        endif
        if(m1(i,2)!=0)
          spr1=1;
        endif
      endfor
    endif

    wierszeG = wierszeG + 1;
    wierszeD = wierszeD + 1;
  endwhile

  if(spr2 == 1)
    wynik = 2;
    return;
  endif

  if(spr1 == 1)
    wynik = 1;
    return;
  else
    wynik = 0;
    return;
  endif
endfunction
