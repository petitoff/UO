# Wykonujemy rzut dwoma monetami
coin1 <- sample(c(0, 1), 1)
coin2 <- sample(c(0, 1), 1)

# Sprawdzamy, czy uzyskaliśmy dwie reszki
if (coin1 == 1 && coin2 == 1) {
  # Jeśli tak, to wykonujemy rzut wadliwą kostką
  roll <- sample(c(0, 2, 2, 4, 4, 6), 1)
} else {
  # W przeciwnym razie wykonujemy rzut zwykłą sześcienną kostką
  roll <- sample(1:6, 1)
}

# Obliczamy wartość oczekiwaną
expected_value <- mean(roll)

# Oszacowujemy, ile razy trzeba powtórzyć doświadczenie, aby prawdopodobieństwo
# różnicy między wartością oczekiwaną a rzeczywistą liczbą oczek była nie mniejsza niż 0,9
n <- 1
while (pnorm(abs(expected_value - mean(roll)), lower.tail = FALSE) < 0.9) {
  n <- n + 1
  roll <- c(roll, sample(1:6, 1))
}
