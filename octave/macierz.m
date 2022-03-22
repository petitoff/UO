function wynik = macierz(m1,m2)
  # sprawdzamy wielkosc (wiersze i kolumny)
  wielkosc = size(m2)
  wiersze = wielkosc(1);
  kolumny = wielkosc(2);
  
  # tworze dwa macierze aby po?niej skleic je w ca?osc
  vector = []
  vector2 = [];
  
  for(i=1:kolumny)
    # dokonuje wypisania pierwszego wiersza do rezulatatu
    vector2 = [vector2,m2(1,i)];
  endfor
  
  znalezionaKolumna = false; # deklaracja zmiennej globalnej dla p?tli for
  for i = 1:kolumny
    szukanaLiczba = m2(2,i); # aktualna szukana liczba
    
    for j = 1:kolumny
      # petla wyszukuje szukanej liczby w macierzy m1 (pierwszej)
      aktualnaSprawdzanaLiczba = m1(1,j);
      if (aktualnaSprawdzanaLiczba == szukanaLiczba)
        znalezionaKolumna = j;
        break;
      endif
    endfor
    
    for j = 1:kolumny
      if(j==znalezionaKolumna)
        # tworzenie drugiego macierza (z wyszukanych wartosci)
        vector = [vector,m1(2, j)];
      endif
    endfor
    
  endfor
  # "sklejanie" macierzy
  wynik = [vector2;vector];
endfunction