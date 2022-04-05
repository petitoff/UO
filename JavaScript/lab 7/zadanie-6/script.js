const numbers = [2, 5, 7, 10, 34, 16, 879, 1];
const numbersEven = [];

for (const i of numbers) {
  if (i % 2 === 0) numbersEven.push(i);
}

console.log(numbersEven);
