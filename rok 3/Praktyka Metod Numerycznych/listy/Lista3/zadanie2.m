N = 5000
A = sprand(N, N, 10/N)
B = A' * A + speye(N);

x=rand(N,1);
f = B * x;

tic
x1 = B \ f;
toc

tic
x2 = pcg(B, f, 1e-8, N/10);
toc
