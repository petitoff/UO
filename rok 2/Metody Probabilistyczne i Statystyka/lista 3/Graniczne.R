library(stats)

mean1 <- 3.375

# Obliczamy wartość kwantyla dla prawdopodobieństwa 0.9
quantile <- qnorm(0.9)

# Obliczamy odchylenie standardowe dla rzutu kostką
sd <- sqrt((1/6) * (0^2 + 2^2 + 2^2 + 4^2 + 4^2 + 6^2) - mean1^2)

# Obliczamy liczbę prób potrzebną do osiągnięcia poziomu ufności 0.9
# i precyzji 0.1

n <- (quantile * sd / 0.1)^2

print(paste("Wynik:", n))


# Sprawozdanie

# Powyższy kod jest programem napisanym w języku R, który służy do oszacowania 
# liczby prób potrzebnych do osiągnięcia poziomu ufności co najmniej 0,9
# i precyzji co najmniej 0,1 w doświadczeniu polegającym na rzucie dwiema monetami 
# i użyciu kostki do gry.

# Program rozpoczyna się od załadowania pakietu stats, który zawiera 
# funkcję qnorm, która jest używana do obliczenia kwantyla dla danej 
# wartości prawdopodobieństwa z rozkładu normalnego. 
# Następnie ustawiana jest wartość oczekiwana, która wynosi 3.375, 
# a następnie obliczany jest kwantyl dla prawdopodobieństwa 0,9.

# Następnie obliczane jest odchylenie standardowe dla rzutu kostką, a 
# następnie liczba prób potrzebna do osiągnięcia poziomu ufności 0,9
# i precyzji 0,1 jest obliczana za pomocą odpowiedniej formuły.
# Na końcu program wyświetla wynik, czyli liczbę prób potrzebną
# do osiągnięcia poziomu ufności 0,9 i precyzji 0,1.