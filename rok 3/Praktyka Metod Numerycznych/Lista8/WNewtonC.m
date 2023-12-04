% Funkcja obliczająca współczynniki dla metody Newtona
function C = WNewtonC(X, Y)
    n = length(X);
    C = Y;
    for j = 2:n
        for i = n:-1:j
            C(i) = (C(i) - C(i-1)) / (X(i) - X(i-j+1));
        end
    end
end
