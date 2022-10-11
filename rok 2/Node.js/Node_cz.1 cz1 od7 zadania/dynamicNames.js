var events = require("events");
var emiter = new events.EventEmitter();

emiter.on("useRegistered", (userName) => {
  console.log(`${userName}: Witaj w naszym świecie`);
});

emiter.emit("useRegistered", "Ksawery");
