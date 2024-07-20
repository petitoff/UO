rm(list=ls())             # Clears all Environment Variables
cat("\014")               # Clears console ctrl-L

Sys.setenv(LANG = "en")
library(dplyr)
library(tidyr)
library(rpart)
library(rpart.plot)
library(caret)


# Wczytanie danych
# d1=read.table("student-mat.csv",sep=";",header=TRUE)
# d2=read.table("student-por.csv",sep=";",header=TRUE)
d1 <- read.table("C:/Users/petit/Desktop/repos/uo/rok 3/Sztuczna inteligencja/DrzewaDecyzyjne - students/student-mat.csv", sep = ";", header = TRUE)
d2 <- read.table("C:/Users/petit/Desktop/repos/uo/rok 3/Sztuczna inteligencja/DrzewaDecyzyjne - students/student-por.csv", sep = ";", header = TRUE)



d1_d2 <- bind_rows(d1, d2) #merge two dataframes
d1_d2 <- select(d1_d2, -G1, -G2) #remove G1 and G2 (napisz dlaczego??)
d1_d2$G3 <- factor(ifelse(d1_d2$G3 >= 10, 1, 0), labels = c("fail", "pass")) #replace marks on scale 1..20 to binary pass >=10 or fail <10
str(d1_d2) #check for data type
d1_d2 <- mutate_if(d1_d2, is.character, as.factor) #replace character type of data with factor type of data
str(d1_d2)

#split into train and test sets
set.seed(3456)
trainIndex <- createDataPartition(d1_d2$G3, p = 0.75, list = FALSE, times = 1)
sTrain <- d1_d2[ trainIndex,]
sTest <- d1_d2[-trainIndex,]

#make ML model
#-minsplit: minimum number of observations in the node before the algorithm perform a split
#-maxdepth: maximum depth of any node of the final tree. The root node is treated a depth 0
#-xval: number of cross-validations
#-cp: complexity parameter

#create tree with xval-fold cross validation
dt_control <- rpart.control(maxdepth = 25, xval = 10, cp = 0)
d1_tree <- rpart(G3~., data = sTrain, method = "class", control = dt_control, minsplit = 20) #<-- Tree

#select optimal cp parameter value (try parameters below the dashed line)
printcp(d1_tree)
plotcp(d1_tree)

#prune tree with chosen parameter cp, plot pruned tree
d1_tree <- prune(d1_tree, cp = 0.02)
rpart.plot(d1_tree, extra=101, fallen.leaves = FALSE, tweak = 1.0, varlen = 10, faclen = 10)

#test the pruned tree performance
d1_tree_predict <- predict(d1_tree, sTest, type="class")
confusionMatrix(table(d1_tree_predict, sTest$G3))
