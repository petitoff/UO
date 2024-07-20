# # Wczytujemy zbiór danych do postaci Data Frame
# grzyby <- read.csv("C:/Users/petit/Desktop/repos/uo/rok 3/Sztuczna inteligencja/DrzewaDecyzyjne/mushroom.csv")
# 
# # Sprawdzamy czy dane są kompletne oraz jakiego są typu
# str(grzyby)

# Zmieniamy typ zmiennych na obsługiwany typ za pomocą kodu:
library(dplyr)
grzyby <- mutate_if(grzyby, is.character, as.factor)

# Ponownie sprawdzamy strukturę danych po zmianach
str(grzyby)

# Ustawienie ziarna losowego dla powtarzalności wyników
set.seed(1456)

# Podział danych na zbiór treningowy i testowy
library(caret)
trainIndex <- createDataPartition(grzyby$class, p = 0.75, list = FALSE, times = 1)
sTrain <- grzyby[trainIndex,]
sTest <- grzyby[-trainIndex,]

# Sprawdzenie liczebności klas w zbiorze treningowym
table(sTrain$class)


# Parametry dla drzewa decyzyjnego
library(rpart)
library(rpart.plot)
dt_control <- rpart.control(maxdepth = 25, xval = 10, cp = 0)

# Konstrukcja drzewa decyzyjnego
d_tree <- rpart(class ~ ., data = sTrain, method = "class", control = dt_control, minsplit = 5)

# Wyświetlenie tabeli z wartościami cp oraz błędami walidacji krzyżowej
printcp(d_tree)

# Wykres błędu xerror w funkcji parametru złożoności cp
plotcp(d_tree)

# Przycinanie drzewa na podstawie optymalnego cp
d_tree_pruned <- prune(d_tree, cp = 0.002)

# Rysowanie przyciętego drzewa
rpart.plot(d_tree_pruned, extra = 101, fallen.leaves = FALSE, tweak = 1.2, varlen = 10, faclen = 10)

# Predykcja na zbiorze testowym
d_tree_predict <- predict(d_tree_pruned, sTest, type = "class")

# Macierz konfuzji i ocena modelu
library(caret)
confusionMatrix(d_tree_predict, sTest$class)

# Wyniki testów dla wcześniej narysowanych drzew
confusionMatrix(d_tree_predict, sTest$class)

# Podsumowanie:
# Najlepsze drzewo zostało przedstawione na rysunku powyżej, ma X węzłów (nspit), oraz wartość cp = 0.002.
