A = ones(9, 9) * 1/9;
A(1:7, end) = 0;
A(8:end, end) = 1/2;

x = ones(9, 1);

tolerance = 1e-10;
max_iterations = 1000;
lambda_previous = 0;

for i = 1:max_iterations
    x = A * x;

    x = x / norm(x, 2);

    lambda = x' * A * x;

    if abs(lambda - lambda_previous) < tolerance
        break;
    end

    lambda_previous = lambda;
end

c = 1/sum(x);
x = x * c;

disp(x);

