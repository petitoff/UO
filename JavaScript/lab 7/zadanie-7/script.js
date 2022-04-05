const person = { name: "Jill", age: 25, hobby: "sports" };

const sayHello = function (person) {
  person["name"] !== undefined
    ? console.log(`Hello ${person.name}!`)
    : console.log("Hello!");
};

sayHello(person);
