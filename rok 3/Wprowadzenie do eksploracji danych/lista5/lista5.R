# Biblioteka datasets
library(datasets)

# Ustawienie ścieżki dostępu do danych
path = "C:\\Users\\petit\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista5\\"
setwd(path)

# -------------- Zadanie 2a: Wczytanie i identyfikacja punktów oddalonych -------------- #
# Wczytanie danych
wine_data <- read.csv('wine\\wine.data', header = FALSE)

# Funkcja do identyfikacji i zliczania punktów oddalonych przy użyciu IQR
identify_outliers <- function(data) {
  quantiles <- quantile(data, c(.25, .75), na.rm = TRUE)
  iqr <- IQR(data, na.rm = TRUE)
  lower_bound <- quantiles[1] - 1.5 * iqr
  upper_bound <- quantiles[2] + 1.5 * iqr
  outliers <- data[data < lower_bound | data > upper_bound]
  return(list("dolna_granica" = lower_bound, "gorna_granica" = upper_bound, "punkty_oddalone" = outliers))
}

# Część a: Wykrywanie punktów oddalonych dla każdej zmiennej
outliers_info <- lapply(wine_data, identify_outliers)

# Dodanie sztucznego punktu oddalonego, jeśli nie istnieje
for (i in 1:length(outliers_info)) {
  if (length(outliers_info[[i]]$punkty_oddalone) == 0) {
    wine_data[i][1] <- outliers_info[[i]]$gorna_granica + 1 # Dodanie punktu oddalonego
  }
}

# Część b: Wizualizacja punktów oddalonych dla maksymalnie 4 zmiennych
# Wybór pierwszych 4 zmiennych do wizualizacji
selected_vars <- head(names(wine_data), 4)
plots <- list()
for (var in selected_vars) {
  plot <- ggplot(wine_data, aes_string(x=var)) + 
    geom_histogram(binwidth = 1, fill="skyblue", color="black") +
    geom_vline(xintercept = outliers_info[[var]]$dolna_granica, color="red", linetype="dashed") +
    geom_vline(xintercept = outliers_info[[var]]$gorna_granica, color="red", linetype="dashed") +
    ggtitle(paste("Histogram zmiennej", var, "z punktami oddalonymi"))
  plots[[var]] <- plot
}

# Część c: Usuwanie punktów oddalonych
cleaned_wine_data <- wine_data
for (var in names(wine_data)) {
  cleaned_wine_data <- cleaned_wine_data[cleaned_wine_data[[var]] >= outliers_info[[var]]$dolna_granica &
                                           cleaned_wine_data[[var]] <= outliers_info[[var]]$gorna_granica, ]
}

# Część d: Wizualizacja po usunięciu punktów oddalonych dla tych samych 4 zmiennych
cleaned_plots <- list()
for (var in selected_vars) {
  plot <- ggplot(cleaned_wine_data, aes_string(x=var)) + 
    geom_histogram(binwidth = 1, fill="green", color="black") +
    ggtitle(paste("Histogram zmiennej", var, "po usunięciu punktów oddalonych"))
  cleaned_plots[[var]] <- plot
}

# Część e: Zapisanie oczyszczonego zbioru danych
write.csv(cleaned_wine_data, "cleaned_wine_data.csv", row.names = FALSE)

# Wynik
list("oryginalne_wykresy" = plots, "oczyszczone_wykresy" = cleaned_plots, "plik_z_oczyszczonymi_danymi" = "/mnt/data/cleaned_wine_data.csv")
