
N <- 200000
licznik <- 0

for(i in 1:N){
  LL <- runif(1, 0, 10)
  Pole <- LL * (10 - LL)
  
  if(Pole <= 21){
    licznik <- licznik + 1
  }
}

licznik/N
