function wynik=rzedyDwieKolumny(m1)
  [a,b]=size(m1);
    if(b != 2)
    wynik = "Podałeś nieprawidołową macierz!";
    return;
  endif

  spr1=0;
  spr2=0;


  for i=1:a-1
    if((m1(i,1)*m1(i+1,2))-(m1(i+1,1)*m1(i,2))!=0)
      spr2=1;
    endif
    if(spr2==0)
      for i=1:a
        if(m1(i,1)!=0)
          spr1=1;
        endif
        if(m1(i,2)!=0)
          spr1=1;
        endif
      endfor
    endif
  endfor
  if(spr2==1)
    wynik=2;
  else
    if(spr1==1)
      wynik=1;
    else
      wynik=0;
    endif
  endif
endfunction
