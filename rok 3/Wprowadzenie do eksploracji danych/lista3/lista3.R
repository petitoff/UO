library(datasets)

path = "C:\\Users\\petitoff\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista3\\"  # używając podwójnych ukośników
setwd(path) ## ustawienie ścieżki

# Załadowanie danych
wine <- read.csv('wine\\wine.data', header = FALSE)


print(wine)

# b) Oto kod zmieniający nazwy kolumn na nazwy w języku polskim:
  
nowe_nazwy <- c(
  "Klasa",
  'Alkohol',
  'Kwas jabłkowy',
  'Popiół',
  'Alkalność popiołu',
  'Magnez',
  'Całkowite fenole',
  'Flawonoidy',
  'Fenole nietrwałe',
  'Proantocyjanidy',
  'Intensywność koloru',
  'Odcień',
  'Stężenie odwiedlane win',
  'Prolina'
)

names(wine) <- nowe_nazwy
View(wine)

# c) Oto kod zapisujący zmienne o wartościach logicznych jako logiczne:
  
wine$Klasa <- as.logical(wine$Klasa)
View(wine)
  
# d) Oto kod sprawdzający, czy zmienne o wartościach liczbowych są typu liczbowego, i jeśli nie, zapisujący je jako numeryczne:
  
wprowadzone <- c('Alkohol', 'Kwas jabłkowy', 'Popiół', 'Alkalność popiołu', 'Magnez', 'Całkowite fenole', 'Flawonoidy', 'Fenole nietrwałe', 'Proantocyjanidy', 'Intensywność koloru', 'Odcień', 'Stężenie odwiedlane win', 'Prolina')
for (zmienna in wprowadzone) {
  if (class(wine[[zmienna]]) != "numeric") {
    wine[[zmienna]] <- as.numeric(wine[[zmienna]])
  }
}

# e) Zmienną celu zapisz jako mającą wartości nominalne (polecenie as.factor)
wine$Klasa <- as.factor(wine$Klasa)
View(wine)

# f) Oto kod sprawdzający i zamieniający brakujące wartości w kolumnach numerycznych na wartości średnie dla tych kolumn:
  
kolumny_numeryczne <- c('Alkohol', 'Kwas jabłkowy', 'Popiół', 'Alkalność popiołu', 'Magnez', 'Całkowite fenole', 'Flawonoidy', 'Fenole nietrwałe', 'Proantocyjanidy', 'Intensywność koloru', 'Odcień', 'Stężenie odwiedlane win', 'Prolina')

for (kolumna in kolumny_numeryczne) {
  brakujace <- is.na(wine[[kolumna]])
  if (sum(brakujace) > 0) {
    srednia <- mean(wine[[kolumna]], na.rm = TRUE)
    wine[[kolumna]][brakujace] <- srednia
  }
}

  
# g) Oto kod zapisujący przetworzone dane do pliku:
  
write.csv(wine, file = 'wyniki.csv', row.names = FALSE)