using Xunit;

namespace QuadraticSolver.Tests
{
    public class QuadraticEquationTests
    {
        [Fact]
        public void Solve_WhenAIsZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 0;
            double b = 2;
            double c = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => QuadraticEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(1, 2, 3)]    // x² + 2x + 3 = 0
        [InlineData(1, 0, 1)]    // x² + 1 = 0
        public void Solve_WhenDiscriminantNegative_ReturnsNoRoots(double a, double b, double c)
        {
            // Act
            var result = QuadraticEquation.Solve(a, b, c);

            // Assert
            Assert.Equal(0, result.RootCount);
            Assert.Null(result.Root1);
            Assert.Null(result.Root2);
        }

        [Theory]
        [InlineData(1, 2, 1)]     // x² + 2x + 1 = 0 -> x = -1
        [InlineData(1, -4, 4)]    // x² - 4x + 4 = 0 -> x = 2
        public void Solve_WhenDiscriminantZero_ReturnsOneRoot(double a, double b, double c)
        {
            // Act
            var result = QuadraticEquation.Solve(a, b, c);

            // Assert
            Assert.Equal(1, result.RootCount);
            Assert.NotNull(result.Root1);
            Assert.Null(result.Root2);

            // Verify the root is correct by substituting back into equation
            double x = result.Root1.Value;
            Assert.Equal(0, a * x * x + b * x + c, precision: 8);
        }

        [Theory]
        [InlineData(1, 5, 6)]     // x² + 5x + 6 = 0 -> x = -2, -3
        [InlineData(1, -7, 12)]   // x² - 7x + 12 = 0 -> x = 3, 4
        public void Solve_WhenDiscriminantPositive_ReturnsTwoRoots(double a, double b, double c)
        {
            // Act
            var result = QuadraticEquation.Solve(a, b, c);

            // Assert
            Assert.Equal(2, result.RootCount);
            Assert.NotNull(result.Root1);
            Assert.NotNull(result.Root2);

            // Verify both roots are correct by substituting back into equation
            double x1 = result.Root1.Value;
            double x2 = result.Root2.Value;
            Assert.Equal(0, a * x1 * x1 + b * x1 + c, precision: 8);
            Assert.Equal(0, a * x2 * x2 + b * x2 + c, precision: 8);
        }

        [Fact]
        public void Solve_WhenRootsExist_RootsAreOrdered()
        {
            // Arrange
            double a = 1;
            double b = -5;
            double c = 6;  // x² - 5x + 6 = 0 -> x = 2, 3

            // Act
            var result = QuadraticEquation.Solve(a, b, c);

            // Assert
            Assert.True(result.Root1 > result.Root2,
                "First root should be larger than second root");
        }
    }
}