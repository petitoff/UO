# encoding: UTF-8

Powt<-10000              # Ustalamy liczbę partii
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
  
  wiersze <- 1
  kolumny <- 1
  
  while(zap_pola<9){  # dopóki są wolne pola wykonuj
    N<-N+1      # uaktualnij numer posunięcia
    
    # check wchich player is playing
    if(gracz == -1){
      # if gracz -1 is playing
      
      if(Pole[kolumny, wiersze]==0){
        Pole[kolumny, wiersze] <- gracz
        zap_pola<-zap_pola+1
      }
      
      wiersze = wiersze + 1;
      
      if(wiersze > 3){
        wiersze <- 1
        kolumny = kolumny + 1;  
      }
      
    } else{
      # wylosuj współrzędne
      xx<-sample(1:3,1)
      yy<-sample(1:3,1)
      
      if(Pole[yy,xx]==0){
        Pole[yy,xx]<-gracz;
        zap_pola<-zap_pola+1
      }
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

Pole

# wypisz ułamek zwycięstw 1 gracza (czyli przybliżone
# prawdopodobieństwo zwycięstwa 1 gracza)
prawdop_wygrania_gr1 <- gr1/Powt

# narysuj histogram ("rozkład") liczby zajętych pól
hist(zaj_pola)

# narysuj histogram liczby posunięć w partiach
hist(dl_partii, breaks=40)


# wnioski
# 1. prawdopodobieństwo zwycięstwa 1 gracza jest bardzo małe (0.3)
# 2. rozkład liczby zajętych pól jest bardzo podobny do rozkładu
#    liczby posunięć w partiach (w obu przypadkach jest to rozkład
#    Poissona) - to oznacza, że w każdej partii jest bardzo mała szansa na
#    wygranie gry w jednym posunięciu (czyli w jednym ruchu) - w każdej partii
#    jest bardzo duża szansa na to, że grę wygra gracz, który zagra ostatni ruch
#    (czyli gracz, który zapełni planszę)