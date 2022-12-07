
N <- 100000
kostka <- c(1,2,3,4,5,6)
nr_partii <- 0
wyniki <- rep(0, N)

7
for (i in 0:N) {
  wyniki[i] <- sample(kostka, 1)
}

hist(wyniki)
x <- seq(0, 30, length.out = 100)
y <- dnorm(x, mean = 15, sd = 5)
par(new=T)
plot(x, y, type = "l", lwd = 2, col = "red")