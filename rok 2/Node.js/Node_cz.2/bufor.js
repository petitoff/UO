const buf1 = new Buffer("this is a test");
console.log(buf1.toString());

console.log(buf1.toString("ascii"));

const buf2 = new Buffer("12352352a", "hex");
console.log(buf2.toString());

// var bufer = new Buffer("Bufor");
// console.log(bufer);

// var bufer = new Buffer("Bufor");
// console.log(bufer.toString());

// var bufer = new Buffer("Bufor");
// console.log(bufer.toJSON());

// var bufer = new Buffer("Bufor");
// console.log(bufer[0]);

// var bufer = new Buffer("Bufor");
// bufer.write("abcde");
// console.log(bufer.toString());
