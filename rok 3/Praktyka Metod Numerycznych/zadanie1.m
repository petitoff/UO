N=500;
e=ones(N,1);
D=spdiags([-e,2*e,-e],[-1,0,1],N,N);

#x=rand(n1,n2)
#b=D*x

x=rand(N,1);
b=D*x;

tic
x1 = D \ b;
toc

tic
x2 = inv(D) * b;
toc

tic
x3 = EliminacjaGaussa2(D, b);
toc

tic
[x4, info, relves, iter, resvec] = pcg(D, b, 1e-10, N);
toc

max(abs(x - x1))
max(abs(x - x2))
max(abs(x - x3))
max(abs(x - x4))

semilogy(abs(resvec))
