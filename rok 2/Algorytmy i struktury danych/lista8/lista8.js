const queru = require("readline-sync");

// Informacja jak poprawnie uruchomić program
// JavaScript nie wspiera domyślnie czytania z klawiatury, dlatego musimy użyć dodatkowej biblioteki.
// W tym programie używam biblioteki cli-interact, która jest dostępna w npm.
// Aby uruchomić program, należy wpisać w konsoli: yarn
// Bądź: npm install
// A następnie: node lista_8.js
// Należy mieć zainstalowanego Node.js oraz Yarn lub NPM.

let tree = null;

const BstINORDER = (root) => {
  // create a stack to hold the nodes we need to process
  const stack = [];

  // create a reference to the current node and set it to the root node
  let current = root;

  // continue processing nodes as long as there are nodes to process or the current node is not null
  while (stack.length > 0 || current !== null) {
    // if the current node is not null, add it to the stack and move to the left subtree
    if (current !== null) {
      stack.push(current);
      current = current.left;
    } else {
      // if the current node is null, pop the top node from the stack and print its value
      current = stack.pop();
      console.log(current.value);

      // move to the right subtree
      current = current.right;
    }
  }
};

const BSTInsert = (tree, value) => {
  // Jeśli drzewo jest puste, dodajemy nowy węzeł jako korzeń drzewa
  if (tree === null) {
    tree = { value: value, left: null, right: null };
  } else {
    // W przeciwnym razie przeszukujemy drzewo, aby znaleźć odpowiednie miejsce dla nowego węzła
    let currentNode = tree;
    while (currentNode !== null) {
      if (value < currentNode.value) {
        // Jeśli wartość jest mniejsza niż wartość węzła, przechodzimy do lewego potomka
        if (currentNode.left === null) {
          currentNode.left = { value: value, left: null, right: null };
          break;
        } else {
          currentNode = currentNode.left;
        }
      } else {
        // Jeśli wartość jest większa lub równa wartości węzła, przechodzimy do prawego potomka
        if (currentNode.right === null) {
          currentNode.right = { value: value, left: null, right: null };
          break;
        } else {
          currentNode = currentNode.right;
        }
      }
    }
  }
  return tree;
};

const isMember = (root, value) => {
  // base case: if the root node is null, the value is not in the tree
  if (root === null) {
    return false;
  }

  // if the value is equal to the value at the root node, return true
  if (value === root.value) {
    return true;
  }

  // if the value is less than the value at the root node, check the left subtree
  if (value < root.value) {
    return isMember(root.left, value);
  } else {
    // if the value is greater than the value at the root node, check the right subtree
    return isMember(root.right, value);
  }
};

const findMax = (root) => {
  // base case: if the root node is null, there are no values in the tree
  if (root === null) {
    return null;
  }

  // if the right subtree is null, the value at the root node is the maximum value
  if (root.right === null) {
    return root.value;
  } else {
    // if the right subtree is not null, the maximum value is in the right subtree
    return findMax(root.right);
  }
};

const findMin = (root) => {
  // base case: if the root node is null, there are no values in the tree
  if (root === null) {
    return null;
  }

  // if the left subtree is null, the value at the root node is the minimum value
  if (root.left === null) {
    return root.value;
  } else {
    // if the left subtree is not null, the minimum value is in the left subtree
    return findMin(root.left);
  }
};

const deleteNode = (localTree, value) => {
  if (!localTree) return null;

  if (value < localTree.val) {
    localTree.left = deleteNode(localTree.left, value);
  } else if (value > localTree.val) {
    localTree.right = deleteNode(localTree.right, value);
  } else {
    if (!localTree.left && !localTree.right) {
      localTree = null;
    } else if (!localTree.right) {
      localTree = localTree.left;
    } else if (!localTree.left) {
      localTree = localTree.right;
    } else {
      let successor = findSuccessor(localTree);
      localTree.val = successor.val;
      localTree.right = deleteNode(localTree.right, successor.val);
    }
  }

  return localTree;
};

const findSuccessor = (node) => {
  if (node.right) {
    node = node.right;
    while (node.left) {
      node = node.left;
    }
    return node;
  } else {
    while (node.parent && node === node.parent.right) {
      node = node.parent;
    }
    return node.parent;
  }
};

const mainFunction = () => {
  console.log("Lista 7");
  console.log("=====================================\n");
  while (true) {
    console.log("\n1. Wyswietl drzewo");
    console.log("2. Dodaj element");
    console.log("3. Szukaj elementu");
    console.log("4. Znajdz maksymalny element");
    console.log("5. Znajdz minimalny element");
    console.log("6. Usun element");
    console.log("7. Zamknij program");
    const choice = queru.question("Wybierz opcje: ");
    console.log();

    switch (choice) {
      case "1":
        console.log("Wyswietlam drzewo");
        BstINORDER(tree);
        break;
      case "2":
        console.log("Dodaje element");
        const value1 = Number(queru.question("Podaj wartosc: "));
        tree = BSTInsert(tree, value1);
        break;
      case "3":
        console.log("Szukam elementu");
        const value2 = Number(queru.question("Podaj wartosc: "));
        console.log(isMember(tree, value2) ? "Znaleziono" : "Nie znaleziono");
        break;
      case "4":
        console.log("Znajduje maksymalny element");
        console.log(findMax(tree));
        break;
      case "5":
        console.log("Znajduje minimalny element");
        console.log(findMin(tree));
        break;
      case "6":
        console.log("Usuwanie elementu");
        const value4 = Number(queru.question("Podaj wartosc: "));
        tree = deleteNode(tree, value4);
        break;
      case "7":
        console.log("Zamykam program");
        process.exit();
        break;
      default:
        console.log("Nie ma takiej opcji");
        break;
    }
  }
};

mainFunction();
