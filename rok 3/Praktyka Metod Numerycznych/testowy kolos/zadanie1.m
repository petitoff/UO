% Define the matrix B
B = [0.9 0.1; 0.2 0.9];

% Calculate the inverse of B
B_inv = inv(B);

% Calculate the sum of the first five terms of the Neumann series
I = eye(2); % Identity matrix
Neumann_series_sum = I + B + B^2 + B^3 + B^4;

% Display the calculated inverse and Neumann series sum
disp("Inverse of B:");
disp(B_inv);

disp("Sum of the first five terms of the Neumann series:");
disp(Neumann_series_sum);

