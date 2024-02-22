library("TSclust")
library("cluster")

data("synthetic.tseries")
View(synthetic.tseries)

matplot(synthetic.tseries, type = "l", lty = 1:6, col = c("black", "blue", "green", "red", "pink", "purple"))

EUCL.dis<-diss(synthetic.tseries, "EUCL")
FRECHET.dis<-diss(synthetic.tseries, "FRECHET")
DTW.dis<-diss(synthetic.tseries, "DTW")
CORT.dis<-diss(synthetic.tseries, "CORT")

EUCL.hclust <- hclust(EUCL.dis)
FRECHET.hclust <- hclust(FRECHET.dis)
DTW.hclust <- hclust(DTW.dis)
CORT.hclust <- hclust(CORT.dis)

EUCL.pam<-pam(EUCL.dis, k=6)$clustering
FRECHET.pam<-pam(FRECHET.dis, k=6)$clustering
DTW.pam<-pam(DTW.dis, k=6)$clustering
CORT.pam<-pam(CORT.dis, k=6)$clustering

EUCL.hclust <- cutree(hclust(EUCL.dis), k=6)
FRECHET.hclust <- cutree(hclust(FRECHET.dis), k=6)
DTW.hclust <- cutree(hclust(DTW.dis), k=6)
CORT.hclust <- cutree(hclust(CORT.dis), k=6)

true_cluster <- rep(1:6, each = 3)

EUCL.hclust.ce=cluster.evaluation(true_cluster, EUCL.hclust)
FRECHET.hclust.ce=cluster.evaluation(true_cluster, FRECHET.hclust)
DTW.hclust.ce=cluster.evaluation(true_cluster, DTW.hclust)
CORT.hclust.ce=cluster.evaluation(true_cluster, CORT.hclust)

EUCL.pam.ce=cluster.evaluation(true_cluster, EUCL.pam)
FRECHET.pam.ce=cluster.evaluation(true_cluster, FRECHET.pam)
DTW.pam.ce=cluster.evaluation(true_cluster, DTW.pam)
CORT.pam.ce=cluster.evaluation(true_cluster, CORT.pam)

df <- data.frame(
  Method = rep(c("EUCL.hclust", "FRECHET.hclust", "DTW.hclust", "CORT.hclust", "EUCL.pam", "FRECHET.pam", "DTW.pam", "CORT.pam")),
  Clustering = c(EUCL.hclust.ce, FRECHET.hclust.ce, DTW.hclust.ce, CORT.hclust.ce, EUCL.pam.ce, FRECHET.pam.ce, DTW.pam.ce, CORT.pam.ce)
)

barplot(df$Clustering, names.arg = df$Method, xlab = "Metoda", ylab = "Efektywność", main = "Efektywnośc grupowania dla każdej metody",ylim=c(0,1))
