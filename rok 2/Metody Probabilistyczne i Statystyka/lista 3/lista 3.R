set.seed(123) #ustawiamy losowość

throws <- 0 # liczba rzutów
throws_results <- c() # wektor przechowujący wyniki rzutów

while (TRUE) {
  coin1 <- sample(c("Eagle", "Tail"), 1) #rzut monetą 1
  coin2 <- sample(c("Eagle", "Tail"), 1) #rzut monetą 2
  
  if (coin1 == "Eagle" & coin2 == "Eagle") {
    dice_roll <- sample(c(0, 2, 2, 4, 4, 6), 1) # rzut wadliwą kostką
  } else {
    dice_roll <- sample(1:6, 1) #rzut zwykłą kostką
  }
  
  throws <- throws + 1
  throws_results <- c(throws_results, dice_roll)
  
  mean_result <- mean(throws_results)
  
  if (abs(mean_result - 3.375) < 0.1) { # sprawdzenie czy odchylenie jest mniejsze niż 0.1
    if (throws > 30) {  # sprawdzenie czy liczba rzutów jest większa niż podano
      break
    }
  }
}

print(throws) # ilość potrzebnych rzutów



# Sprawozdanie
# Błażej Domagała
# Projekt nr 3 - Praktyczne wykorzystanie twierdzeń granicznych

# Ten kod realizuje symulację rzutu dwoma monetami. 
# W przypadku uzyskania dwóch orłów, symulowany jest rzut specjalną kostką 
# do gry (z odpowiednio 0, 2, 2, 4, 4 i 6 kropkami) natomiast w przypadku 
# uzyskania jednego orła lub braku orłów symulowany jest rzut zwykłą 
# sześcienną kostką do gry. Program oszacowuje ile razy trzeba powtórzyć 
# doświadczenie, aby średnia liczba oczek różniła się od
# wartości oczekiwanej 3.375 o mniej niż 0,1 z prawdopodobieństwem 
# nie mniejszym niż 0,9.

# Kod realizuje to przy użyciu pętli while, generując losowe liczby 
# z odpowiednich rozkładów dla każdego rodzaju rzutu. Każdy rzut jest 
# zliczany, a wyniki są przechowywane w wektorze. 
# Pętla while liczy rzuty do momentu spełnienia warunków: 
# liczba rzutów jest większa niż 30 oraz absolutna wartość 
# różnicy między średnią wartością oczek, a wartością oczekiwana jest mniejsza niż 0.1.