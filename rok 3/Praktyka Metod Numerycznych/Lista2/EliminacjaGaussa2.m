function retval = EliminacjaGaussa2 (A, b)
  n=columns(A);

  for(i=1:(n-1))
    A(i,:);
    for(j=(i+1):n)
      z=A(j,i)/A(i,i);
      A(j,i)=0;
##      for(k=(i+1):n)
        A(j,(i+1):n)=A(j,(i+1):n)-z*A(i,(i+1):n);
##      endfor


      b(j)=b(j)-z*b(i);
    endfor
  endfor
  retval=RedukcjaWsteczna(A,b);

endfunction
