function W = zadanie4()
    function W = horner(wsp, x)
        n = length(wsp) - 1;
        W = wsp(1);
        for i = 2:n+1
            W = W * x + wsp(i);
        end
    end

    wspolczynniki = [2, 3, 4, 2, 1, 0];
    x = 2;

    W = horner(wspolczynniki, x);

    fprintf('Wartość wielomianu w1(x) w punkcie x = %d wynosi: %d\n', x, W);
end
