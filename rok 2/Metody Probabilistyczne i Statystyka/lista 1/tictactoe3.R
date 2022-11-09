# encoding: UTF-8

Powt<-300              # Ustalamy liczbę partii
gr1<-0                  # wyzeruj liczbę zwycięstw gracza 1

# utwórz tablicę do zapisu liczby posunięć w poszczególnych partiach
dl_partii<-rep(0,Powt)  

# utwórz tablicę do zapisu liczby zajętych pól w poszczeg. partiach
zaj_pola<-rep(0,Powt)

for(i in 1:Powt){
  #---------------------------------------------------------
  # Kod procedury symulującej jedną partię (O i X)  
  Pole<-matrix(rep(0,9),nrow=3)  # Wyzeruj planszę 3x3 
  gracz<-1;     # gracze będą stawiali na planszy 1 i -1
  zap_pola<-0;  # wyzeruj licznik zapełnionych pól
  N<-0          # wyzeruj licznik posunięć w partii
  
  while(zap_pola<9){  # dopóki są wolne pola wykonuj 
    N<-N+1      # uaktualnij numer posunięcia
    
    # wylosuj współrzędne
    xx<-sample(1:3,1)
    yy<-sample(1:3,1)
    
    # check wchich player is playing
    if(gracz == -1){
      # if gracz -1 is playing
      
      # set coordinates
      wierwsze <- 1
      kolumny <- 1
      
      # iterate over Pole (all index)
      for(j in 1:9){
        if(Pole[kolumny,wierwsze]==0){
          Pole[kolumny,wierwsze] <- gracz
          zaj_pola<-zaj_pola+1
          
          # if empty index is found, break
          break;
        }
        
        kolumny <- j%/%3
        if(kolumny == 0){
          kolumny <- kolumny + 1
        }
        
        wierwsze <- wierwsze + 1;
        if(wierwsze == 4){
          wierwsze <- 1
        }
        
      }
    }else if(Pole[yy,xx]==0){
      Pole[yy,xx]<-gracz;
      zap_pola<-zap_pola+1
    }
    
    
    # sprawdzanie wygranej
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
