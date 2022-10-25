function shellSort(arr = []) {
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

  console.log(`Liczba porównań: ${numbersOfComparisons}`);
  console.log(
    `Średnia wartość: ${numbersOfComparisons / Math.pow(arr.length, 2)}`
  );
  return arr;
}

const arr = Array.from({ length: 10000 }, () =>
  Math.floor(Math.random() * 1000)
);

const sample1 = [9, 5, 16, 8, 13, 6, 12, 10, 4, 2, 3];

console.log(shellSort(arr));
