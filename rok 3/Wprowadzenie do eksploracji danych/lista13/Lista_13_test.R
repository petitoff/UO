library("TSclust")
library("cluster")

data("synthetic.tseries")
View(synthetic.tseries)

true_cluster <- rep(1:6, each = 3)

COR.dis<-diss(synthetic.tseries, "COR")

p <- hclust(COR.dis)
plot(p)
rect.hclust(p,k=6, border = "red")

COR.hclust <- cutree(hclust(COR.dis), k=6)
plot(COR.hclust, axis(side=1, at=c(1:18)),ylab = "Numer indexu", xlab = "Numer klastra")
axis(side=2, at=c(1:18))

COR.hclust

cluster.evaluation(true_cluster, COR.hclust)

COR.pam<-pam(COR.dis, k=6)$clustering
plot(COR.pam, axis(side=1, at=c(1:18)),ylab = "Numer indexu", xlab = "Numer klastra")
axis(side=2, at=c(1:18))

