var events = require("events");
var emiter = new events.EventEmitter();
emiter.on("useRegistered", showGreetings);

function showGreetings() {
  console.log("Witaj w naszym serwisie");
}

emiter.emit("useRegistered");
emiter.emit("useRegistered");
emiter.emit("useRegistered");
