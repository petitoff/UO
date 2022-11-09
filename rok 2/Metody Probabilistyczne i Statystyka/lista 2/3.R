

nr_partii <- 0
wynik <- 0


for (i in 1:10000) {
  nr <- sample(1:6, 1)
  nr2 <- sample(1:6, 1)
  nr3 <- sample(1:6, 1)
  wynik[i] <- nr + nr2 + nr3
}


hist(wynik, breaks = 6, col = "red", main = "Histogram", xlab = "nr partii", ylab = "liczba wystąpień")
