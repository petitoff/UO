function W = zadanie4()
    % Zdefiniowana funkcja Hornera
    function W = horner(wsp, x)
        n = length(wsp) - 1; % Stopień wielomianu
        W = wsp(1);
        for i = 2:n+1
            W = W * x + wsp(i);
        end
    end

    % Współczynniki wielomianu
    wspolczynniki = [3, 2, 1, 0, 2, 3];
    x = 2; % Wartość x dla której obliczamy wielomian

    % Obliczenie wartości wielomianu
    W = horner(wspolczynniki, x);

    % Wyświetlenie wyniku
    fprintf('Wartość wielomianu w1(x) w punkcie x = %d wynosi: %d\n', x, W);
end

