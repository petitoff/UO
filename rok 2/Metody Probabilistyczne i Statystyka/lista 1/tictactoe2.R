# encoding: UTF-8


#===========================================================
#   Zapis zajęć z 19.10.2022,  grupa 1,  (z godz. 15:15)
#===========================================================

Powt<-1000              # Ustalamy liczbę partii
gr1<-0                  # wyzeruj liczbę zwycięstw gracza 1
dl_partii<-rep(0,Powt)  # utwórz tablicę do zapisu liczby
# posunięć w poszczególnych partiach
zaj_pola<-rep(0,Powt)   # utwórz tablicę do zapisu liczby
# zajętych pól w poszczeg. partiach

pierwsza_runda <- 0

for(i in 1:Powt){
  #---------------------------------------------------------
  # Kod procedury symulującej jedną partię (O i X)  
  Pole<-matrix(rep(0,9),nrow=3)  # Wyzeruj planszę 3x3 
  gracz<-1;     # gracze będą stawiali na planszy 1 i -1
  zap_pola<-0;  # wyzeruj licznik zapełnionych pól
  N<-0          # wyzeruj licznik posunięć w partii
  
  while(zap_pola<9){  # dopóki są wolne pola wykonuj 
    N<-N+1      # uaktualnij numer posunięcia
    
    
    if(gracz == 1){
      xx<-sample(1:3,1)
      yy<-sample(1:3,1)
    }
    else{
      if(N == 2){
        xx <- 2
        yy <- 2
      }
      else{
        xx<-sample(1:3,1)
        yy<-sample(1:3,1)
      }
    }
    
    
    
    if(Pole[yy,xx]==0){    # jeśli wylosowano puste pole
      Pole[yy,xx]<-gracz;  # postaw znak gracza
      zap_pola<-zap_pola+1 # zwiększ licznik zajętych pól
    }
    # policz, ile jest układów trzech 1 w jednej linii
    # poziomej, pionowej lub ukośnej
    S1<-sum(rowSums(Pole)==3)+sum(colSums(Pole)==3)+
      sum(sum(diag(Pole))==3)+
      sum(sum(diag(apply(Pole,2,rev)))==3)
    # policz, ile jest układów trzech -1 w jednej linii
    # poziomej, pionowej lub ukośnej    
    S2<-sum(rowSums(Pole)==-3)+sum(colSums(Pole)==-3)+
      sum(sum(diag(Pole))==-3)+
      sum(sum(diag(apply(Pole,2,rev)))==-3)
    if(S1+S2>0) break # jeśli pojawił się układ potrójny,
    # to przerwij partię
    gracz<- -gracz    # ruch otrzymuje przeciwnik 
  }
  #---------------------------------------------------------
  if(gracz==1) gr1<-gr1+1 # jeśli wygrał gracz 1, zwiększ
  # jego licznik
  dl_partii[i]<-N        # zapisz liczbę posunięć
  # w i-tej partii
  zaj_pola[i]<-zap_pola   # zapisz liczbę zajętych pól
  # w i-tej partii
}

# wypisz ułamek zwycięstw 1 gracza (czyli przybliżone
# prawdopodobieństwo zwycięstwa 1 gracza)
prawdop_wygrania_gr1 <- gr1/Powt


# narysuj histogram ("rozkład") liczby zajętych pól
hist(zaj_pola)

# narysuj histogram liczby posunięć w partiach
hist(dl_partii, breaks=40)
