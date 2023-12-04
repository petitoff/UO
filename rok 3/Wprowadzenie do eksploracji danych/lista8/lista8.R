library(tidyverse)
library(cluster)
library(factoextra)
library(ggplot2)

# Ustawienie ścieżki dostępu do danych
path <- "C:/Users/petit/Desktop/repos/UO/rok 3/Wprowadzenie do eksploracji danych/lista8/wine"
setwd(path)

# Read the data
wine_data <- read.csv('wine.data', header = FALSE)

# Standardize the data
wine_data_scaled <- scale(wine_data)

# a) Stosowanie metody k-średnich dla k = 1 do 15
results <- list()
for (k in 1:15) {
  set.seed(123)  # dla powtarzalności wyników
  kmeans_result <- kmeans(wine_data_scaled, centers = k, nstart = 25)
  results[[k]] <- kmeans_result
  cat("Dla k =", k, "\n",
      "Całkowita suma kwadratów wewnątrz klastrów:", kmeans_result$tot.withinss, "\n",
      "Suma kwadratów dla każdego klastra:", kmeans_result$withinss, "\n",
      "Centra klastrów:\n", kmeans_result$centers, "\n",
      "Liczba obserwacji w każdym klastrze:", kmeans_result$size, "\n",
      "Przypisanie klastrów dla pierwszych 20 obserwacji:", kmeans_result$cluster[1:20], "\n\n")
}

# b) Wizualizacja wyników dla k = 2 do 7
par(mfrow = c(3, 2))
summary(results[[2]])

for (k in 2:7) {
  # Tworzenie wykresu
  plot <- fviz_cluster(results[[k]], data = wine_data_scaled, geom = "point", ellipse = TRUE, main = paste("k =", k))
  
  # Wyświetlanie wykresu
  print(plot)
  
  # Zapisywanie wykresu do pliku PNG
  ggsave(filename = paste("kmeans_k", k, ".png"), plot = plot, width = 10, height = 6)
  
  # Sprawdź, czy plik został zapisany
  if (file.exists(paste("kmeans_k", k, ".png"))) {
    cat("Plik", paste("kmeans_k", k, ".png"), "został zapisany.\n")
  } else {
    cat("Plik", paste("kmeans_k", k, ".png"), "NIE został zapisany.\n")
  }
}


# c) Określenie optymalnej liczby klastrów
# Metoda łokcia
elbow_plot <- fviz_nbclust(wine_data_scaled, kmeans, method = "wss")
ggsave(filename = "elbow_method.png", plot = elbow_plot, width = 10, height = 6)

# Metoda średniego konturu
silhouette_plot <- fviz_nbclust(wine_data_scaled, kmeans, method = "silhouette")
ggsave(filename = "silhouette_method.png", plot = silhouette_plot, width = 10, height = 6)

# Statystyka luk
set.seed(123)
gap_stat <- clusGap(wine_data_scaled, FUN = kmeans, nstart = 25, K.max = 10, B = 50)
gap_stat_plot <- fviz_gap_stat(gap_stat)
ggsave(filename = "gap_statistic.png", plot = gap_stat_plot, width = 10, height = 6)

