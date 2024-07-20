# Clears all Environment Variables
# clears console ctrl-L

# Install keras package
# install.packages("keras")

# Load the keras library
library(keras)

# Install Keras and TensorFlow
# install_keras()


# Load MNIST dataset
mnist <- dataset_mnist()
train_images <- mnist$train$x
train_labels <- mnist$train$y
test_images <- mnist$test$x
test_labels <- mnist$test$y

# Check dimensions and structure of the data
print(dim(train_images))
print(str(train_images))
print(str(train_labels))

print(dim(test_images))
print(str(test_images))
print(str(test_labels))

# Display a sample image
no_of_sample <- 55
digit <- train_images[no_of_sample,,]
plot(as.raster(digit, max = 255))

# Preserve original test images and labels
test_images_original <- test_images
test_labels_original <- test_labels

# Reduce dataset size for training
train_images <- train_images[1:10000,,]
train_labels <- train_labels[1:10000]

# Reshape and normalize the images
train_images <- array_reshape(train_images, c(10000, 28 * 28))
train_images <- train_images / 255

test_images <- array_reshape(test_images, c(10000, 28 * 28))
test_images <- test_images / 255

# Convert labels to categorical
train_labels <- to_categorical(train_labels, 10)
test_labels <- to_categorical(test_labels, 10)

# Debug outputs
print(dim(train_labels))
print(dim(test_labels))

# Define the neural network model
network <- keras_model_sequential() %>%
  layer_dense(units = 512, activation = 'relu', input_shape = c(28*28)) %>%
  layer_dense(units = 64, activation = 'relu') %>%
  layer_dense(units = 10, activation = 'softmax')

# Compile the model
network %>% compile(
  optimizer = 'rmsprop',
  loss = 'categorical_crossentropy',
  metrics = c('accuracy')
)

# Train the model
network %>% fit(train_images, train_labels,
                epochs = 30,
                batch_size = 128,
                validation_split = 0.2)

# Evaluate the model
network %>% evaluate(test_images, test_labels)

# Predictions and result processing
predictions <- network %>% predict(test_images[1:400,])
class_predicted <- apply(predictions, 1, function(x) which.max(x)-1)
original_labels <- test_labels_original[1:400]

prediction_result <- data.frame(class_predicted, original_labels)
print(prediction_result)

wrong_predictions <- prediction_result[class_predicted != original_labels,]
print(wrong_predictions)


##################

model1 <- keras_model_sequential() %>%
  layer_dense(units = 512, activation = 'relu', input_shape = c(28 * 28)) %>%
  layer_dense(units = 10, activation = 'softmax')

model2 <- keras_model_sequential() %>%
  layer_dense(units = 256, activation = 'relu', input_shape = c(28 * 28)) %>%
  layer_dense(units = 10, activation = 'softmax')

model3 <- keras_model_sequential() %>%
  layer_dense(units = 512, activation = 'relu', input_shape = c(28 * 28)) %>%
  layer_dense(units = 256, activation = 'relu') %>%
  layer_dense(units = 10, activation = 'softmax')

model4 <- keras_model_sequential() %>%
  layer_dense(units = 256, activation = 'relu', input_shape = c(28 * 28)) %>%
  layer_dense(units = 128, activation = 'relu') %>%
  layer_dense(units = 10, activation = 'softmax')

model5 <- keras_model_sequential() %>%
  layer_dense(units = 512, activation = 'relu', input_shape = c(28 * 28)) %>%
  layer_dense(units = 256, activation = 'relu') %>%
  layer_dense(units = 128, activation = 'relu') %>%
  layer_dense(units = 10, activation = 'softmax')

models <- list(model1, model2, model3, model4, model5)
for (model in models) {
  model %>% compile(
    optimizer = 'rmsprop',
    loss = 'categorical_crossentropy',
    metrics = c('accuracy')
  )
}

history1 <- model1 %>% fit(train_images, train_labels, epochs = 30, batch_size = 128, validation_split = 0.2)
history2 <- model2 %>% fit(train_images, train_labels, epochs = 30, batch_size = 128, validation_split = 0.2)
history3 <- model3 %>% fit(train_images, train_labels, epochs = 30, batch_size = 128, validation_split = 0.2)
history4 <- model4 %>% fit(train_images, train_labels, epochs = 30, batch_size = 128, validation_split = 0.2)
history5 <- model5 %>% fit(train_images, train_labels, epochs = 30, batch_size = 128, validation_split = 0.2)

# Funkcja do zapisywania wykresów
save_plot <- function(history, model_number) {
  # Accuracy plot
  jpeg(filename = paste0("model_", model_number, "_accuracy.jpg"))
  plot(history$metrics$accuracy, type = "l", col = "blue", ylim = c(0, 1), xlab = "Epoch", ylab = "Accuracy", main = paste("Model", model_number, "Accuracy"))
  lines(history$metrics$val_accuracy, type = "l", col = "red")
  legend("bottomright", legend = c("Train", "Validation"), col = c("blue", "red"), lty = 1:1)
  dev.off()
  
  # Loss plot
  jpeg(filename = paste0("model_", model_number, "_loss.jpg"))
  plot(history$metrics$loss, type = "l", col = "blue", ylim = c(0, max(history$metrics$loss)), xlab = "Epoch", ylab = "Loss", main = paste("Model", model_number, "Loss"))
  lines(history$metrics$val_loss, type = "l", col = "red")
  legend("topright", legend = c("Train", "Validation"), col = c("blue", "red"), lty = 1:1)
  dev.off()
}

# Zapisywanie wykresów
save_plot(history1, 1)
save_plot(history2, 2)
save_plot(history3, 3)
save_plot(history4, 4)
save_plot(history5, 5)

model1 %>% evaluate(test_images, test_labels)
model2 %>% evaluate(test_images, test_labels)
model3 %>% evaluate(test_images, test_labels)
model4 %>% evaluate(test_images, test_labels)
model5 %>% evaluate(test_images, test_labels)

#### Generowanie predykcji i porównanie wyników
predictions <- model5 %>% predict(test_images[1:500,])
prediction_result <- data.frame(Predicted = max.col(predictions) - 1, Actual = test_labels_original[1:500])
print(prediction_result)

# Wygeneruj listę błędnie sklasyfikowanych próbek:
wrong <- which(prediction_result$Predicted != prediction_result$Actual)
wrong_predictions <- prediction_result[wrong, ]
print(wrong_predictions)

png(filename = "wrong_predictions_plot.png")
plot(wrong_predictions$Predicted, wrong_predictions$Actual, 
     main = "Błędne klasyfikacje", xlab = "Predykcje", ylab = "Rzeczywiste wartości")
dev.off()

########################

# Błędnie sklasyfikowane próbki
wrong_indices <- which(prediction_result$Predicted != prediction_result$Actual)
correct_indices <- which(prediction_result$Predicted == prediction_result$Actual)

# Wygeneruj obrazki dla błędnie sklasyfikowanych próbek
for (i in wrong_indices) {
  digit <- test_images_original[i,,]
  png(filename = paste0("wrong_digit_", i, ".png"))
  plot(as.raster(digit, max = 255))
  dev.off()
}

# Wygeneruj obrazki dla prawidłowo sklasyfikowanych próbek (3 przykłady)
for (i in correct_indices[1:3]) {
  digit <- test_images_original[i,,]
  png(filename = paste0("correct_digit_", i, ".png"))
  plot(as.raster(digit, max = 255))
  dev.off()
}



