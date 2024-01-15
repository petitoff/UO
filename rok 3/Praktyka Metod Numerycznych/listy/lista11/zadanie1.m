x=2
h=[1,0.5,0.25,0.125]
fun=@(x) ((4)*(x^3)+(2)*x+1);

for i=1:length(h)
  f=(fun(x+h(i))-fun(x))/h(i);
  b=(fun(x)-fun(x-h(i)))/h(i);
  c=(fun(x+(h(i)/2))-fun(x-(h(i)/2)))/h(i);

  printf("\ndla h=%f\n",h(i));
  printf("Iloraz różnicowy do przodu: %f\n",f);
  printf("Iloraz różnicowy do tyłu: %f\n",b);
  printf("Centralny iloraz różnicowy: %f\n",c);
endfor
