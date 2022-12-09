let numberOfComparisons = 0;

const partion = (array, left, right) => {
  const pivot = array[left];
  let i = left - 1;
  let j = right + 1;

  while (i < j) {
    do {
      j--;
      numberOfComparisons++;
    } while (array[j] > pivot);

    do {
      i++;
      numberOfComparisons++;
    } while (array[i] < pivot);

    if (i < j) {
      // swap array[i] and array[j]
      let temp = array[i];
      array[i] = array[j];
      array[j] = temp;
    }
  }

  return j;
};

const partionRandom = (array, left, right) => {
  const i = Math.random(left, right + 1);
  // swap array[i] and array[left]
  let temp = array[i];
  array[i] = array[left];
  array[left] = temp;

  temp = partion(array, left, right);
  return temp;
};

const hoareChoice = (array, left, right, k) => {
  if (left < right) {
    const j = partionRandom(array, left, right);
    const m = j - left + 1;

    if (k <= m) {
      return hoareChoice(array, left, j, k);
    } else {
      return hoareChoice(array, j + 1, right, k - m);
    }
  } else {
    return array[left];
  }
};

const hoareAlgorithm = (array, k) => {
  const n = array.length;

  if (n <= 100) {
    for (let i = 0; i < n; i++) {
      console.log(array[i]);
    }
  }

  if (n > 100) {
    for (let i = 0; i < n; i++) {
      console.log(array[i]);
    }
  }

  let left = 0;
  let right = n - 1;

  const result = hoareChoice(array, left, right, k, 0);

  return result;
};

const randomNumbers = 100000;
const array = Array.from({ length: randomNumbers }, () =>
  Math.floor(Math.random() * randomNumbers)
);

const array2 = [-146, -642, -239, -850, 127];

let numbers = array2;

const start = new Date().getTime();
console.log(`Wynik: ${hoareAlgorithm(numbers, 0)}`);

const end = new Date().getTime();
console.log(`Time taken: ${(end - start) / 1000} seconds`);
console.log(`liczba porównań: ${numberOfComparisons}`);
console.log(`t/n: ${numberOfComparisons / numbers.length}`);
