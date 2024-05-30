using System;
using System.Collections.Generic;
using System.Linq;

namespace prog6221_st10081087_st10081087
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public double OriginalQuantity { get; set; }
        public string OriginalUnit { get; set; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalQuantity = quantity;
            OriginalUnit = unit;
        }

        public void Reset()
        {
            Quantity = OriginalQuantity;
            Unit = OriginalUnit;
        }
    }

    class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnCaloriesExceeded;

        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories) - {ingredient.FoodGroup}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }

            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke("Warning: Total calories exceed 300!");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Reset();
            }
        }

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            var ingredients = new List<Ingredient>
            {
                new Ingredient("Sugar", 1, "tablespoon", 48, "Sweeteners"),
                new Ingredient("Butter", 2, "tablespoon", 102, "Dairy")
            };

            var steps = new List<Step>
            {
                new Step("Mix sugar with butter"),
                new Step("Bake for 20 minutes")
            };

            var recipe = new Recipe("Example Recipe", ingredients, steps);
            recipe.OnCaloriesExceeded += message => Console.WriteLine(message);
            recipes.Add(recipe);

            recipe.DisplayRecipe();

            recipe.ScaleRecipe(2);
            Console.WriteLine("\nRecipe after scaling:");
            recipe.DisplayRecipe();

            recipe.ResetQuantities();
            Console.WriteLine("\nRecipe after resetting quantities:");
            recipe.DisplayRecipe();

            var ingredients2 = new List<Ingredient>
            {
                new Ingredient("Flour", 1, "cup", 455, "Grains"),
                new Ingredient("Eggs", 2, "pieces", 70, "Protein")
            };

            var steps2 = new List<Step>
            {
                new Step("Mix flour with eggs"),
                new Step("Cook on medium heat")
            };

            var recipe2 = new Recipe("Another Recipe", ingredients2, steps2);
            recipe2.OnCaloriesExceeded += message => Console.WriteLine(message);
            recipes.Add(recipe2);

            Console.WriteLine("\nAll Recipes:");
            foreach (var r in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(r.Name);
            }

            Console.WriteLine("\nEnter the name of the recipe to display:");
            string selectedRecipeName = Console.ReadLine();
            var selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(selectedRecipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}


// References:
// https://youtu.be/aripIuUPO-Q?si=nWZsEDPM9Qlg6gq2
//https://stackoverflow.com/questions/tagged/c%23
//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
//https://www.w3schools.com/cs/cs_classes.php
//https://www.youtube.com/watch?v=24ytq8JP2jI&ab_channel=CuriousDrive%3ASolveCodingChallenges.WinPrizes.
//https://www.youtube.com/watch?v=f2NrKazjWes&ab_channel=FoxLearn




