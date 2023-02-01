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

// Example usage
let n = 5;
let edges = [5, 1, 2, 2, 3, 3, 4, 4, 5, 0, 0];
let graph = createGraph(n, edges);
console.log(graph);
// Output: [ [ 4 ], [ 1, 1 ], [ 2, 2 ], [ 3, 3 ], [ 0 ] ]
