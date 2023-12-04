library(datasets)
library(MASS)

if (!require(FactoMineR)) install.packages("FactoMineR")
library(FactoMineR)
if (!require(factoextra)) install.packages("factoextra")
library(factoextra)

# Ustawienie ścieżki dostępu do danych
path = "C:\\Users\\petit\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista7\\"
setwd(path)

# Wczytanie danych
wine_data <- read.csv('wine\\wine.data', header = FALSE)

# Usunięcie obserwacji brakujących i punktów oddalonych
wine_data <- na.omit(wine_data)  # Usunięcie obserwacji brakujących

# Obliczanie odległości Mahalanobisa dla każdego punktu
wine_data$distance <- mahalanobis(wine_data, colMeans(wine_data), cov(wine_data))

# Ustalenie progu dla identyfikacji punktów oddalonych, np. 95 percentyla
threshold <- quantile(wine_data$distance, 0.95)

# Usuwanie punktów oddalonych
wine_data <- wine_data[wine_data$distance <= threshold, ]

# Przygotowanie danych do PCA
wine_data_pca <- PCA(wine_data, graph = FALSE)

# a) Wartości własne i wyjaśniana wariancja
eig_val <- get_eigenvalue(wine_data_pca)
print(eig_val)
fviz_eig(wine_data_pca)  # Wykres osypiskowy
ggsave("scree_plot.png", bg = "white")  # Zapisanie do pliku

# b) Ładunki czynnikowe
loadings <- wine_data_pca$var$coord
print(loadings)

# c) Zasoby zmienności wspólnej
communalities <- wine_data_pca$var$cos2
print(communalities)

# d) Wkłady zmiennych pierwotnych w składowe główne
contributions <- wine_data_pca$var$contrib
print(contributions)
fviz_pca_var(wine_data_pca)  # Wykres korelacji
ggsave("correlation_plot.png", bg = "white")  # Zapisanie do pliku

# e) Wykres łącznego wkładu dla pierwszych trzech wymiarów
fviz_contrib(wine_data_pca, choice = "var", axes = 1:3)
ggsave("contrib_plot.png", bg = "white")

# f) Wektory własne
eigen_vectors <- wine_data_pca$ind$coord
print(eigen_vectors)

# g) Wybór liczby składowych
# Analiza procentu wyjaśnianej wariancji
fviz_screeplot(wine_data_pca)
ggsave("explained_variance_plot.png", bg = "white")  # Zapisanie do pliku

# Załóżmy, że decydujemy się zachować pierwsze 3 składowe główne
selected_components <- 1:3

# h) Utworzenie nowej tabeli danych

# Wybór składowych głównych do nowej tabeli danych
new_data <- wine_data_pca$ind$coord[, selected_components]

# Konwersja new_data do ramki danych, jeśli to konieczne
new_data <- as.data.frame(new_data)

# Dodanie zmiennej celu (klasy) do nowej tabeli
# Zakładając, że klasa znajduje się w pierwszej kolumnie oryginalnych danych
new_data$class <- wine_data[, 1]

# Zapis nowej tabeli danych do pliku CSV
if (!require(readr)) install.packages("readr")
library(readr)

write_csv(new_data, "new_wine_data.csv")
