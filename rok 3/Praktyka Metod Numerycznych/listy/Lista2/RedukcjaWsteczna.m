function retval = RedukcjaWsteczna(A, b)
  n = length(b);
  x = zeros(n, 1);
  A;

  x(n) = b(n) / A(n, n);

  for i = n-1:-1:1
    sum = 0;
    for j = i+1:n
      sum = sum + A(i, j) * x(j);
    end

    x(i) = (b(i) - sum) / A(i, i);
  end

  retval = x;
end








##function x = RedukcjaWsteczna (A, b)
##  n = length(A);
##  temp = 0;
##
##  for i=n:-1:1
##    b(i,1) = b(i,1)/A(i,i);
##    A(i,i) = A(i,i)/A(i,i);
##    for j = 1:i-1
##      temp=A(j,i)/A(i,i)
##      b(j,1) = b(j,1)-(b(i,1)*temp);
##      A(j,i) = A(j,i) - A(j,i);
##    endfor
##  endfor
##  x = b;
##end
