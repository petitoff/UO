# Błażej Domagała
counter <- 0

# Funkcja 'generate_von_Neumann' generuje wartość za pomocą algorytmu eliminacyjnego von Neumanna
generate_von_Neumann <- function(){
  repeat{
    counter <<- counter + 1
    x <- runif(1, -3, 5)
    y <- runif(1, 0, 1)

    # Jeśli wartość 'y' jest mniejsza lub równa wartości funkcji Gaussa o środku w 1 i szerokości 2, pętla jest przerywana i wartość 'x' jest zwracana
    if (y <= ((1/(2 * sqrt(2 * pi))) * exp(-1 * (x - 1)^2 / (2 * 2)))) break
  }
  return(x)
}

data_table <- rep(0, 10000)

for (i in 1:10000) {
  data_table[i] <- generate_von_Neumann()
}

sample_table <- sample(data_table, 100, replace = F)

# Funkcja 'shapiro.test' jest używana do testowania, czy 'sample_table' pochodzi z rozkładu normalnego
shapiro.test(sample_table)

confidence_level <- 1 - 0.95
expected_value <- mean(sample_table)
std_dev <- sqrt(var(sample_table))

# Zmienna 't_value' jest inicjalizowana jako kwantyl rozkładu t-Studenta dla poziomu ufności 'confidence_level' i liczby stopni swobody równej 99
t_value <- qt(1 - confidence_level/2, 99)
delta <- t_value * std_dev / sqrt(100)
cat("Przedział ufności dla wartości oczekiwanej: ", expected_value - delta, ",", expected_value + delta)

# Zmienna 'chi_1' jest inicjalizowana jako kwant
chi_1 <- qchisq(confidence_level/2, 99)
chi_2 <- qchisq(1 - confidence_level/2, 99)

variance <- var(sample_table)
cat("Przedział ufności dla wariancji: ", 99 * variance / chi_2, ",", 99 * variance / chi_1)

# generator liczb pseudolosowych z rozkładu normalnego za pomocą metody eliminacji von Neumanna, a następnie testowanie czy wygenerowane liczby faktycznie pochodzą z rozkładu normalnego oraz określenie przedziałów ufności dla wartości oczekiwanej i wariancj