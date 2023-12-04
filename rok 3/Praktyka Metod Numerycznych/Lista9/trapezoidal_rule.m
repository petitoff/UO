function I = trapezoidal_rule(f, a, b, n)
    h = (b - a) / n;
    x = a : h : b;
    y = f(x);
    I = (h/2) * (y(1) + 2*sum(y(2:end-1)) + y(end));
end

