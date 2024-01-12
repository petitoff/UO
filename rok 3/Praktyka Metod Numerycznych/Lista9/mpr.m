function result = mpr(f, a, b, n)
    result = 0;
    h = (b - a) / n;
    x = a;

    sum_result = 0;
    for i = 1:n
        sum_result = sum_result + f(x);
        x = x + h;
    end

    result = h * sum_result;
end
