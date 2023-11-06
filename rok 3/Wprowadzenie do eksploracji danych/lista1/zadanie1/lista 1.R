library(datasets)

path = "C:\\Users\\petitoff\\Desktop\\repos\\UO\\rok 3\\Wprowadzenie do eksploracji danych\\lista1\\zadanie1"  # używając podwójnych ukośników
setwd(path) ## ustawienie ścieżki

data(iris)
iris

## Wyświetlenie podstawowych informacji o zbiorze "iris"
View(iris) ## podgląd tabeli z danymi
summary(iris) ## podstawowe statystyki
nrow(iris) ## liczba wierszy
ncol(iris) ## liczba kolumn

##----------------------------------------------------------
## Narysowanie wykresu cechy "Petal.Length" w zależności od klasy
class<-iris[,5] ## 5. kolumna ("Species", czyli klasa)
petall<-iris[,3] ## 3. kolumna ("Petal.Length")
plot(class, petall,
     xlab= "Klasa",
     ylab= "Długość płatka",
     text(class, petall, cex= 0.7))

## Zapisanie rysunku do pliku (w ścieżce "path")
png(file = "plot1.png", width=1200, height=1000, res=150)
plot(class, petall,
     xlab= "Klasa",
     ylab= "Długość płatka",
     text(class, petall, cex= 0.7))
dev.off()

##----------------------------------------------------------
## Narysowanie wykresu trójwymiarowego, trzy cechy
install.packages("scatterplot3d")
library("scatterplot3d")
xx<-iris[,2] ## 2. kolumna ("Sepal.Width")
yy<-iris[,3] ## 3. kolumna ("Petal.Length")
zz<-iris[,4] ## 4. kolumna ("Petal.Width")
png(file = "plot2.png", width=1200, height=1000, res=150)
scatterplot3d(xx,yy,zz,
              xlab= "Szerokość listka",
              ylab= "Długość płatka",
              zlab= "Szerokość płatka")
dev.off()