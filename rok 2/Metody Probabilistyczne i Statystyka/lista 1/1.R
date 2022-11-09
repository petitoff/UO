U1 <- c("B", "B", "c")
U2 <- c("B", "C", "c")
U3 <- c("B", "C")

N <- 10000 # liczba powótrzeń
licznik <- 0

for(i in 1:N){
  K1 <- sample(U1, 1)
  K2 <- sample(c(U2, K1), 1)
  K3 <- sample(c(U3, K2), 1)
  
  if(K3 == "B"){
    licznik <- licznik + 1
  }
}


licznik/N