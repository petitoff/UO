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

      console.log("====================================");
      console.log(arr);
      console.log("====================================");
    }
  }

  console.log(`Liczba porównań: ${numbersOfComparisons}`);
  console.log(
    `Średnia wartość: ${
      Math.round((numbersOfComparisons / Math.pow(arr.length, 2)) * 100) / 100
    }`
  );
  return arr;
}

console.log(shellSort([8, 2, 4, 1, 3]));
