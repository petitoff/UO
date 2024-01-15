% zagadnienie najmniejszych kwadratów

D = zeros(9,1)
A = ones(9,9) * (1/ 9)

E = eye(9)

wynik = (E-A) \ D
