function generateGraph(n, p) {
  let edges = [];
  for (let i = 0; i < n; i++) {
    for (let j = i + 1; j < n; j++) {
      if (Math.random() < p) {
        edges.push([i, j]);
      }
    }
  }
  return createGraph(n, edges);
}

let n = 1000;
let p = 0.01;
let graph = generateGraph(n, p);
console.log(graph);
