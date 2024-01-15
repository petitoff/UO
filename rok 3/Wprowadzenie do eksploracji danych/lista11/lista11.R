library(rpart)
library(rpart.plot)

# Ustawienie ścieżki dostępu do danych
path <- "C:/Users/petit/Desktop/repos/UO/rok 3/Wprowadzenie do eksploracji danych/lista11"
setwd(path)

# Wczytanie danych
wine <- read.csv('wine/wine.data', header = FALSE)

# Podział danych na zbiór treningowy i testowy
set.seed(123)  # Ustawienie ziarna dla reprodukowalności wyników
indeksy <- sample(1:nrow(wine), nrow(wine) * 0.7)
train_data <- wine[indeksy, ]
test_data <- wine[-indeksy, ]

# Budowa modelu drzewa decyzyjnego z ograniczeniem do 3 poziomów
tree_model <- rpart(V1 ~ ., data = train_data, method = "class", cp = 0, maxdepth = 3)

# Wyświetlenie podsumowania modelu
print(summary(tree_model))

# Rysowanie drzewa
rpart.plot(tree_model)

# Budowa modelu drzewa decyzyjnego bez ograniczenia liczby poziomów
full_tree_model <- rpart(V1 ~ ., data = train_data, method = "class", cp = 0)

# Klasyfikacja danych ze zbioru testowego
predictions <- predict(full_tree_model, test_data, type = "class")

# Macierz błędów, dokładność i % błędów
confusion_matrix <- table(test_data$V1, predictions)
accuracy <- sum(diag(confusion_matrix)) / sum(confusion_matrix)
error_rate <- 1 - accuracy

print(confusion_matrix)
print(paste("Accuracy:", accuracy))
print(paste("Error rate:", error_rate))