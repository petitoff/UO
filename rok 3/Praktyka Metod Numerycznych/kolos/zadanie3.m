Macierz = [15, -4, 3, -2; -1, 15, -1, -1; 2, -2, 15, -2; -2, 2, -1, 15];
Wektor = [12; 12; 13; 14];

function x = iteracja_jacobiego(Macierz, Wektor, maks_iteracje, tolerancja)
    rozmiar = length(Wektor);
    x_stare = zeros(rozmiar, 1);
    x_nowe = zeros(rozmiar, 1);

    for iteracja = 1:maks_iteracje
        for indeks = 1:rozmiar
            suma = Macierz(indeks, :) * x_stare - Macierz(indeks, indeks) * x_stare(indeks);
            x_nowe(indeks) = (Wektor(indeks) - suma) / Macierz(indeks, indeks);
        end

        if norm(x_nowe - x_stare, inf) < tolerancja
            x_stare = x_nowe;
            break;
        end

        x_stare = x_nowe;
    end
    x = x_stare;
end

% Weryfikacja dominacji przekątniowej macierzy
czy_dominujaca = all(2 * abs(diag(Macierz)) >= sum(abs(Macierz), 2) - abs(diag(Macierz)));
if czy_dominujaca
    disp('Dominacja przekątniowa potwierdzona. Metoda Jacobiego ma duże szanse na zbieżność.');
else
    disp('Brak dominacji przekątniowej. Zbieżność metody Jacobiego niepewna.');
end

% Parametry dla iteracji Jacobiego
ilosc_iteracji = 1000;
dokladnosc = 1e-6;

% Obliczenia przy użyciu metody Jacobiego
wynik = iteracja_jacobiego(Macierz, Wektor, ilosc_iteracji, dokladnosc);
disp('Wynik obliczeń układu równań:');
disp(wynik);

