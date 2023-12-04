f = @(x) x.^2;
a = 0;
b = 1;
n = 100;

## Wywołanie Metody Prostokąta Środkowego:
integral_midpoint = midpoint_rule(f, a, b, n)

##Wywołanie Metody Trapezów:
integral_trapezoidal = trapezoidal_rule(f, a, b, n)

##Wywołanie Metody Mieszanej:
integral_composite = composite_midpoint_trapezoidal_rule(f, a, b, n)


