 Recipe Application

This application manages recipes, including ingredients, steps, and calorie calculations. It also provides functionality to scale recipes and reset ingredient quantities.

## Prerequisites
- .NET SDK (version 5.0 or higher)
- A text editor or IDE (Visual Studio, Visual Studio Code, etc.)

## Getting Started

1. **Clone the repository**:
    ```sh
    git clone https://github.com/yourusername/recipe-application.git
    cd recipe-application
    ```

2. **Build the application**:
    ```sh
    dotnet build
    ```

3. **Run the application**:
    ```sh
    dotnet run --project prog6221_st10081087_st10081087/Program.cs
    ```

4. **Using the application**:
    - When prompted, enter the name of the recipe you wish to display. The application will list all available recipes, and you can select one by typing its name.

5. **Running the tests**:
    ```sh
    dotnet test
    ```

 Project Files

- **Program.cs**: The main entry point of the application. It contains the `Main` method which initializes and runs the application.
- **UnitTest1.cs**: Contains unit tests for the application to verify that the calorie calculations and other functionalities are working correctly.

### Running the Application

1. **Build the project**:
    ```sh
    dotnet build
    ```

2. **Run the application**:
    ```sh
    dotnet run --project prog6221_st10081087_st10081087/Program.cs
    ```

 Running the Tests

To ensure the application works correctly, you can run the unit tests:

```sh
dotnet test
