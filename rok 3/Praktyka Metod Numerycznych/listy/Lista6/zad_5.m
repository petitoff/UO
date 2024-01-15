opts = optimset('Jacobian','on')
[x,fx,info,out,dfx]=fsolve('ufun',-1,opts)
