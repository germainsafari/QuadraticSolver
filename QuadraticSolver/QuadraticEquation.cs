namespace QuadraticSolver
{
    public class QuadraticEquation
    {
        public record QuadraticRoots(int RootCount, double? Root1, double? Root2);

        public static QuadraticRoots Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Coefficient 'a' cannot be zero - this would make the equation linear");
            }

            double discriminant = (b * b) - (4 * a * c);

            if (discriminant < 0)
            {
                return new QuadraticRoots(0, null, null);
            }

            if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return new QuadraticRoots(1, root, null);
            }

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double root1 = (-b + sqrtDiscriminant) / (2 * a);
            double root2 = (-b - sqrtDiscriminant) / (2 * a);

            return new QuadraticRoots(2, root1, root2);
        }
    }
}