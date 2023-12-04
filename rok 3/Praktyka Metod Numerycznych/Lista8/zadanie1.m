X=[1;2;5;3;8];
Y= [12;23;152;46;551];

plot (X, Y, "or");
C=WNewtonC (X, Y) ;
WNewton (X, X, C, length (X) ) ;
x=linspace (min (X) , max (X) , 100) ;
plot (x, LLagrange (x, X, 1) )
hold on
plot (x, WNewton (x, X, C, 1) , "-r");
plot (x, WNewton (x, X, C, 2) , "-g");
plot (x, WNewton (x, X, C, 3) , "-b");
plot (x, WNewton (x, X, C, 4) , "-m");
plot (x, WNewton (x, X, C, 5) , "-k");
plot (x, LLagrange (x, X, 1) )
hold on

