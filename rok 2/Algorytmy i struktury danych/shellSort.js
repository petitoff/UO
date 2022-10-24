function shellSort(arr) {
  let n = arr.length;

  for (let gap = Math.floor(n / 2); gap > 0; gap = Math.floor(gap / 2)) {
    for (let i = gap; i < n; i += 1) {
      let curr = arr[i];

      let j;
      for (j = i; j >= gap && arr[j - gap] > curr; j -= gap) {
        arr[j] = arr[j - gap];
      }

      arr[j] = curr;
    }
  }

  return arr;
}

console.log(shellSort([25, 1, 5, 3]));
