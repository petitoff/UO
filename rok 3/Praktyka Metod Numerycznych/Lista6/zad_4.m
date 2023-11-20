opts=fsolve('defaults')
printf("*\n*\n*\n")
#Jeśli ||F(x)||2 <= Tol Fun to koniec info=1
#Jeśli ||Xn-Xn-1||2/||Xn||2 <= Tol x to koniec info=2
#Jeśli MaxIter osiągnięte to info=0
opts=optimset('MaxIter',100,'TolFun',1e-16)
printf("*\n*\n*\n")
[x,fx,info,out,dfx]=fsolve('funcg',0.1,opts)
printf("*\n*\n*\n")
[x,fx,info,out,dfx]=fsolve('funcg',0.11,opts)
printf("*\n*\n*\n")
