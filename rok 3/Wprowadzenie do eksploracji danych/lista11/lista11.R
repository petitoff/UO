# Ustawienie ścieżki dostępu do danych
path <- "C:/Users/petit/Desktop/repos/UO/rok 3/Wprowadzenie do eksploracji danych/lista11"
setwd(path)

# Wczytanie danych
data <- read.csv('wine/wine.data', header = FALSE)