function wynik = abc(x,n)
  if(x<n)
    z = x;
    x = n;
    n = z;
  endif
  
  koniecn = 0;
  while koniecn != 1
    disp(x);
    disp(n);
    t = idivide(x, int32(n), "fix");
    koniecn = mod(x, (t*n));
    
    if koniecn == 0
      n = "Brak rozwiazania!";
      break;
    endif
    
    if koniecn == 1
      break;
    endif
    
    x = t;
    n = koniecn;
  endwhile
  wynik = n;
endfunction