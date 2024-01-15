%Zadanie 3
%Funkcja sklejana st. 3

x = [1, 2, 3, 5, 8];
y = [13, 23, 46, 152, 551];

plot(x, y, "or");
hold on;

t1 = flip([0:3]);
t2 = t1(2:4);
t3 = t1(1:3);


d = [13; 23; 23; 46; 46; 152; 152; 551; zeros(8, 1)];

A = [ones(1, 4), zeros(1, 12);
2.^t1, zeros(1, 12);
zeros(1, 4), 2.^t1, zeros(1, 8);
zeros(1, 4), 3.^t1, zeros(1, 8);
zeros(1, 8), 3.^t1, zeros(1, 4);
zeros(1, 8), 5.^t1, zeros(1, 4);
zeros(1, 12), 5.^t1;
zeros(1, 12), 8.^t1;

2.^t2.*t3, 0, -2.^t2.*t3, zeros(1, 9);
zeros(1, 4), 3.^t2.*t3, 0, -3.^t2.*t3, zeros(1, 5);
zeros(1, 8), 5.^t2.*t3, 0, -5.^t2.*t3, 0;

6*2, 2, 0, 0, -6*2, -2, zeros(1, 10);
zeros(1, 4), 6*3, 2, 0, 0, -6*3, -2, zeros(1, 6);
zeros(1, 8), 6*5, 2, 0, 0, -6*5, -2, 0, 0;

%1.^t2.*t3, zeros(1, 13);
%zeros(1, 12), 8.^t2.*t3, 0;
6, 2, zeros(1, 14); %druga pochodna w 1 = 0
zeros(1, 12), 8*6, 2, 0, 0; % druga pochodna w 8 = 0
];


W = A\d;


function retval = sklejana1(x, X, w)
  retval = zeros(1, length(x));
  i=zeros(1,length(x));
  j=2;
  n=length(X);
  while(j<=n-1)
    i+=x>X(j);
    j++;
  endwhile

  t = x'.^flip([0:3]);
  for(j=1:length(x))
    retval(j)=sum(w(1+i(j)*4:4+i(j)*4)'.*t(j,1:4));
  endfor
end


xp=linspace(0,10,10000);
plot(xp, sklejana1(xp, x, W), 'r');
hold on;


%Czêœc 2


h=x(2:5)-x(1:4)
u=2.*(h(1:3)+h(2:4))
b=(6./(h(1:4))).*(y(2:5)-y(1:4))
v=b(2:4)-b(1:3)


A2 = [u(1), h(2), 0;
h(2), u(2), h(3);
0, h(3), u(3)
]

% Z = pochodne w punktach x
Z = [0; A2\v'; 0]

% TODO: zaimplementowac ostatni wzor ze strony 329 (346) z https://www.impan.pl/~szczep/AMM1/Kincaid.pdf na Si(x)

function retval = Si(x, X, Y, z, h)
  retval = zeros(1, length(x));
  i=ones(1,length(x));
  j=2;
  n=length(X);
  while(j<=n-1)
    i+=x>X(j);
    j++;
  endwhile

  for(j=1:length(x))
    retval(j) = (z(i(j))/(6*h(i(j)))) * (X(i(j)+1) - x(j))^3 + (z(i(j)+1)/(6*h(i(j)))) * (x(j) - X(i(j)))^3 + (Y(i(j)+1)/h(i(j)) - (z(i(j)+1)*h(i(j)))/6) * (x(j) - X(i(j))) + (Y(i(j))/h(i(j)) - (z(i(j))*h(i(j)))/6) * (X(i(j)+1) - x(j));
  endfor
end


plot(xp, Si(xp, x, y, Z, h), 'g');
hold off;






