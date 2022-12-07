const podzial = (l, r) => {
  const p = l;
  let i = l - 1;
  let j = r + 1;

  while (i < j) {
    do {
      i++;
    } while (arr[i] < p);

    do {
      j--;
    } while (arr[j] > p);

    if (i < j) {
      // swap arr[i] and arr[j]
      const temp = arr[i];
      arr[i] = arr[j];
      arr[j] = temp;
    }
  }

  return j;
};

const arr = [1, 2, 3];

console.log(podzial(0, arr.length - 1));
