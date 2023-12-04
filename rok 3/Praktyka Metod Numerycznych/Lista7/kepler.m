function [x, info] = kepler(epsilon, M, tol)
    % Funkcja rozwiązująca równanie x - epsilon*sin(x) = M
    % przy użyciu metody Newtona.

    % Inicjalizacja
    x = M;
    max_iter = 1000;
    iter = 0;

    % Pętla iteracyjna
    while true
        f = x - epsilon*sin(x) - M;  % Wartość funkcji
        df = 1 - epsilon*cos(x);     % Pochodna funkcji

        x = x - f/df;  % Metoda Newtona

        % Sprawdzenie warunku stopu
        if abs(f) < tol || iter >= max_iter
            break;
        end

        iter = iter + 1;
    end

    % Ustawienie flagi informacyjnej
    if abs(f) < tol
        info = 'Sukces';
    else
        info = 'Brak zbieżności';
    end
end
