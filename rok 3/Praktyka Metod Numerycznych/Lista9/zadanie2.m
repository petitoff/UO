N=7;
wynik = zeros(N,10);
wynik(8,N+1)=nan;
wynik(9,N+1)=nan;
wynik(10,N+1)=nan;
poprawny=quad("fun",4,7)

for i=0:N
  n=10*(2^i);
  wynik(1,i+1)=n;
  wynik(2,i+1)=mpr(@(x) fun(x),4,7,n);
  wynik(3,i+1)=mps(@(x) fun(x),4,7,n);
  wynik(4,i+1)=mtr(@(x) fun(x),4,7,n);
  wynik(5,i+1)=abs(wynik(2,i+1)-poprawny);
  wynik(6,i+1)=abs(wynik(3,i+1)-poprawny);
  wynik(7,i+1)=abs(wynik(4,i+1)-poprawny);
endfor

for i=0:N-1
  wynik(8,i+1)=log2(wynik(5,i+1)./wynik(5,i+2));
  wynik(9,i+1)=log2(wynik(6,i+1)./wynik(6,i+2));
  wynik(10,i+1)=log2(wynik(7,i+1)./wynik(7,i+2));
endfor

printf("n\tIm.pr\tIm.ps\tIm.tr\tem.pr\tem.sr\tem.tr\tλm.pr\tλm.sr\tλm.tr\n");
for i=0:N
  printf("%d\t%f\t%f\t%f\t%f\t%f\t%f\t%f\t%f\t%f\n",wynik(1,i+1),wynik(2,i+1),wynik(3,i+1),wynik(4,i+1),wynik(5,i+1),wynik(6,i+1),wynik(7,i+1),wynik(8,i+1),wynik(9,i+1),wynik(10,i+1));
endfor

