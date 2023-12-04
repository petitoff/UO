% Funkcja obliczająca wartości wielomianu Lagrange'a
function result = LLagrange(x, X, Y, k)
    n = length(X);
    result = zeros(size(x));
    for j = 1:n
        term = ones(size(x));
        for i = 1:n
            if i ~= j
                term = term .* (x - X(i)) / (X(j) - X(i));
            end
        end
        result = result + term * Y(j);
    end
end

