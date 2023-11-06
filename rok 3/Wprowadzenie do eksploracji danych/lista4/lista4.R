library(ggplot2)
library(reshape2)

correlation_matrix <- function(df, threshold) {
  # Obliczanie macierzy korelacji
  cor_matrix <- cor(df)
  
  # Rysowanie macierzy korelacji
  melted_cor_matrix <- melt(cor_matrix)
  plot <- ggplot(data = melted_cor_matrix, aes(x=Var1, y=Var2, fill=value)) + 
    geom_tile() +
    scale_fill_gradient2(low = "blue", high = "red", mid = "white", 
                         midpoint = 0, limit = c(-1,1), space = "Lab", 
                         name="Pearson\nCorrelation") +
    theme_minimal() + 
    theme(axis.text.x = element_text(angle = 45, vjust = 1, 
                                     size = 12, hjust = 1),
          axis.text.y = element_text(size = 12)) +
    coord_fixed()
  
  # Zapisywanie rysunku do pliku
  ggsave("correlation_matrix.png", plot)
  
  # Wypisywanie par zmiennych o korelacji większej niż zadany próg
  cor_pairs <- subset(melted_cor_matrix, abs(value) > threshold & Var1 != Var2)
  
  # Usuwanie powtórzeń
  cor_pairs <- cor_pairs[!duplicated(t(apply(cor_pairs[,c("Var1","Var2")],1,sort))),]
  
  return(cor_pairs)
}

# Załadowanie zestawu danych iris
data(iris)

# Usunięcie kolumny Species (bo to jest nasza zmienna celu)
df <- iris[,-5]

# Użycie funkcji na df z progiem 0.5
correlation_matrix(df, 0.5)
