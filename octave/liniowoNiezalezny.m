function wynik=liniowoNiezalezny(m1)
  [a,b]=size(m1);
  if(a==2&&b==2)
     if((m1(1,1)*m1(2,2))==(m1(1,2)*m1(2,1)))
        printf("Liniowo Zalezny");
     endif
  endif
  printf("Liniowo Niezalezny");
endfunction