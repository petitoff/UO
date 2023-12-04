#Zadanie 1 Narysowac wykres wielomianu interpolacyjnego
#X=[1,2,5,3,8] 1 Newton
#Y=[12,23,152,46,551] 2 Lagrange
#pk(x)= Sigma k i=0 Ci i-1/||j=0 (x-xj)
#(x-x0) (x-x0)(x-x1)    (x-x0)(x-x1)(x-x2)
#Ci obliczamy za pomocą ilorazów różniczkowych
#hold on dodaje wykres na juz istniejacy az damy hold off
% Dane wejściowe
% Dane wejściowe
X = [1; 2; 5; 3; 8];
Y = [12; 23; 152; 46; 551];

% Wykres punktów
figure;
plot(X, Y, 'or');
hold on;

% Obliczenia ilorazów różnicowych dla współczynników Newtona
C = WNewtonC(X, Y);

% Punkty do wygenerowania wykresu
x = linspace(min(X), max(X), 100);

% Wykresy wielomianów interpolacyjnych
plot(x, WNewton(x, X, C, 1), '-r');
plot(x, WNewton(x, X, C, 2), '-g');
plot(x, WNewton(x, X, C, 3), '-b');
plot(x, WNewton(x, X, C, 4), '-m');
plot(x, WNewton(x, X, C, 5), '-k');
plot(x, LLagrange(x, X, Y, 1));

xlabel('x');
ylabel('y');
title('Interpolacja z wykorzystaniem Newtona oraz Lagrange');
grid on;
hold off;

