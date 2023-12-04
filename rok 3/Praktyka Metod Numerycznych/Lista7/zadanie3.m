R=8.3145;
P=1.0133*10^5;
T=303;
N=0.22722;
a=0.364*10^-12;
b=42.67*10^-6;

%fun = @(V) (P + (N^2 * a) / V^2) * (V - N * b) - N * R * T;
%fun = @(V) (P.* (V.^2) + (N.^2 .* a))  .* (V - N .* b) - (N .* R .* T).*(V.^2);
fun = @(V) (-P*V^3 + N*R*T*V^2 + b*N*P*V^2 - a*N^2*V -a*b*N^3);

c=[-P,(N*R*T)+(P*N*b),-a*(N^2),-a*b*(N^3)]
pier = roots(c)

NRPT = fsolve(fun,((N.*R.*T)./P));
NRPT
printf("\n\n")

[wynik,fx,info,out] = fzero(fun,pier(1));

wynik
blad=out.bracketx(2)-out.bracketx(1)
printf("\n\n")

[wynik,fx,info,out] = fzero(fun,pier(2));

wynik
blad=out.bracketx(2)-out.bracketx(1)
printf("\n\n")

[wynik,fx,info,out] = fzero(fun,pier(3));

wynik
blad=out.bracketx(2)-out.bracketx(1)
printf("\n\n")
