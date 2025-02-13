using QuadraticSolver;

Console.WriteLine("Quadratic Equation Solver (ax² + bx + c = 0)");

Console.Write("Enter a: ");
double a = double.Parse(Console.ReadLine()!);

Console.Write("Enter b: ");
double b = double.Parse(Console.ReadLine()!);

Console.Write("Enter c: ");
double c = double.Parse(Console.ReadLine()!);

try
{
    var result = QuadraticEquation.Solve(a, b, c);

    switch (result.RootCount)
    {
        case 0:
            Console.WriteLine("No real roots exist.");
            break;
        case 1:
            Console.WriteLine($"One root exists: x = {result.Root1}");
            break;
        case 2:
            Console.WriteLine($"Two roots exist: x₁ = {result.Root1}, x₂ = {result.Root2}");
            break;
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}