const findBiggestNumber = (numbers) => {
  if (numbers.length === 0) {
    return "error";
  }

  let result = numbers[0];
  numbers.forEach((number) => {
    if (result < number) {
      result = number;
    }
  });

  return result;
};

console.log("====================================");
console.log(findBiggestNumber([5, 4, 7, 1, 5]));
console.log("====================================");
