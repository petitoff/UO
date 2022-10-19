Pole <- matrix(rep(0,9),nrow = 3)
zajete_pola <- 0
gracz <- 1

while(zajete_pola<9){
  xx <- sample(1:3,1); yy <- sample(1:3,1);
  
  if(Pole[yy,xx] == 0){
    Pole[yy,xx] <- gracz
    zajete_pola <- zajete_pola + 1
  }
  
  S1 <- sum(rowSums(Pole) == 3) + sum(colSums(Pole) == 3) + 
    sum(sum(diag(Pole)) == 3) + sum(sum(diag(apply(Pole, 2, rev)))==3)  
  S2 <- sum(rowSums(Pole) == 3) + sum(colSums(Pole) == 3) + 
    sum(sum(diag(Pole)) == 3) + sum(sum(diag(apply(Pole, 2, rev)))==3)
  
  if(S1+S2>0){
    break
  }
  
  gracz <- -gracz
}


 

Pole
S1
S2