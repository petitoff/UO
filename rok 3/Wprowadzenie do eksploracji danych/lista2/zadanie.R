path = "C:\\Users\\petitoff\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista2"
setwd(path) ## ustawienie ścieżki

# Załadowanie danych
wine <- read.csv('wine\\wine.data', header = FALSE)

# Wyświetl nazwy kolumn w zbiorze danych "wine"
names(wine)


# Zmień nazwy kolumn
names(wine) <-
  c(
    'Class',
    'Alcohol',
    'Malic acid',
    'Ash',
    'Alcalinity of ash',
    'Magnesium',
    'Total phenols',
    'Flavanoids',
    'Nonflavanoid phenols',
    'Proanthocyanins',
    'Color intensity',
    'Hue',
    'OD280/OD315 of diluted wines',
    'Proline'
  )

# head(wine)

# View(wine)

# a)	Dla wybranej cechy wyświetlić wybrane wartości stosując: zakres wartości, sekwencję indeksów (np. co dziesiąty indeks), indeksy ujemne, warunki logiczne.
# Zakres wartości
wine$Alcohol[5:15]

# Sekwencja indeksów
wine$Alcohol[seq(1, nrow(wine), 10)]

# Indeksy ujemne
wine$Alcohol[-(1:5)]

# Warunki logiczne
wine$Alcohol[wine$Alcohol > 14]


# b) Wybranie wierszy i kolumn:
selected_rows_columns <- wine[1:10, c("Alcohol", "Malic acid")]
print(selected_rows_columns)

# indeksy
wine[5:15,]


# c) Dodanie nowej kolumny:
# Sprawdzanie, czy kolumna istnieje i zawiera dane
if ("Total phenols" %in% names(wine) &&
    !all(is.na(wine$`Total phenols`))) {
  # Dodanie nowej kolumny
  wine$Total.phenols.squared <- wine$`Total phenols` ^ 2
  head(wine)
} else {
  cat("Column 'Total phenols' does not exist or is empty.")
}

# d) Statystyki podstawowe dla wybranej kolumny, np. "Alcohol"
cat("Statystyki dla kolumny 'Alcohol':", "\n")
cat("Zakres: ", min(wine$Alcohol), " - ", max(wine$Alcohol), "\n")
cat("Średnia: ", mean(wine$Alcohol), "\n")
cat("Mediana: ", median(wine$Alcohol), "\n")
cat("Odchylenie standardowe: ", sd(wine$Alcohol), "\n")
cat("Kurtoza: ", moments::kurtosis(wine$Alcohol), "\n")
cat("Skośność: ", moments::skewness(wine$Alcohol), "\n")
cat("Kwantyle: ", quantile(wine$Alcohol, probs = c(0.25, 0.5, 0.75)), "\n")

# e) Macierz korelacji dla wybranych pięciu zmiennych i jej wizualizacja
selected_vars <-
  wine[, c('Alcohol', 'Malic acid', 'Ash', 'Alcalinity of ash', 'Magnesium')]
cor_matrix <- cor(selected_vars)

library(corrplot)
corrplot(cor_matrix, method = "circle")

# f) Histogramy dla trzech różnych zmiennych
par(mfrow = c(1, 3))  # ustawienie layoutu na 1 wiersz i 3 kolumny
hist(wine$Alcohol,
     main = 'Alcohol',
     xlab = '',
     col = 'skyblue')
hist(
  wine$`Malic acid`,
  main = 'Malic acid',
  xlab = '',
  col = 'skyblue'
)
hist(wine$Ash,
     main = 'Ash',
     xlab = '',
     col = 'skyblue')

