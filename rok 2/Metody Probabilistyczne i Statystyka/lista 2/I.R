# cześć I
my_function <- function(number_of_round,number_of_sum) {
  N <- number_of_round
  kostka <- c(1,2,3,4,5,6)
  nr_partii <- 0
  wyniki <- rep(0, N)
  
  
  for (i in 0:N) {
    # sum number of number_of_sum
    for (j in 1:number_of_sum) {
      wyniki[i] <- wyniki[i] + sample(kostka, 1)
    }
  }

  hist(wyniki, freq = F)
  x <- seq(0, 30, length.out = 100)
  y <- dnorm(x, 17.5, 3)
  par(new=T)
  plot(x, y, type = "l", lwd = 2, col = "red")
}

# Część I
my_function(10000, 1)
my_function(10000, 2)
my_function(10000, 3)
my_function(10000, 4)
my_function(10000, 5)

# wnioski z części I:
# - im więcej razy rzucamy kostką tym bardziej rozkład zbliża się do rozkładu normalnego

# część II
my_function(100000, 1)
my_function(100000, 2)
my_function(100000, 3)
my_function(100000, 4)
my_function(100000, 5)

# wnioski z części II:
# - im więcej razy rzucamy kostką tym bardziej rozkład zbliża się do rozkładu normalnego
