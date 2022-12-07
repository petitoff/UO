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

const wybor = (l, r, k) => {
  if (l < r) {
    const j = podzialLos(l, r);
    const m = j - l + 1;
    if (k <= m) {
      wybor(l, j, k);
    } else {
      wybor(j + 1, r, k - m);
    }
  } else {
    console.log(arr);
    return arr[l];
  }
};

const podzialLos = (l, r) => {
  const i = Math.random(l, r);

  // swap arr[l] and arr[i]
  const temp = arr[l];
  arr[l] = arr[i];
  arr[i] = temp;

  return podzial(l, r);
};

const swap = (arr, i, j) => {
  const temp = arr[i];
  arr[i] = arr[j];
  arr[j] = temp;
};

// const arr = [10, 9, 12, 9, 6, 10, 1, 15, 17, 14];
const arr = [1, 2, 3];

console.log(wybor(0, arr.length - 1, 3));

// console.log(podzial(0, arr.length - 1));
