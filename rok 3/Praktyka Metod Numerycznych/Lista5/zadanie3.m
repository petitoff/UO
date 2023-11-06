% Define the matrix A
A = ones(9, 9) * 1/9;
A(1:7, end) = 0;
A(8:end, end) = 1/2;

% Perform Singular Value Decomposition
[U, S, V] = svd(A);

% Find the smallest singular value and its corresponding singular vector
[minSingularValue, minIndex] = min(diag(S))
u = U(:, minIndex)
v = V(:, minIndex)

% The matrix with the smallest norm is the outer product of u and v
% scaled by the smallest singular value
A_min_norm = minSingularValue * (u * v')

