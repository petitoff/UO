const roundNumber = (num) => {
  return Math.round((num + Number.EPSILON) * 100) / 100;
};

const insertionSort = (arr = []) => {
  const startTime = performance.now();
  let numbersOfComparisons = 0;

  for (let i = 1; i < arr.length; i++) {
    const curr = arr[i];
    j = i - 1;

    while (j >= 0 && arr[j] > curr) {
      numbersOfComparisons++;
      arr[j + 1] = arr[j];
      j--;
    }
    arr[j + 1] = curr;
  }

  const endTime = performance.now();
  var seconds = ((endTime - startTime) % 60000) / 1000;
  console.log(`Call took ${roundNumber(endTime - startTime)} milliseconds`);
  console.log(`Call took ${roundNumber(seconds)} seconds`);

  console.log(`Liczba porównań: ${numbersOfComparisons}`);
  console.log(
    `Średnia wartość: ${numbersOfComparisons / Math.pow(arr.length, 2)}`
  );

  return arr;
};

const arr = Array.from({ length: 10000 }, () =>
  Math.floor(Math.random() * 1000)
);

const sample1 = [9, 5, 16, 8, 13, 6, 12, 10, 4, 2, 3];
console.log(insertionSort(arr));

// T: O(n^2)
