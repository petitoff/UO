function y = funcg(x)
  z=(x-1).^2;
  z=z.*((x+1).^3);
  z=z+(1./(x.^4+0.1));
  z=z-0.731;
  y=z;
endfunction
