1% N - gałęzi
% a_ij - zapotrzebowanie na i-ty produkt do wytworzenia j-tego
% A = {a_ij}

% d = [d1;d2;...;dn]

% (I-A) x = d

% tworzenie macierzy z samych jdynek : A = ones(a,b)

B = ones(8,9) * 0.1;

C = [0.01, zeros(1,7), 0.1];

A = [B; C];

D = ones(9,1);

% macierz jednostkowa
E = eye(9);

% x = (I-A)^-1*d
wynik = inv(E - A) * D

% zamiast tego możemy użyc tego: (I-A) \ d
wynik2 = (E-A) \ D

wynik - wynik2
