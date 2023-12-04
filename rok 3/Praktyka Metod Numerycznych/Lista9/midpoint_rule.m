function I = midpoint_rule(f, a, b, n)
    h = (b - a) / n;
    x = a + h/2 : h : b - h/2;
    I = sum(f(x)) * h;
end
