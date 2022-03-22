function wynik = macierz(m1,m2)
  # sprawdzamy wielkosc (wiersze i kolumny)
  wielkosc = size(m2)
  wiersze = wielkosc(1);
  kolumny = wielkosc(2);
  
  vector = []
  vector2 = [];
  for(i=1:kolumny)
  
    vector2 = [vector2,m1(1,i)];
  endfor
  znalezionaKolumna = false;
  for i = 1:kolumny
    szukanaLiczba = m2(2,i);
    
    for j = 1:kolumny
      aktualnaSprawdzanaLiczba = m1(1,j);
      if (aktualnaSprawdzanaLiczba == szukanaLiczba)
        znalezionaKolumna = j;
        disp(znalezionaKolumna);
        break;
      endif
    endfor
    
    for j = 1:kolumny
      if(j==znalezionaKolumna)
        vector = [vector,m1(2, j)];
      endif
    endfor
  endfor
  vector2 = [vector2;vector]
  wynik = vector2;
endfunction