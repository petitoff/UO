function WY = WNewton(x, X, C, n)
    WY = zeros(size(x));
    for k = 1:length(x)
        temp = C(n);
        for j = n-1:-1:1
            temp = temp * (x(k) - X(j)) + C(j);
        end
        WY(k) = temp;
    end
end
