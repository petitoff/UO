N=9;
d=zeros(N,1)
b=[zeros(N-2,1);0.5;0.5];
A=zeros(N,N-1)+(1/9);
A=[A,b]

x=ones(N,1)
M=10

for(i=1:M)
  y=A\x;
  x=y/norm(y);
endfor

x=x/sum(x)
