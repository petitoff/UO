% Pierwiastek wielomianu w1
function root = zadanie5()
    % Przykładowy wielomian
    w1 = @(x) x^2 - 2;
    w1_prime = @(x) 2*x;
    x0 = 1; % Przybliżenie początkowe
    tol = 1e-3; % Tolerancja błędu

    root = x0;
    while abs(w1(root)) > tol
        root = root - w1(root) / w1_prime(root);
    end
end

% Rozwiązanie równania nieliniowego
function root = zadanie5()
    % Przykładowe równanie nieliniowe
    f = @(x) log(x + 100) + sin(x) + x;
    f_prime = @(x) 1/(x + 100) + cos(x) + 1;
    x0 = -99; % Przybliżenie początkowe
    tol = 1e-2; % Tolerancja błędu

    root = x0;
    while abs(f(root)) > tol
        root = root - f(root) / f_prime(root);
    end
end

% Wywołanie funkcji
root_wielomian = zadanie5()
root_równanie = zadanie5()

