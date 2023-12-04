function I = composite_midpoint_trapezoidal_rule(f, a, b, n)
    h = (b - a) / n;
    x_mid = a + h/2 : h : b - h/2;
    x_trap = a : h : b;

    I_mid = sum(f(x_mid(1:2:end))) * h;
    y_trap = f(x_trap(2:2:end));
    I_trap = (h/2) * (y_trap(1) + 2*sum(y_trap(2:end-1)) + y_trap(end));

    I = I_mid + I_trap;
end

