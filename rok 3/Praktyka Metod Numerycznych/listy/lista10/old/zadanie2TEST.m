% Twoje punkty danych
X = [1, 2, 3, 5, 8];
Y = [13, 23, 46, 152, 551];

% Przygotowanie macierzy A i wektora b
n = length(X);
A = zeros(4*(n-1), 4*(n-1));
b = zeros(4*(n-1), 1);

% Wypełnienie macierzy A i wektora b
for i = 1:(n-1)
    xi = X(i);
    xi1 = X(i+1);

    % Równania interpolujące punkty
    A(2*i-1, 4*i-3:4*i) = [xi^3, xi^2, xi, 1];
    b(2*i-1) = Y(i);
    A(2*i, 4*i-3:4*i) = [xi1^3, xi1^2, xi1, 1];
    b(2*i) = Y(i+1);

    % Warunki ciągłości pierwszej pochodnej
    if i < n-1
        A(2*n-1+i, 4*i-3:4*i+4) = [3*xi1^2, 2*xi1, 1, 0, -3*xi1^2, -2*xi1, -1, 0];
    end

    % Warunki ciągłości drugiej pochodnej
    if i < n-1
        A(3*n-3+i, 4*i-3:4*i+4) = [6*xi1, 2, 0, 0, -6*xi1, -2, 0, 0];
    end
end

% Warunki brzegowe (pierwsza pochodna równa 0 na krańcach)
A(end-1, 1:4) = [3*X(1)^2, 2*X(1), 1, 0];
A(end, end-3:end) = [3*X(end)^2, 2*X(end), 1, 0];
b(end-1:end) = [0; 0];

% Rozwiązanie układu równań
coeff = A\b;

% Funkcja do obliczania wartości splajnu
function y = evalSpline(coeffs, x, X)
    % Znajdź odpowiedni segment
    segment = find(x >= X(1:end-1) & x < X(2:end), 1, 'last');
    if isempty(segment)
        segment = length(X) - 1; % Jeśli x jest ostatnim punktem
    end
    % Wyciągnięcie współczynników dla tego segmentu
    c = coeffs(4*segment-3:4*segment);
    % Obliczenie wartości splajnu
    y = polyval(c, x - X(segment));
end

% Rysowanie splajnu
xx = linspace(X(1), X(end), 1000);
yy = arrayfun(@(x) evalSpline(coeff, x, X), xx);

plot(X, Y, 'o', xx, yy, '-');

