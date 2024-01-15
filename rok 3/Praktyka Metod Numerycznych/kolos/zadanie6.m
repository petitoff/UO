% Definicja funkcji z prawej strony równania różniczkowego y'(x) = x^2 + y
f = @(x, y) x^2 + y;

% Funkcja obliczająca dokładne rozwiązanie
fun = @(x) -x.^2 - 2.*x + 6*exp(x+3) - 2;

% Definicja metody Rungego-Kutty
runge_kutta = @(x, y, h) y + h/2 * (f(x, y) + f(x + h, y + h * f(x, y)));

N = 1000;
h = 2 / (N - 1);
x = linspace(-3, -1, N);
y_rk = zeros(1, N);
y_rk(1) = 1;

for j = 2:N
    y_rk(j) = runge_kutta(x(j-1), y_rk(j-1), h);
end

rk_error = abs(fun(-1) - y_rk(end));

figure;
plot(x, fun(x), 'k', x, y_rk, 'b');
legend('Dokładne', 'Runge-Kutta');
title('Rozwiązanie równania różniczkowego y''(x) = x^2 + y metodą Rungego-Kutty');

fprintf('Błąd bezwzględny w punkcie x = -1 wynosi: %f\n', rk_error);

