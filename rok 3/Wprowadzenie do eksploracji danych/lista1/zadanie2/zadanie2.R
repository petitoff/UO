library(datasets)

path = "C:\\Users\\petitoff\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista1\\zadanie2"  # używając podwójnych ukośników
setwd(path) ## ustawienie ścieżki

## zmiana nazwy kolumn:

# Załadowanie danych
wine <- read.csv('wine\\wine.data', header=FALSE)

# Zmień nazwy kolumn
names(wine) <- c('Class', 'Alcohol', 'Malic acid', 'Ash', 'Alcalinity of ash', 'Magnesium', 'Total phenols', 'Flavanoids', 'Nonflavanoid phenols', 'Proanthocyanins', 'Color intensity', 'Hue', 'OD280/OD315 of diluted wines', 'Proline')

## ===================
View(wine)

## Liczba obserwacji w zbiorze
nrow(wine)

## Liczba kolumn
print(names(wine))

## Zmienna celu
unique(wine$Class)

## Podsumowanie cech
summary(wine)

## Wykres 2D:
data(wine, package = "datasets")

# Załadowanie biblioteki do tworzenia wykresów
library(ggplot2)

# Wybór cechy do przedstawienia na wykresie - np. "Alcohol"
feature <- "Alcohol"

# Konwersja zmiennej 'Class' na faktor
wine$Class <- as.factor(wine$Class)

# Stworzenie wykresu 2D z użyciem ggplot2
p <- ggplot(wine, aes(x = Class, y = !!sym(feature), color = Class)) +
  geom_boxplot() +
  labs(title = paste("Wykres", feature, "dla różnych klas"),
       x = "Klasa",
       y = feature) +
  theme_minimal()

# Wyświetlenie wykresu
print(p)

# Zapis do pliku
ggsave("C:\\Users\\petitoff\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista1\\zadanie2\\wykres.png", plot = p, width = 10, height = 6, dpi = 300)

## Wykres 3D:
library(scatterplot3d)

# Stwórz wykres 3D dla wybranych cech
scatterplot3d(wine$Alcohol, wine$`Malic acid`, wine$Ash,
              xlab="Alkohol", ylab="Kwas jabłkowy", zlab="Popiół",
              highlight.3d=TRUE, angle=30)




