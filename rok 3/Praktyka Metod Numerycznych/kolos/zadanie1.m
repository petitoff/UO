B = [1, -0.1; 0.1, 1.1];

I = eye(2);
A = I - B;
Neumann_series_sum = I;

for n = 1:5
    Neumann_series_sum += A^n;
end
Neumann_series_sum
norm_A = norm(A)

if norm_A < 1
    disp('Założenia twierdzenia o szeregu Neumanna są spełnione.')
else
    disp('Założenia twierdzenia o szeregu Neumanna nie są spełnione.')
end
