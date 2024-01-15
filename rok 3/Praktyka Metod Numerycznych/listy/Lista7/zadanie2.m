epsilon = 0.1;
M = 0.5;
tol = 1e-6;

[x, info] = kepler(epsilon, M, tol);

fprintf('Rozwiązanie: x = %f\n', x);
fprintf('Informacja: %s\n', info);

