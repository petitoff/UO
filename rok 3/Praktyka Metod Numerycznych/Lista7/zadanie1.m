fun = @(x) exp(-x) - x;

[wynik,fx,info,out]=fzero(fun,[0,1]);

wynik

blad=out.bracketx(2)-out.bracketx(1)
