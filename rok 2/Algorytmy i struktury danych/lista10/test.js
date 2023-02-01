function createGraph(n, edges) {
  // Initialize an array of empty lists to represent the adjacency list
  let adjList = new Array(n).fill(null).map(() => []);

  // Add edges to the adjacency list
  for (let i = 0; i < edges.length; i += 2) {
    let v1 = edges[i] - 1;
    let v2 = edges[i + 1] - 1;
    if (v1 == 0 && v2 == 0) break;
    if (v1 < 0 || v1 >= n || v2 < 0 || v2 >= n) continue;
    adjList[v1].push(v2);
    adjList[v2].push(v1);
  }

  return adjList;
}

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

// Example usage
let n = 5;
let edges = [1, 2, 2, 3, 3, 4, 4, 5, 0, 0];
let graph = createGraph(n, edges);
console.log(graph);

let source = 0;
let distances = bfs(graph, source);
console.log(distances);

let xx = 1000;
let p = 0.01;
let graph2 = generateGraph(n, p);
console.log(graph2);
