% Definicja funkcji z prawej strony równania różniczkowego y'(x) = 4x
f = @(x, y) 4 * x;

% Funkcja obliczająca dokładne rozwiązanie
fun = @(x) 2 * x.^2 + 2;

% Definicja metody Rungego-Kutty
runge_kutta = @(x, y, h) y + h/2 * (f(x, y) + f(x + h, y + h * f(x, y)));

% Liczba punktów do obliczeń
N = 1000;
h = 3 / (N - 1);
x = linspace(-2, 1, N);
y_rk = zeros(1, N);
y_rk(1) = 10;  % Warunek początkowy y(-2) = 10

% Obliczenia metodą Rungego-Kutty
for j = 2:N
    y_rk(j) = runge_kutta(x(j-1), y_rk(j-1), h);
end

% Błąd bezwzględny w punkcie x = 1
rk_error = abs(fun(1) - y_rk(end));

% Wyświetlenie wykresu
figure;
plot(x, fun(x), 'k', x, y_rk, 'b');
legend('Dokładne', 'Runge-Kutta');
title('Rozwiązanie metodą Rungego-Kutty');

% Wyświetlenie błędu bezwzględnego
fprintf('Błąd bezwzględny w punkcie x = 1 wynosi: %f\n', rk_error);

