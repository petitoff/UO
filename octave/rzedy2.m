function wynik = rzedy2(m1)
  [a,b] = size(m1);

  if(b != 2)
    disp("Podałeś nieprawidłową macierz!");
    return;
  endif

  spr1 = 0;
  spr2 = 0;

  # sprawdzanie czy są tylko 0

  for i=1:a
    for j=1:b
      if(m1(i,j)!= 0)
        spr1 += 1;
      endif
    endfor
  endfor

  if(spr1 == 0)
    wynik = 0;
    return;
  endif

  # sprawdzanie wyznaczników wszystkich macierzy 2x2
  for i=1:a
    for j=1:a
      wyznacznik = m1(i,1) * m1 (j,2) - m1(i,2) * m1(j,1);
      if (wyznacznik != 0)
        spr2 += 1;
      endif
    endfor
  endfor

  if(spr2 == 0)
    wynik = 1; # wszystkie wyznaczniki wszystkich macierzy 2x2 były równe 0
    return;
  endif

  # sprawdzanie czy jest liniowo niezależny
  for i=1:a
    if(m1(i,1)*m1(i+1,2))==(m1(i,2)*m1(2,i))
      wynik = 2; # jest liniowo zależny
      return;
    endif
  endfor

  wynik = 1; # jest liniowo niezależny
endfunction
