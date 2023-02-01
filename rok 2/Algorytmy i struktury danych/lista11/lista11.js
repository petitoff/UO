// Funkcja tworząca szachownicę o podanych rozmiarach
function createChessboard(rows, columns) {
  const chessboard = [];
  for (let i = 0; i < rows; i++) {
    const row = [];
    for (let j = 0; j < columns; j++) {
      row.push(false);
    }
    chessboard.push(row);
  }
  return chessboard;
}

// Funkcja zwracająca listę ruchów konia szachowego z danego pola
function knightMoves(row, column) {
  const moves = [];
  moves.push([row - 2, column - 1]);
  moves.push([row - 2, column + 1]);
  moves.push([row - 1, column - 2]);
  moves.push([row - 1, column + 2]);
  moves.push([row + 1, column - 2]);
  moves.push([row + 1, column + 2]);
  moves.push([row + 2, column - 1]);
  moves.push([row + 2, column + 1]);
  return moves.filter((move) => {
    const [newRow, newColumn] = move;
    return (
      newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns
    );
  });
}

// Funkcja wyszukująca drogę konia szachowego
function findKnightPath(chessboard, start, end) {
  const path = [];
  const [startRow, startColumn] = start;
  const [endRow, endColumn] = end;
  const queue = [[startRow, startColumn]];
  while (queue.length > 0) {
    // Wyjęcie pierwszego elementu z kolejki 'queue' i przypisanie go do zmiennych 'row' i 'column'.
    const [row, column] = queue.shift();
    if (row === endRow && column === endColumn) {
      return path;
    }

    // Wywołanie funkcji 'knightMoves' z argumentami 'row' i 'column', która zwraca listę możliwych ruchów konia
    const moves = knightMoves(row, column);

    // Iteracja po wszystkich możliwych ruchach konia
    for (const move of moves) {
      const [newRow, newColumn] = move;
      // Sprawdzenie, czy pole na szachownicy o współrzędnych 'newRow' i 'newColumn' nie zostało jeszcze odwiedzone
      if (!chessboard[newRow][newColumn]) {
        // Ustawienie pola na szachownicy o współrzędnych 'newRow' i 'newColumn' jako odwiedzone
        chessboard[newRow][newColumn] = true;
        path.push([newRow, newColumn]);
        queue.push([newRow, newColumn]);
      }
    }
  }
  return null;
}

// Przykład użycia programu
const rows = 8;
const columns = 8;
const chessboard = createChessboard(rows, columns);
const start = [0, 0];
const end = [7, 7];
const path = findKnightPath(chessboard, start, end);
if (path === null) {
  console.log("Nie znaleziono drogi.");
} else {
  console.log("Znaleziona drogę:", path);
}
