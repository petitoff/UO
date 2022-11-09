N <- 100000

wyniki <- rep(0, N)

for(i in 1:N){
  wyniki[i] <- sample(c(-1,1), 1)
}

mean(wyniki)
plot(wyniki, pch=20)

konto <- cumsum(wyniki)
plot(konto, type="l")