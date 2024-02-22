MacierzA = [15, -4, 3, 2; -1, 15, -1, -1; 2, -2, 15, -2; -2, 2, -1, 15];
WektorB = [12; 12; 13; 14];

function rozwiazanie = Jakobi(Macierz, Wektor, przyblizenie, IteracjeMax)
    Diag = diag(Macierz);
    Wektor = Wektor ./ Diag;
    rozmiar = length(Wektor);

    for indeks = 1:rozmiar
        Macierz(indeks, :) = Macierz(indeks, :) / Diag(indeks);
    endfor

    for iteracja = 1:IteracjeMax
        nowe_przyblizenie = Wektor;
        for i = 1:rozmiar
            for j = 1:(i - 1)
                nowe_przyblizenie(i) = nowe_przyblizenie(i) - Macierz(i, j) * przyblizenie(j);
            endfor
            for j = (i + 1):rozmiar
                nowe_przyblizenie(i) = nowe_przyblizenie(i) - Macierz(i, j) * przyblizenie(j);
            endfor
        endfor
        przyblizenie = nowe_przyblizenie;
    endfor
    rozwiazanie = przyblizenie;
endfunction

przyblizenie_poczatkowe = zeros(length(WektorB), 1);

MaxIteracje = 1000;

% Sprawdzenie warunku zbieżności metody Jacobiego
czy_zbiezna = all(2 * abs(diag(MacierzA)) > sum(abs(MacierzA), 2));

% Wywołanie metody Jacobiego i wyświetlenie wyników
rozwiazanie_jakobi = Jakobi(MacierzA, WektorB, przyblizenie_poczatkowe, MaxIteracje);

if czy_zbiezna
disp('Metoda Jacobiego jest zbieżna dla podanego układu równań.');
else
disp('Nie można zagwarantować zbieżności metody Jacobiego dla podanego układu równań.');
end

disp('Rozwiązanie układu równań metodą Jacobiego:');
disp(rozwiazanie_jakobi);

