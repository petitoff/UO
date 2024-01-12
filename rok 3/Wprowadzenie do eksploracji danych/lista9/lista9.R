# Ustawienie ścieżki dostępu do danych
path <- "C:/Users/petit/Desktop/repos/UO/rok 3/Wprowadzenie do eksploracji danych/lista9"
setwd(path)

# Read the data
wine <- read.csv('wine/wine.data', header = FALSE)

wine

## 1. Dyskretyzacja zmiennej numerycznej

# Załóżmy, że chcesz dyskretyzować drugą kolumnę numeryczną (V2)
variable_to_discretize <- wine[, 2]  # druga kolumna

# Ustal liczbę przedziałów, np. 5
number_of_bins <- 5

# Dyskretyzacja według równej szerokości
equal_width_bins <- cut(variable_to_discretize, breaks = number_of_bins, include.lowest = TRUE)

# Dyskretyzacja według równej częstości
library(classInt)
freq_breaks <- classIntervals(variable_to_discretize, n = number_of_bins, style = "quantile")$brks
equal_freq_bins <- cut(variable_to_discretize, breaks = freq_breaks, include.lowest = TRUE)

# Wykresy dla dyskretyzacji według równej szerokości
hist(variable_to_discretize, breaks = number_of_bins, main = "Histogram (Equal Width)", xlab = "V2")
rug(jitter(as.numeric(equal_width_bins)))

# Wykresy dla dyskretyzacji według równej częstości
hist(variable_to_discretize, breaks = freq_breaks, main = "Histogram (Equal Frequency)", xlab = "V2")
rug(jitter(as.numeric(equal_freq_bins)))

## 2. Dyskretyzacja wszystkich numerycznych zmiennych

# Dyskretyzacja wszystkich numerycznych zmiennych metodą "frequency"
discretized_wine <- wine
for(i in 2:ncol(wine)) {
  discretized_wine[, i] <- cut(wine[, i], breaks = classIntervals(wine[, i], n = number_of_bins, style = "quantile")$brks, include.lowest = TRUE)
}

# Wyświetlenie wartości przed i po dyskretyzacji dla kilku pierwszych wierszy
head(wine)
head(discretized_wine)

## 3. Algorytm A priori

# Parametry algorytmu A priori
min_support <- 0.1
min_confidence <- 0.8

library(arules)
data <- as(discretized_wine, "transactions")
rules <- apriori(data, parameter = list(support = min_support, confidence = min_confidence))

# Ilość wygenerowanych reguł
length(rules)

# Sortowanie reguł według miary lift
rules_sorted <- sort(rules, by = "lift", decreasing = TRUE)

# Wyświetlenie kilku pierwszych reguł
head(rules_sorted)

png("wykres_wsparcie_vs_ufnosc.png")
plot(rules, method = "scatter", measure = c("support", "confidence"))
dev.off()

png("wykres_lift_vs_wsparcie.png")
plot(rules, method = "scatter", measure = c("lift", "support"))
dev.off()

png("wykres_lift_vs_ufnosc.png")
plot(rules, method = "scatter", measure = c("lift", "confidence"))
dev.off()

