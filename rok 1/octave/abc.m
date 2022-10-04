function wynik = abc(x,n)
  for i = 1:n
    y = x * i;
    wynikMod = mod(y,n);
    if(wynikMod == 1)
      wynik = i;
      return;
    endif
  endfor
  disp("Brak elementu odwrotnego");
endfunction