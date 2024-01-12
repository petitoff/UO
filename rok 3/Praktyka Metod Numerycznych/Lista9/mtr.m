function result = mtr(f, a, b, n)
    % Trapezoidal Rule for numerical integration
    result = 0;
    h = (b - a) / n; % Step size

    x = linspace(a, b, n + 1); % Generate equally spaced points
    y = f(x); % Evaluate the function at each point

    % Calculate the integral using trapezoidal rule
    result = sum((y(1:end-1) + y(2:end)) / 2 * h);
end

