# Biblioteka datasets
library(datasets)
library(ggplot2)

# Ustawienie ścieżki dostępu do danych
path = "C:\\Users\\petit\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista5\\"
setwd(path)

# -------------- Zadanie 2a: Wczytanie i identyfikacja punktów oddalonych -------------- #
# Wczytanie danych
wine <- read.csv('wine\\wine.data', header = FALSE)

# a) Wyszukiwanie punktów oddalonych dla każdej zmiennej
outliers <- list()
for (i in 1:ncol(wine)) {
  Q1 <- quantile(wine[[i]], 0.25)
  Q3 <- quantile(wine[[i]], 0.75)
  IQR <- Q3 - Q1
  lower_bound <- Q1 - 1.5 * IQR
  upper_bound <- Q3 + 1.5 * IQR
  
  outliers[[i]] <- which(wine[[i]] < lower_bound | wine[[i]] > upper_bound)
  cat("Variable", i, ": Number of outliers =", length(outliers[[i]]), "\n")
}

# b) Wykresy dla punktów oddalonych
for (i in 1:min(4, length(outliers))) {
  if (length(outliers[[i]]) > 0) {
    p <- ggplot(wine, aes_string(x=names(wine)[i])) + 
      geom_histogram(binwidth = 1, fill="blue", color="black") +
      geom_vline(xintercept=wine[outliers[[i]], i], color="red", linetype="dashed") +
      ggtitle(paste("Histogram of Variable", i, "with Outliers"))
    print(p)
    ggsave(paste("histogram_outliers_var", i, ".png", sep=""), plot=p, width=10, height=6)
  }
}

# c) Usuwanie punktów oddalonych
total_outliers_removed <- 0
outlier_indices <- unique(unlist(outliers)) # Zbieranie unikalnych indeksów wierszy do usunięcia
total_outliers_removed <- length(outlier_indices)
wine <- wine[-outlier_indices, ] # Usunięcie wierszy jednorazowo

cat("Total outliers removed:", total_outliers_removed, "\n")
cat("Remaining data points:", nrow(wine), "\n")

# d) Ponowne sporządzenie wykresów
for (i in 1:selected_variables) {
  if (length(outliers[[i]]) > 0) {
    p <- ggplot(wine, aes_string(x=names(wine)[i])) + 
      geom_histogram(binwidth = 1, fill="blue", color="black") +
      ggtitle(paste("Histogram of Variable", i, "After Removing Outliers"))
    print(p)
    ggsave(paste("histogram_cleaned_var", i, ".png", sep=""), plot=p, width=10, height=6)
  }
}

# e) Zapis zmodyfikowanego zbioru danych do pliku
write.csv(wine, "wine_cleaned.csv", row.names=FALSE)