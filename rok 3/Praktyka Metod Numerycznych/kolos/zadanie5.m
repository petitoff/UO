% Przykładowy wielomian, dla którego chcemy znaleźć pierwiastek.
% Wielomian w1 jest nieznany, więc załóżmy, że jest to wielomian x^2 - 2
w1 = @(x) x^2 - 2;

% Znalezienie przybliżonego pierwiastka wielomianu w1
% z dokładnością do 10^-3
x_w1_approx = fzero(w1, 1); % Startujemy z punktu 1
w1_error = abs(w1(x_w1_approx));

if w1_error < 1e-3
    fprintf('Znaleziono przybliżenie pierwiastka wielomianu w1: %f\n', x_w1_approx);
else
    fprintf('Nie znaleziono przybliżenia pierwiastka wielomianu w1 spełniającego wymagane kryterium dokładności.\n');
end

% Funkcja nieliniowa dla której szukamy rozwiązania x
f = @(x) log(x) + exp(x) + x;

% Metoda Newtona wymaga pochodnej funkcji f
% Pochodna funkcji f: f'(x) = 1/x + exp(x) + 1
df = @(x) 1/x + exp(x) + 1;

% Znalezienie przybliżonego rozwiązania równania nieliniowego
% z dokładnością do 10^-2
% Założymy początkowe przybliżenie x0 = 0.5 (nie możemy użyć x = 0 ze względu na log(x))
x0 = 0.5;
x_approx = x0;
for i = 1:100
    x_next = x_approx - f(x_approx)/df(x_approx);
if abs(x_next - x_approx) < 1e-2
    fprintf('Znaleziono przybliżenie rozwiązania x: %f\n', x_next);
break;
end
    x_approx = x_next;
end

if i == 100
    fprintf('Nie znaleziono przybliżenia spełniającego kryterium dokładności w 100 iteracjach.\n');
end

