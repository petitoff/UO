function result = mps(f, a, b, n)
    if n <= 0
        error('Number of subintervals (n) must be greater than 0');
    end

    result = 0;
    h = (b - a) / n;
    x_mid = a + 0.5 * h; % Początkowa wartość x_mid

    for i = 1 : n
        result = result + f(x_mid);

        x_mid += h;
    end

    result *= h;
end

