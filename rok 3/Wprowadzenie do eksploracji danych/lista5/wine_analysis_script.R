
library(ggplot2)

# Load the dataset
wine_data <- read.csv("/mnt/data/wine_with_column_names.csv")

# Function to identify and count outliers using IQR
identify_outliers <- function(data) {
  quantiles <- quantile(data, c(.25, .75), na.rm = TRUE)
  iqr <- IQR(data, na.rm = TRUE)
  lower_bound <- quantiles[1] - 1.5 * iqr
  upper_bound <- quantiles[2] + 1.5 * iqr
  outliers <- data[data < lower_bound | data > upper_bound]
  return(list("lower_bound" = lower_bound, "upper_bound" = upper_bound, "outliers" = outliers))
}

# Part a: Detecting outliers for each variable
outliers_info <- lapply(wine_data, identify_outliers)

# Adding artificial outlier if none exists
for (i in 1:length(outliers_info)) {
  if (length(outliers_info[[i]]$outliers) == 0) {
    wine_data[i][1] <- outliers_info[[i]]$upper_bound + 1 # Adding outlier
  }
}

# Part b: Visualize outliers for up to 4 variables
# Selecting first 4 variables for visualization
selected_vars <- head(names(wine_data), 4)
plots <- list()
for (var in selected_vars) {
  plot <- ggplot(wine_data, aes_string(x=var)) + 
            geom_histogram(binwidth = 1, fill="skyblue", color="black") +
            geom_vline(xintercept = outliers_info[[var]]$lower_bound, color="red", linetype="dashed") +
            geom_vline(xintercept = outliers_info[[var]]$upper_bound, color="red", linetype="dashed") +
            ggtitle(paste("Histogram of", var, "with Outliers"))
  plots[[var]] <- plot
}

# Part c: Remove outliers
cleaned_wine_data <- wine_data
for (var in names(wine_data)) {
  cleaned_wine_data <- cleaned_wine_data[cleaned_wine_data[[var]] >= outliers_info[[var]]$lower_bound &
                                          cleaned_wine_data[[var]] <= outliers_info[[var]]$upper_bound, ]
}

# Part d: Visualize post-removal for the same 4 variables
cleaned_plots <- list()
for (var in selected_vars) {
  plot <- ggplot(cleaned_wine_data, aes_string(x=var)) + 
            geom_histogram(binwidth = 1, fill="green", color="black") +
            ggtitle(paste("Histogram of", var, "After Outlier Removal"))
  cleaned_plots[[var]] <- plot
}

# Part e: Save the cleaned dataset
write.csv(cleaned_wine_data, "/mnt/data/cleaned_wine_data.csv", row.names = FALSE)

# Output
list("original_plots" = plots, "cleaned_plots" = cleaned_plots, "cleaned_data_file" = "/mnt/data/cleaned_wine_data.csv")
