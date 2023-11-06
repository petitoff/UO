A = [420,210,140,105;210,140,105,84;140,105,84,70;105,84,70,60];
b = [875;539;399;319];

B = inv(A);
I=eye(4);

temp=1000;

B=B*temp;
B=round(B);
B=B/temp;

norm(I-A*B)

while(norm(I-A*B)>1)
  temp = temp * 10
  B=inv(A)
  B=B*temp
  B=round(B)
  B=B/temp
end

suma = I;
temp = I;

for i=1:20
  temp*=(I-A*B);
  suma+=temp;
endfor

x=B*suma*b

