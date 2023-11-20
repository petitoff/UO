function [y,Dx] = ufun(x)
  y=funcg(x);
  Dx=funcpoch(x);
endfunction
