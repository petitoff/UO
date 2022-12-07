let numberOfComparisons = 0;

function mergeSort(array) {
  if (array.length === 1) {
    return array;
  }

  // Divide and Conqure (split array to one item)
  const length = array.length;
  const middleIndex = Math.floor(length / 2);
  const left = array.slice(0, middleIndex);
  const right = array.slice(middleIndex, length);

  // Split Array in into right and left
  return merge(mergeSort(left), mergeSort(right));
}

function merge(left, right) {
  const newArray = [];
  const length = left.length + right.length;
  let leftIndex = 0;
  let rightIndex = 0;
  while (newArray.length < length) {
    numberOfComparisons++;
    if (right.length === rightIndex || left[leftIndex] < right[rightIndex]) {
      newArray.push(left[leftIndex]);
      leftIndex++;
    } else {
      newArray.push(right[rightIndex]);
      rightIndex++;
    }
  }
  return newArray;
}

const randomNumbers = 100000;
const array = Array.from({ length: randomNumbers }, () =>
  Math.floor(Math.random() * randomNumbers)
);

const array2 = [12, 11, 13, 5, 6, 7];

let numbers = array;
// start time
const start = new Date().getTime();
console.log(mergeSort(numbers));
// end time
const end = new Date().getTime();
console.log(`Time taken: ${(end - start) / 1000} seconds`);
console.log(numberOfComparisons);
console.log(
  `c: ${numbers.length / (numbers.length * Math.log2(numbers.length))}`
);
