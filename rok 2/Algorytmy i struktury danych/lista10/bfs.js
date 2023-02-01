function bfs(graph, source) {
  let n = graph.length;
  let distances = new Array(n).fill(Infinity);
  let queue = [source];
  distances[source] = 0;

  while (queue.length > 0) {
    let current = queue.shift();
    for (let neighbor of graph[current]) {
      if (distances[neighbor] === Infinity) {
        distances[neighbor] = distances[current] + 1;
        queue.push(neighbor);
      }
    }
  }

  return distances;
}

// Example usage
let graph = bfs(n, edges);
let source = 0;
let distances = bfs(graph, source);
console.log(distances);
