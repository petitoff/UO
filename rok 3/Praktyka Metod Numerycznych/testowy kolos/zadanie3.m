A=[1,-2,3,4;4,1,-2,3;3,4,1,-2;-2,3,4,1];
b=[6;6;6;6];

function retval = EliminacjaGaussa2 (A, b)
  n=columns(A);

  for(i=1:(n-1))
    A(i,:);
    for(j=(i+1):n)
      z=A(j,i)/A(i,i);
      A(j,i)=0;
      A(j,(i+1):n)=A(j,(i+1):n)-z*A(i,(i+1):n);
      b(j)=b(j)-z*b(i);
    endfor
  endfor
  retval=RedukcjaWsteczna(A,b);

endfunction

function x = RedukcjaWsteczna(A, b)
  n = length(A);

  for i=n:-1:1
    b(i,1) = b(i,1)/A(i,i);
    A(i,i)=A(i,i)/A(i,i);
    for j=1:i-1
      b(j,1)=b(j,1)-(b(i,1)*(A(j,i)/A(i,i)));
      A(j,i)=A(j,i)-A(j,i);
    endfor
  endfor
  x=b;
endfunction

x=EliminacjaGaussa2(A,b)

[L, U,P] = lu(A);
L
U

