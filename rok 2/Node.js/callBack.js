setTimeout(function () {
  console.log("Hello from callback function");
}, 1000);

setTimeout(() => {
  console.log("Hello from callback arrow function");
}, 1000);

const callback = () => console.log("Hello from expression arrow function");
setTimeout(callback, 1000);

const callback2 = function () {
  console.log("Hello from expression function");
};
setTimeout(callback2, 1000);

const list = [1, 2, 3].map((e) => e * 2);
console.log(list);

const handleResponse = (data) => console.log(data);

function handleError(error) {
  console.log("Some error: ", error);
}

function calculator(a, b, callback) {
  const result = callback(a, b);
  console.log(result);
}

const add = (a, b) => a + b;

const sub = (a, b) => a - b;

calculator(1, 3, add);
calculator(1, 3, sub);
