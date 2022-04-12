function wynik = mnozenieDwochMacierzy(m1,m2)
  [a,b]=size(m1);
  [c,d]=size(m2);

  if(b != c)
   wynik = "Niepoprawny wymiar macierzy";
   return
  endif

  wynik = m1;
  wynik = wynik * 0;

  for n=1:a
    for i=1:d
      for j=1:c

      wynik(n,i) += m1(n,j) * m2(j,i);
      disp(wynik);

      endfor
    endfor
  endfor

endfunction
