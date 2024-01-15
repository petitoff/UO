% Definiowanie równania różniczkowego
dy = @(x, y) 2 * y;

% Exact solution
y_exact = @(x) 3 * exp(2 * x);

% Euler's Method function
function y_euler = euler_method(dy, x0, y0, h, n)
    y_euler = zeros(1, n + 1);
    y_euler(1) = y0;
    for i = 1:n
        y_euler(i + 1) = y_euler(i) + h * dy(x0 + h * (i - 1), y_euler(i));
    end
end

% Runge-Kutta Method function
function y_rk = runge_kutta_method(dy, x0, y0, h, n)
    y_rk = zeros(1, n + 1);
    y_rk(1) = y0;
    for i = 1:n
        k1 = dy(x0 + h * (i - 1), y_rk(i));
        k2 = dy(x0 + h * (i - 0.5), y_rk(i) + 0.5 * h * k1);
        k3 = dy(x0 + h * (i - 0.5), y_rk(i) + 0.5 * h * k2);
        k4 = dy(x0 + h * i, y_rk(i) + h * k3);
        y_rk(i + 1) = y_rk(i) + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
    end
end

% Interval [0, 1], initial conditions, and number of points
x0 = 0; y0 = 3;
n1 = 10; % For 11 points
n2 = 100; % For 101 points
h1 = 1 / n1;
h2 = 1 / n2;

% Calculate solutions
x1 = linspace(0, 1, n1 + 1);
x2 = linspace(0, 1, n2 + 1);
y_euler_1 = euler_method(dy, x0, y0, h1, n1);
y_euler_2 = euler_method(dy, x0, y0, h2, n2);
y_rk_1 = runge_kutta_method(dy, x0, y0, h1, n1);
y_rk_2 = runge_kutta_method(dy, x0, y0, h2, n2);

% Plotting
plot(x1, y_euler_1, 'r', x2, y_euler_2, 'b', x1, y_rk_1, 'g', x2, y_rk_2, 'm', x2, y_exact(x2), '--k');
legend('Euler 11 pts', 'Euler 101 pts', 'Runge-Kutta 11 pts', 'Runge-Kutta 101 pts', 'Exact Solution');
xlabel('x');
ylabel('y');
title('Porównanie metod Eulera i Rungego-Kutty z dokładnym rozwiązaniem');

