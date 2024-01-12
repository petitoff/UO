# Wczytanie potrzebnych bibliotek
library(e1071)
library(caret)
library(ggplot2)

# Ustawienie ścieżki dostępu do danych
path <- "C:/Users/petit/Desktop/repos/UO/rok 3/Wprowadzenie do eksploracji danych/lista10"
setwd(path)

# Wczytanie danych
data <- read.csv('wine/wine.data', header = FALSE)

set.seed(123)  # Dla powtarzalności wyników
splitIndex <- createDataPartition(data$V14, p = .8, list = FALSE)
train_data <- data[splitIndex, ]
test_data <- data[-splitIndex, ]

# b) Naiwny klasyfikator Bayesowski
library(e1071)
nb_model <- naiveBayes(V14 ~ ., data = train_data)
# print(nb_model)

write.csv(nb_model$tables, file = "nb_model.csv")

# c) Klasyfikacja danych testowych i macierz błędów
nb_predictions <- predict(nb_model, test_data)

# Upewnienie się, że przewidywania mają te same poziomy co zmienna celu
nb_predictions <- factor(nb_predictions, levels = levels(as.factor(test_data$V14)))

# Tworzenie macierzy błędów
confusionMatrix(nb_predictions, as.factor(test_data$V14))


# d) Dokładność klasyfikacji i współczynnik błędu
accuracy <- sum(nb_predictions == test_data$V14) / nrow(test_data)
error_rate <- 1 - accuracy
print(accuracy)
print(error_rate)

# e) Cztery modele SVM
library(kernlab)

# Przygotowanie danych (standaryzacja)
train_data_scaled <- scale(train_data[, -ncol(train_data)])
test_data_scaled <- scale(test_data[, -ncol(test_data)])

# SVM z różnymi jądrami
svm_radial <- ksvm(V14 ~ ., data = train_data, kernel = "rbfdot")
svm_linear <- ksvm(V14 ~ ., data = train_data, kernel = "vanilladot")
svm_polynomial <- ksvm(V14 ~ ., data = train_data, kernel = "polydot")
svm_sigmoid <- ksvm(V14 ~ ., data = train_data, kernel = "tanhdot")

# f) Parametry i liczba wektorów nośnych dla każdego modelu
summary(svm_radial)
summary(svm_linear)
summary(svm_polynomial)
summary(svm_sigmoid)

# g) Klasyfikacja zbioru testowego dla modeli SVM
svm_radial_pred <- predict(svm_radial, test_data)
svm_linear_pred <- predict(svm_linear, test_data)
svm_polynomial_pred <- predict(svm_polynomial, test_data)
svm_sigmoid_pred <- predict(svm_sigmoid, test_data)

# h) Macierze błędów i dokładność dla każdego modelu SVM
# Konwersja przewidywań do tego samego typu i poziomów co oryginalna zmienna celu
svm_radial_pred_factor <- factor(svm_radial_pred, levels = levels(as.factor(test_data$V14)))
svm_linear_pred_factor <- factor(svm_linear_pred, levels = levels(as.factor(test_data$V14)))
svm_polynomial_pred_factor <- factor(svm_polynomial_pred, levels = levels(as.factor(test_data$V14)))
svm_sigmoid_pred_factor <- factor(svm_sigmoid_pred, levels = levels(as.factor(test_data$V14)))

# Tworzenie macierzy błędów
confusionMatrix(svm_radial_pred_factor, as.factor(test_data$V14))
confusionMatrix(svm_linear_pred_factor, as.factor(test_data$V14))
confusionMatrix(svm_polynomial_pred_factor, as.factor(test_data$V14))
confusionMatrix(svm_sigmoid_pred_factor, as.factor(test_data$V14))

# j) Wykres Słupkowy Dokładności
# Użyj tych samych średnich i odchylenia standardowego z danych treningowych do przeskalowania danych testowych
test_data_scaled <- scale(test_data[, -ncol(test_data)], center = attr(train_data_scaled, "scaled:center"), scale = attr(train_data_scaled, "scaled:scale"))

# Wykonanie predykcji
predictions_radial <- predict(svm_radial, test_data_scaled[, -ncol(test_data_scaled)])
predictions_linear <- predict(svm_linear, test_data_scaled[, -ncol(test_data_scaled)])
predictions_polynomial <- predict(svm_polynomial, test_data_scaled[, -ncol(test_data_scaled)])
predictions_sigmoid <- predict(svm_sigmoid, test_data_scaled[, -ncol(test_data_scaled)])

# Obliczenie dokładności
svm_radial_accuracy <- sum(predictions_radial == test_data$V14) / nrow(test_data)
svm_linear_accuracy <- sum(predictions_linear == test_data$V14) / nrow(test_data)
svm_polynomial_accuracy <- sum(predictions_polynomial == test_data$V14) / nrow(test_data)
svm_sigmoid_accuracy <- sum(predictions_sigmoid == test_data$V14) / nrow(test_data)

# Tworzenie wykresu słupkowego
accuracy_values <- c(accuracy_nb, svm_radial_accuracy, svm_linear_accuracy, svm_polynomial_accuracy, svm_sigmoid_accuracy)
names(accuracy_values) <- c("Bayes", "SVM Radial", "SVM Linear", "SVM Polynomial", "SVM Sigmoid")
barplot(accuracy_values, main="Porównanie dokładności metod klasyfikacji", ylab="Dokładność", xlab="Metoda", col=rainbow(length(accuracy_values)))
