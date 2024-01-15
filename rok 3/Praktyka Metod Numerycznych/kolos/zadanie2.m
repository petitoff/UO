B = [1, -0.1; 0.1, 1.1];

x = [1; 1];
tol = 1e-6;
max_iter = 1000;

% Metoda potegowa
for i = 1:max_iter
    y = B * x;
    lambda = norm(y);
    x = y / lambda;
    if norm(B * x - lambda * x) < tol
        break;
    end
end

% Odwrotna metoda potegowa
for i = 1:max_iter
    y = inv(B) * x;
    lambda_inv = norm(y);
    x = y / lambda_inv;
    if norm(inv(B) * x - lambda_inv * x) < tol
        break;
    end
end

% Obliczenie promienia spektralnego
spectral_radius = abs(lambda);

fprintf("Wartosci wlasne: %f, %f\n", lambda, lambda_inv);
fprintf("Wektory wlasne:\n");
disp(x);
disp(y);
fprintf("Promien spektralny: %f\n", spectral_radius);
