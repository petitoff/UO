N=9;
d=zeros(N,1)
b=[zeros(N-2,1);0.5;0.5];
A=zeros(N,N-1)+(1/9);
A=[A,b]

[x,l]=eigs(A,1)

x

c=1/sum(x)
x=x*c
sum(x)
