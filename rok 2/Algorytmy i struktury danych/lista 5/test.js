function quickSort(arr, lo, hi) {
  if (lo >= 0 && hi >= 0 && lo < hi) {
    const p = partition(arr, lo, hi);
    quickSort(arr, lo, p);
    quickSort(arr, p + 1, hi);
  }
}

function partition(arr, lo, hi) {
  const pivot = arr[Math.floor((lo + hi) / 2)];
  let i = lo - 1;
  let j = hi + 1;
  while (true) {
    do {
      i++;
    } while (arr[i] < pivot);

    do {
      j--;
    } while (arr[j] > pivot);

    if (i >= j) {
      return j;
    }

    swap(arr, i, j);
  }
}

function swap(arr, i, j) {
  const tmp = arr[i];
  arr[i] = arr[j];
  arr[j] = tmp;
}

let arr = [9, 4, 1, 6, 7, 3, 8, 2, 5];
console.log(quickSort(arr, 0, arr.length - 1));
