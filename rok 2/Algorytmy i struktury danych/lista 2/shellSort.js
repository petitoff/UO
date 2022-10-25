const printArray = (arr = [], howManyElements) => {
  console.log("====================================");
  arr.slice(0, howManyElements).forEach((element) => {
    console.log(element);
  });
  console.log("====================================");
};

const roundNumber = (num) => {
  return Math.round((num + Number.EPSILON) * 100) / 100;
};

function shellSort(arr = []) {
  printArray(arr, 50);
  const startTime = performance.now();
  if (arr.length == 0) {
    console.log("====================================");
    console.log("Tablica nie może być pusta!");
    console.log("====================================");
    return;
  }

  let numbersOfComparisons = 0;
  let n = arr.length;

  for (let gap = Math.floor(n / 2); gap > 0; gap = Math.floor(gap / 2)) {
    for (let i = gap; i < n; i += 1) {
      let curr = arr[i];

      let j;
      for (j = i; j >= gap && arr[j - gap] > curr; j -= gap) {
        numbersOfComparisons++;
        arr[j] = arr[j - gap];
      }

      arr[j] = curr;
    }
  }

  const endTime = performance.now();
  var seconds = ((endTime - startTime) % 60000) / 1000;
  console.log(`Call took ${roundNumber(endTime - startTime)} milliseconds`);
  console.log(`Call took ${roundNumber(seconds)} seconds`);

  console.log(`Number of comparisons: ${numbersOfComparisons}`);
  console.log(
    `Average value: ${numbersOfComparisons / Math.pow(arr.length, 2)}`
  );

  printArray(arr, 50);
  return arr;
}

const arr = Array.from({ length: 10000 }, () =>
  Math.floor(Math.random() * 1000)
);

const sample1 = [9, 5, 16, 8, 13, 6, 12, 10, 4, 2, 3];

console.log(shellSort(arr));
