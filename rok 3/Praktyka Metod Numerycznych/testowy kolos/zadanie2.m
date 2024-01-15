% Matrix from task 1
B = [0.9, 0.1; 0.2, 0.9];

% Power method for the largest eigenvalue and corresponding eigenvector
function [eigenvalue, eigenvector, iterations] = power_method(A, tol, max_iter)
  n = size(A, 1);
  eigenvector = rand(n, 1);
  eigenvector = eigenvector / norm(eigenvector, 2);
  for iterations = 1:max_iter
    w = A * eigenvector;
    eigenvalue = max(abs(w));
    eigenvector = w / eigenvalue;
    error = norm(A * eigenvector - eigenvalue * eigenvector, 2);
    if error < tol
      break;
    end
  end
end

% Inverse power method for the smallest eigenvalue and corresponding eigenvector
function [eigenvalue, eigenvector, iterations] = inverse_power_method(A, tol, max_iter)
  n = size(A, 1);
  eigenvector = rand(n, 1);
  eigenvector = eigenvector / norm(eigenvector, 2);
  for iterations = 1:max_iter
    w = A \ eigenvector;
    eigenvalue = 1 / max(abs(w));
    eigenvector = w / norm(w, 2);
    error = norm(A * eigenvector - 1 / eigenvalue * eigenvector, 2);
    if error < tol
      break;
    end
  end
end

% Tolerance and maximum number of iterations
tolerance = 1e-6;
max_iterations = 1000;

% Calculate the largest eigenvalue and corresponding eigenvector
[largest_eigenvalue, largest_eigenvector, iter1] = power_method(B, tolerance, max_iterations);

% Calculate the smallest eigenvalue and corresponding eigenvector
[smallest_eigenvalue, smallest_eigenvector, iter2] = inverse_power_method(B, tolerance

, max_iterations);

% Display the results
disp("Największa wartość własna i odpowiadający jej wektor własny metoda potęgowa:");
disp(["Wartość własna: ", num2str(largest_eigenvalue)]);
disp("Wektor własny:");
disp(largest_eigenvector);

disp("Najmniejsza wartość własna i odpowiadający jej wektor własny odwrotna metoda potęgowa:");
disp(["Wartość własna: ", num2str(smallest_eigenvalue)]);
disp("Wektor własny:");
disp(smallest_eigenvector);

% Using the results to approximate the spectral radius
spectral_radius = max(abs(largest_eigenvalue), abs(smallest_eigenvalue));
disp(["Promień spektralny macierzy B wynosi: ", num2str(spectral_radius)]);

