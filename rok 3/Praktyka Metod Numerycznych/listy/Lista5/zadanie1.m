A = ones(9, 9) * 1/9;

A(1:7, end) = 0;
A(8:end, end) = 1/2;

A;

[V, L] = eig(A);
L;

x = V(:,1);

##A * x - x

c = 1/sum(x);
x * c
