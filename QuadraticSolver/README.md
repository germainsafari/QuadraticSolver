# Quadratic Equation Solver

A C# application that solves quadratic equations of the form ax² + bx + c = 0.

## Features

- Solves quadratic equations with real coefficients
- Handles all possible cases:
  - Two real roots
  - One real root (double root)
  - No real roots
- Input validation for coefficient 'a' cannot be zero
- Comprehensive unit tests using xUnit

## Project Structure

- `QuadraticSolver/` - Main project
  - `Program.cs` - Console application entry point
  - `QuadraticEquation.cs` - Core solving logic
- `QuadraticSolver.Tests/` - Test project
  - `QuadraticEquationTests.cs` - Unit tests

## How to Use

1. Run the application
2. Enter coefficients a, b, and c when prompted
3. The program will display:
   - Two roots if they exist
   - One root if it's a double root
   - "No real roots" message if roots are complex

## Running Tests

Tests can be run using:
- Visual Studio Test Explorer
- Command line: `dotnet test`

## Requirements

- .NET 6.0 or later
- Visual Studio 2022 or VS Code