function S = fun2(x, X, Y, z, h)
  S = zeros(1, length(x));
  i=ones(1,length(x));
  j=2;
  n=length(X);
  while(j<=n-1)
    i+=x>X(j);
    j++;
  endwhile

  for(j=1:length(x))
    S(j) = (z(i(j))/(6*h(i(j)))) * (X(i(j)+1) - x(j))^3 + (z(i(j)+1)/(6*h(i(j)))) * (x(j) - X(i(j)))^3 + (Y(i(j)+1)/h(i(j)) - (z(i(j)+1)*h(i(j)))/6) * (x(j) - X(i(j))) + (Y(i(j))/h(i(j)) - (z(i(j))*h(i(j)))/6) * (X(i(j)+1) - x(j));
  endfor
endfunction
