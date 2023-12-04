function result = WNewton(x, X, C, k)
    result = C(1);
    term = 1;
    for j = 2:k
        term = term .* (x - X(j-1));
        result = result + C(j) * term;
    end
end

