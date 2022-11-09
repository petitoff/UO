let numbersOfComparisons = 0;

const buildMaxHeap = (arr) => {
  // Get index of the middle element
  let i = Math.floor(arr.length / 2 - 1);

  // Build a max heap out of
  // All array elements passed in
  while (i >= 0) {
    heapify(arr, i, arr.length);
    i -= 1;
  }
};

const heapify = (heap, i, max) => {
  let index;
  let leftChild;
  let rightChild;

  while (i < max) {
    index = i;
    numbersOfComparisons++;

    // Get the left child index
    // Using the known formula
    leftChild = 2 * i + 1;

    // Get the right child index
    // Using the known formula
    rightChild = leftChild + 1;

    // If the left child is not last element
    // And its value is bigger
    if (leftChild < max && heap[leftChild] > heap[index]) {
      index = leftChild;
    }

    // If the right child is not last element
    // And its value is bigger
    if (rightChild < max && heap[rightChild] > heap[index]) {
      index = rightChild;
    }

    // If none of the above conditions is true
    // Just return
    if (index === i) {
      return;
    }

    // swap elements
    swap(heap, i, index);

    // Continue by using the swapped index
    i = index;
  }
};

const swap = (arr, firstItemIndex, lastItemIndex) => {
  // swap index of arr with lastItemIndex and firstItemIndex
  [arr[firstItemIndex], arr[lastItemIndex]] = [
    arr[lastItemIndex],
    arr[firstItemIndex],
  ];
};

const heapSort = (arr) => {
  // Build max heap
  buildMaxHeap(arr);

  // Get the index of the last element
  let lastElement = arr.length - 1;

  // Continue heap sorting until we have
  // One element left
  while (lastElement > 0) {
    swap(arr, 0, lastElement);
    heapify(arr, 0, lastElement);
    lastElement -= 1;
  }

  console.log(`Liczba porównań: ${numbersOfComparisons}`);
  console.log(
    `Średnia wartość: ${
      numbersOfComparisons / (arr.length * Math.log2(arr.length))
    }`
  );

  // Return sorted array
  return arr;
};

const arr = [9, 6, 8, 2, 1, 4, 3];

console.log(heapSort(arr));

// T: O(n log n)
// S: O(1)
