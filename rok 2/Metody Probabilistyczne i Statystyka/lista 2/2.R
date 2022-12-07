
N <- 100000
kostka <- c(1,2,3,4,5,6)
nr_partii <- 0
wyniki <- rep(0, N)


for (i in 0:N) {
  pierwsza <- sample(kostka, 1)
  druga <- sample(kostka, 1)
  
  wyniki[i] <- pierwsza + druga
}

hist(wyniki)