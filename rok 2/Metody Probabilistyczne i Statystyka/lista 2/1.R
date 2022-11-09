

nr_partii <- 0
wynik <- rep(0, nr_partii)


for (i in 0:1000) {
  nr <- sample(1:6, 1)
  wynik[i] <- nr
}


hist(wynik, col = "red", main = "Histogram", xlab = "nr partii", ylab = "liczba wystąpień")
