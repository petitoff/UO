X=[1,2,3,5,8];
Y=[13,23,46,152,551];
A=zeros(16,16);
b=[13;23;23;46;46;152;152;551;0;0;0;0;0;0;0;0];

k=0;
l=1;
for i=1:8
  A(i,(1:4)+k)+=X(l).^(3:-1:0);
  if(mod(i,2)==0)
    k+=4;
  endif
  if(mod(i,2)==1)
    l+=1;
  endif
endfor
l=2;
k=0;
for i=9:11
  A(i,(1:3)+k)=(X(l).^(2:-1:0)).*(3:-1:1);
  A(i,(1:3)+k+4)=-(X(l).^(2:-1:0)).*(3:-1:1);
  l+=1;
  k+=4;
endfor
l=2;
k=0;
for i=12:14
  A(i,(1:2)+k)=(X(l).^(1:-1:0)).*(3:-1:2).*(2:-1:1);
  A(i,(1:2)+k+4)=-(X(l).^(1:-1:0)).*(3:-1:2).*(2:-1:1);
  l+=1;
  k+=4;
endfor
A(15,1:3)=(X(1).^(2:-1:0)).*(3:-1:1);
A(16,13:15)=(X(5).^(2:-1:0)).*(3:-1:1);

A
b
x=A\b

z=linspace(X(1),X(2),1000);
plot(z,fun(x(1:4),z))

hold on

z=linspace(X(2),X(3),1000);
plot(z,fun(x(5:8),z))

z=linspace(X(3),X(4),1000);
plot(z,fun(x(9:12),z))

z=linspace(X(4),X(5),1000);
plot(z,fun(x(13:16),z))

hold off