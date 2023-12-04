[x,fx,info,out,dfx]=fsolve('funcg',-1)
printf("\n\n\n")
[x,fx,info,out,dfx]=fsolve('funcg',1)

x=linspace(1.1,1.12,1000);
plot(x,funcg(x))
