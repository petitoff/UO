f = @(x) x.^2 + 7.*x + 11;

[x, info, nf, env] = quad(f, 4, 7)
disp(x)

