function LY = LLagrange(x, X, Y)
    n = length(X);
    LY = zeros(size(x));
    for k = 1:length(x)
        for i = 1:n
            p = 1;
            for j = 1:n
                if i ~= j
                    p = p * (x(k) - X(j))/(X(i) - X(j));
                end
            end
            LY(k) = LY(k) + Y(i) * p;
        end
    end
end
