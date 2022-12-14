# Liczba rzutów dwoma monetami
n = 100

# Liczba uzyskanych orłów w rzucie dwoma monetami
eagles = rbinom(n, 2, 0.5)

# Liczba oczek na kostce do gry
dice = numeric()

# Dla każdego rzutu dwoma monetami
for (i in 1:n) {
  # Jeżeli uzyskano 2 orły, to wykonaj rzut wadliwą kostką do gry
  if (eagles[i] == 2) {
    dice[i] = sample(c(0,2,2,4,4,6), size = 1)
  }
  # W przeciwnym razie wykonaj rzut zwykłą sześcienną kostką do gry
  else {
    dice[i] = sample(1:6, size = 1)
  }
}

# Wyświetl średnią liczbę oczek uzyskanych na kostce do gry
mean(dice)

power.prop.test(p1 = 3.375, p2 = 0.1, sig.level = 0.9, power = 0.9, alternative = "two.sided")
