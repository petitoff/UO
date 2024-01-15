% Stałe
R = 8.3145; % J/(mol*K)
P = 1.0133e5; % N/m^2
T = 303; % Kelvin
N = 0.22722; % mol
a = 0.364e-12; % J*m^3/mol^2
b = 42.67e-6; % m^3/mol

% Definicja funkcji
fun = @(V) (a*b*N^3 - a*N^2*V + b*N*P*V^2 + N*R*T*V^2 - P*V^3);

% Wartości początkowe i obliczenia
v_guess = 0.1;
c2 = [-P, N*R*T + b*N*P, -a*N^2, a*b*N^3];
roots_vals = roots(c2);
[V_sol, fzp, info, out] = fzero(fun, v_guess);

% Wyświetlanie wyników
for V = roots_vals'
    disp(['Dla V = ', num2str(V), ', wynik: ', num2str((P + (N^2*a)/V^2)*(V-N*b) - N*R*T)]);
end

