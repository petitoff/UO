# P(xi = null) = P(k0/0z) * P(0z) + P(k0/1z) * P(001)

xi <- 0:6
pi <- c(1,3,5,3,5,3,4)/24
EXi <- sum(xi*pi)
EXi.2 <- sum(xi^2*pi)
D2x <- EXi.2 - EXi^2

sigma <- sqrt(D2x)
N <- floor((10*sigma * qnorm(0.95,0,1))^2)+1

# Krok 1. Znajdziemy rozkład prawdopodobieństwa zmiennej losowej xi,
# oznaczającej wynik na wylosowanej kostce


# P(xi=0) = P(K_0 | o_2) * P(o_2) + P(k_0/o_01) * P(o_01) = 1/6*1/4+0*3/4

